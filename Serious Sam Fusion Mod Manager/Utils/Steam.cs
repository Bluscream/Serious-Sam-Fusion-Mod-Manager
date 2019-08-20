using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Steam.Classes;

namespace Steam
{
    public static class Utils {
        public static async Task<GetPublishedFileDetailsResponse> GetPublishedFileDetailsAsync(HttpClient webClient, SSF.Mod Mod) => await GetPublishedFileDetailsAsync(webClient, Mod.Id);
        public static async Task<GetPublishedFileDetailsResponse> GetPublishedFileDetailsAsync(HttpClient webClient, string fileId) => await GetPublishedFileDetailsAsync(webClient, new List<string>() { fileId });
        public static async Task<GetPublishedFileDetailsResponse> GetPublishedFileDetailsAsync(HttpClient webClient, List<string> fileIds)
        {
            /*SteamRequest request = new SteamRequest("ISteamRemoteStorage/GetPublishedFileDetails/v1/");
            request.AddParameter("itemcount", fileIds.Count);
            request.AddParameter("publishedfileids", fileIds.ToArray());
			var response = steam.Execute(request);
            Console.WriteLine(response.Content);
            */
            var values = new Dictionary<string, string> { { "itemcount", fileIds.Count.ToString() } };
            for (int i = 0; i < fileIds.Count; i++)
            {
                values.Add($"publishedfileids[{i}]", fileIds[i].ToString() );
            }
            var content = new FormUrlEncodedContent(values);
            var url = new Uri("https://api.steampowered.com/ISteamRemoteStorage/GetPublishedFileDetails/v1/");
            Console.WriteLine($"[Steam] POST to {url} with payload {content.ToString()}");
            var response = await webClient.PostAsync(url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetPublishedFileDetailsResponse>(responseString);
        }
    }
}
