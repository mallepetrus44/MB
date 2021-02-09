using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.Server.Services
{
    public interface IKlantDataService
    {
        Task<IEnumerable<Klant>> GetAllKlanten();
        Task<Klant> GetKlantDetails(int klantId);
        Task<Klant> AddKlant(Klant klant);
        Task UpdateKlant(Klant klant);
        Task DeleteKlant(int klantId);
    }
}
