using MB.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MB.Server.Services
{
    public class KlantDataService : IKlantDataService
    {
        private readonly HttpClient _httpClient;

        public KlantDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Klant> AddKlant(Klant klant)
        {
            var klantJson =
                 new StringContent(JsonSerializer.Serialize(klant), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/klant", klantJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Klant>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteKlant(int klantId)
        {
            await _httpClient.DeleteAsync($"api/klant/{klantId}");
        }

        public async Task<IEnumerable<Klant>> GetAllKlanten()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Klant>>
                (await _httpClient.GetStreamAsync($"api/klant"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Klant> GetKlantDetails(int klantId)
        {
            return await JsonSerializer.DeserializeAsync<Klant>
                 (await _httpClient.GetStreamAsync($"api/klant/{klantId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateKlant(Klant klant)
        {
            var klantJson =
                 new StringContent(JsonSerializer.Serialize(klant), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/klant", klantJson);
        }

        public async Task<string> UploadKlantImage(MultipartFormDataContent content)
        {
            var postResult = await _httpClient.PostAsync("api/upload", content);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
            else
            {
                var imgUrl = Path.Combine("https://localhost:5011/", postContent);
                return imgUrl;
            }
        }
    }
}
