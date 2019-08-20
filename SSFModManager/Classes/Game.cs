using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SSFModManager;
using SteamSharp;
using Steam.Classes;
using System.Net.Http;

namespace SSF
{
    public class Game
    {
        public const int SteamAppId = 564310;
        public const string AppFileName = "Sam2017.exe";
        public const string AppFileName_Unrestricted = "Sam2017_Unrestricted.exe";
        private const string AppFileName_Editor = "Sam2017_SeriousEditor.exe";
        public DirectoryInfo DisabledModsDir { get { return BasePath.Combine("Temp", "SteamWorkshop"); } }
        public DirectoryInfo BasePath { get; set; }
        public List<Mod> Mods { get; set; }
        private List<DirectoryInfo> ModDirs { get; set; }
        public Game(DirectoryInfo basePath) {
            BasePath = basePath;
            Mods = new List<Mod>();
            ModDirs = GetModsDirs();
            foreach (var modDir in ModDirs) {
                Mods.AddRange(LoadMods(modDir));
            }
        }
        public List<DirectoryInfo> GetModsDirs(bool force = false)
        {
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
            /*request.AddParameter("publishedfileids", fileIds);
			var response = steam.Execute(request);
            Console.WriteLine(response.Content);
            */
            var parsedResponse = await Steam.Utils.GetPublishedFileDetailsAsync(webClient, fileIds);
            foreach (var details in parsedResponse.response.publishedfiledetails) {
                Mods.Where(t => t.Id == details.publishedfileid).First().Details = details;
            }
            return parsedResponse;
        }
    }
}
