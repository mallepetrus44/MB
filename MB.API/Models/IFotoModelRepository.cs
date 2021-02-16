using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MB.API.Models
{
    public interface IFotoModelRepository
    {
        IEnumerable<FotoModel> GetAllFotoModellen();
        FotoModel GetFotoModelById(int fotoModelId);
        FotoModel AddFotoModel(FotoModel fotoModel);
        FotoModel UpdateFotoModel(FotoModel fotoModel);
        void DeleteFotoModel(int fotoModelId);
        string UploadFotoModelImage(MultipartFormDataContent content);
    }
}
