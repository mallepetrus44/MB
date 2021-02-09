using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Server.Services
{
    public interface IFotoModelDataService
    {
        Task<IEnumerable<FotoModel>> GetAllFotoModellen();
        Task<FotoModel> GetFotoModelDetails(int fotoModelId);
        Task<FotoModel> AddFotoModel(FotoModel fotoModel);
        Task UpdateFotoModel(FotoModel fotoModel);
        Task DeleteFotoModel(int fotoModelId);
    }
}
