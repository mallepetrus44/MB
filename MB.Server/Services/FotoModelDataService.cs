using BlazorInputFile;
using MB.Shared;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
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

        private readonly IWebHostEnvironment _environment;
        public FotoModelDataService(IWebHostEnvironment env)
        {
            _environment = env;
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


        public async Task<string> UploadFotoModelImage(MultipartFormDataContent content)
        {

            // resultaat afwachten: De content meegeven (HTTPPOST} aan de httpClient en versturen naar de uploadController 
            var postResult = await _httpClient.PostAsync("api/upload", content);

            var postContent = await postResult.Content.ReadAsStringAsync();


            // als het resultaat niet OK is een exception anders een imageUrl
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
