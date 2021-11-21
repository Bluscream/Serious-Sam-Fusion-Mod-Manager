using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SSFModManager;
using Steam.Classes;
using SteamSharp;

namespace SSF
{
    public class FileWithHash
    {
        public string PrivatePath { get; set; }
        public string Hash { get; set; }
        public FileWithHash(string sharedPath, string hash)
        {
            PrivatePath = sharedPath; Hash = hash;
        }
    }
        /// <summary>
        /// 
        /// </summary>
        public class Mod
        {
            [JsonIgnore]
            private Game Game { get; set; }
            public bool Disabled {
                get {
                    var disabledFile = Game.DisabledModsDir.CombineFile($"{this.Id}.disabled");
                    return disabledFile.Exists;
                }
                set {
                    var disabledFile = Game.DisabledModsDir.CombineFile($"{this.Id}.disabled");
                    switch (value)
                    {
                        case true:
                            if (!disabledFile.Exists) File.WriteAllText(disabledFile.FullName, $"Disabled by Serious Sam Mod Manager at {DateTime.Now}\nID: {Id} ({Uuid})\nName: {Name}\nDir: {Directory.FullName}");
                            break;
                        case false:
                            if (disabledFile.Exists) disabledFile.Delete();
                            break;
                        default:
                            break;
                    }
                }
            }
            public string Id { get; set; } = "<NO ID>";
        public DirectoryInfo Directory { get; set; }
            public string WorkshopVersion { get; set; } = "0";
        public string Name { get; set; } = "<NO NAME>";
            public string Uuid { get; set; } = "<NO UUID";
        public FileWithHash GroFile { get; set; }
            public FileWithHash Thumbnail { get; set; }
            public Publishedfiledetail Details { get; set; }
            public List<string> Tags { get {
                if (Details is null || Details.tags is null) return null;
                var ret = new List<string>();
                foreach (var tag in Details.tags) {
                    ret.Add(tag.tag);
                }
                return ret;
            } }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="directory"></param>
            /// <param name="workshopversion"></param>
            /// <param name="name"></param>
            /// <param name="uuid"></param>
            /// <param name="grofile"></param>
            /// <param name="thumbnail"></param>
            public Mod(string id, DirectoryInfo directory, string workshopversion, string name, string uuid, FileWithHash grofile, FileWithHash thumbnail)
            {
                Id = id; Directory = directory; WorkshopVersion = workshopversion; Name = name; Uuid = uuid; GroFile = grofile; Thumbnail = thumbnail;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="directory"></param>
            /// <returns></returns>
            public Mod(DirectoryInfo directory, Game game)
            {
                var files = directory.GetFiles("*.txt");
                foreach (var file in files)
                {
                    // try {
                    var lines = File.ReadAllLines(file.FullName);
                    foreach (var line in lines)
                    {
                        var attrs = line.Split('#');
                        WorkshopVersion = attrs[0];
                        Name = attrs[1];
                        Uuid = attrs[2];
                        GroFile = new FileWithHash(attrs[3], attrs[4]);
                        Thumbnail = new FileWithHash(attrs[5], attrs[6]);
                    }
                    break;
                    // } catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
                // decimal.TryParse(directory.Name, )
                Id = directory.Name;
                Directory = directory;
                Game = game;
            }
        
            public async Task<Publishedfiledetail> UpdateModDetailsAsync(HttpClient webClient) {
                var parsedResponse = await Steam.Utils.GetPublishedFileDetailsAsync(webClient, Id);
                // Console.WriteLine(parsedResponse.ToJson());
                Details = parsedResponse.response.publishedfiledetails.First();
                return Details;
            }
            public override string ToString() {
                return Name;
            }
    }
    }
