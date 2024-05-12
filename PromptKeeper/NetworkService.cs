using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PromptKeeper.Entities;

namespace PromptKeeper
{
    public class NetworkService
    {
        private HttpClient _client;
        private string _baseUri = "http://localhost:5000/api/";

        public NetworkService()
        {
            _client = new HttpClient();
        }

        public async Task SyncFromServer(Action<List<Template>> updateLocalDatabase)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_baseUri + "download");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var templates = JsonConvert.DeserializeObject<List<Template>>(jsonString);
                updateLocalDatabase(templates);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to download data from server: " + ex.Message);
            }
        }

        public async Task SyncToServer(List<Template> templates)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(templates);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(_baseUri + "sync", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to upload data to server: " + ex.Message);
            }
        }
    }
}
