using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SSFModManager;
using SteamSharp;
using Steam.Classes;
using System.Net.Http;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;

namespace SSF
{
    public enum Architecture {
        [Description("x64")]
        WIN_64,
        [Description("x86")]
        WIN_32
    }
    public class Binary
    {
        public string FileName = "";
        public List<Process> Processes { get; set; } = new List<Process>();
        public FileInfo File(Game game, Architecture arch) => game.BasePath.CombineFile("bin", arch.GetDescription(), FileName);
        public bool Running() {
            var pName = Path.GetFileNameWithoutExtension(FileName);
            Processes = Process.GetProcessesByName(pName).ToList();
            if (Processes.Count == 0) return false;
            return true;
        }
    }
    public class Binaries {
        public Binary Main = new Binary() { FileName = Game.AppFileName };
        public Binary Modded = new Binary() { FileName = "Sam2017_Unrestricted.exe" };
        public Binary Editor = new Binary() { FileName = "Sam2017_SeriousEditor.exe" };
    }
    public class Game
    {
        public const string Name = "Serious Sam Fusion";
        public const int SteamAppId = 564310;
        public const string AppFileName = "Sam2017.exe";
        public List<Process> Processes { get { return Binaries.Main.Processes.Concat(Binaries.Modded.Processes).ToList(); } }
        public Binaries Binaries { get; set; } = new Binaries();
        public DirectoryInfo DisabledModsDir { get { return BasePath.Combine("Temp", "SteamWorkshop"); } }
        public DirectoryInfo BasePath { get; set; }
        public List<Mod> Mods { get; set; } = new List<Mod>();
        private List<DirectoryInfo> ModDirs { get; set; } = new List<DirectoryInfo>();
        public delegate void DetailsLoadedEventHandler(object sender);
        public event DetailsLoadedEventHandler OnDetailsLoaded;
        public Game(DirectoryInfo basePath) {
            BasePath = basePath;
            ModDirs = GetModsDirs();
            foreach (var modDir in ModDirs) {
                Mods.AddRange(LoadMods(modDir));
            }
        }
        public bool Running()
        {
            return (Binaries.Main.Running() || Binaries.Modded.Running());
        }
        public List<DirectoryInfo> GetModsDirs(bool force = true)
        {
            if (!force) return ModDirs;
            // if (ModDirs != null && !force) return ModDirs;
            var ContentPathFile = BasePath.CombineFile("Temp", "SteamWorkshop", $"ContentPath_{SteamAppId}.txt");
            // if (!ContentPathFile.Exists) throw new FileNotFoundException();
            var dirs = new List<DirectoryInfo>();
            var lines = File.ReadAllLines(ContentPathFile.FullName);
            foreach (var line in lines) {
                var modDir = new DirectoryInfo(line.Substring(1));
                if (modDir.Exists) dirs.Add(modDir);
            }
            return dirs;
        }
        public List<Mod> LoadMods(DirectoryInfo modsDir) {
            var mods = new List<Mod>();
            foreach (var modDir in Directory.GetDirectories(modsDir.FullName)) {
                var ModDir = new DirectoryInfo(modDir);
                var mod = new Mod(ModDir, this);
                mods.Add(mod);
            }
            return mods;
        }
        public async System.Threading.Tasks.Task<GetPublishedFileDetailsResponse> UpdateModDetailsAsync(HttpClient webClient)
        {
            /*SteamRequest request = new SteamRequest("ISteamRemoteStorage/GetPublishedFileDetails/v1/");
            request.AddParameter("itemcount", Mods.Count);*/
            var fileIds = Mods.Select(t => t.Id).ToList();
            if (fileIds.Count < 1) return null;
            /*request.AddParameter("publishedfileids", fileIds);
			var response = steam.Execute(request);
            Console.WriteLine(response.Content);
            */
            var parsedResponse = await Steam.Utils.GetPublishedFileDetailsAsync(webClient, fileIds);
            foreach (var details in parsedResponse.response.publishedfiledetails) {
                Mods.Where(t => t.Id == details.publishedfileid).First().Details = details;
            }
            try {
                OnDetailsLoaded?.Invoke(this);
            } catch (Exception ex) { Console.WriteLine("[ERROR] UpdateModDetailsAsync: {0}", ex.Message); }
            return parsedResponse;
        }
    }
}
