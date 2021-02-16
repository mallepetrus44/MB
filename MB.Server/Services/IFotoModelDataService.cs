using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;
using System.Net.Http;

namespace MB.Server.Services
{
    public interface IFotoModelDataService
    {
        Task<IEnumerable<FotoModel>> GetAllFotoModellen();
        Task<FotoModel> GetFotoModelDetails(int fotoModelId);
        Task<FotoModel> AddFotoModel(FotoModel fotoModel);
        Task UpdateFotoModel(FotoModel fotoModel);
        Task DeleteFotoModel(int fotoModelId);
        Task<string> UploadFotoModelImage(MultipartFormDataContent content);
    }
}
