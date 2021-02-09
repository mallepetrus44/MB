using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MB.Server.Services
{
    public class FotoModelDataService : IFotoModelDataService
    {
        private readonly HttpClient _httpClient;

        public FotoModelDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FotoModel> AddFotoModel(FotoModel fotoModel)
        {
            var fotoModelJson =
                new StringContent(JsonSerializer.Serialize(fotoModel), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/fotoModel", fotoModelJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<FotoModel>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteFotoModel(int fotoModelId)
        {
            await _httpClient.DeleteAsync($"api/fotoModel/{fotoModelId}");
        }

        public async Task<IEnumerable<FotoModel>> GetAllFotoModellen()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<FotoModel>>
                (await _httpClient.GetStreamAsync($"api/fotoModel"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<FotoModel> GetFotoModelDetails(int fotoModelId)
        {
            return await JsonSerializer.DeserializeAsync<FotoModel>
                (await _httpClient.GetStreamAsync($"api/fotoModel/{fotoModelId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateFotoModel(FotoModel fotoModel)
        {
            var fotoModelJson =
               new StringContent(JsonSerializer.Serialize(fotoModel), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/fotoModel", fotoModelJson);
        }
    }
}
