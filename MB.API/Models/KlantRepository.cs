using MB.API.Data;
using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.API.Models
{
    public class KlantRepository : IKlantRepository
    {
        private readonly ApplicationDbContext _mBDbContext;

        public KlantRepository(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }
        public Klant AddKlant(Klant klant)
        {
            var addKlant = _mBDbContext.Klanten.Add(klant);
            _mBDbContext.SaveChanges();
            return addKlant.Entity;
        }

        public void DeleteKlant(int klantId)
        {
            var Klant = _mBDbContext.Klanten.FirstOrDefault(e => e.KlantId == klantId);
            if (Klant == null) return;

            _mBDbContext.Klanten.Remove(Klant);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<Klant> GetAllKlanten()
        {
            return _mBDbContext.Klanten;
        }

        public Klant GetKlantById(int klantId)
        {
            return _mBDbContext.Klanten.FirstOrDefault(c => c.KlantId == klantId);
        }

        public Klant UpdateKlant(Klant klant)
        {
            var updateKlant = _mBDbContext.Klanten.FirstOrDefault(e => e.KlantId == klant.KlantId);

            if (updateKlant != null)
            {
                updateKlant.Voornaam = klant.Voornaam;
                updateKlant.Achternaam = klant.Achternaam;
                updateKlant.Adres = klant.Adres;
                updateKlant.Postcode = klant.Postcode;
                updateKlant.Logo = klant.Logo;
                updateKlant.KvkNummer = klant.KvkNummer;
                updateKlant.BtwNummer = klant.BtwNummer;
                updateKlant.Stad = klant.Stad;
                updateKlant.Goedgekeurd = false;

                _mBDbContext.SaveChanges();

                return updateKlant;
            }

            return null;
        }
    }
}
