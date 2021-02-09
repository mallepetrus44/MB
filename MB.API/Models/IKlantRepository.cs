using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.API.Models
{
    public interface IKlantRepository
    {
        IEnumerable<Klant> GetAllKlanten();
        Klant GetKlantById(int klantId);
        Klant AddKlant(Klant klant);
        Klant UpdateKlant(Klant klant);
        void DeleteKlant(int klantId);
    }
}
