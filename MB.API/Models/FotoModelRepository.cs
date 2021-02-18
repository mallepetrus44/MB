using MB.API.Data;
using MB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MB.API.Models
{
    public class FotoModelRepository : IFotoModelRepository
    {
        private readonly ApplicationDbContext _mBDbContext;

        public FotoModelRepository(ApplicationDbContext mBDbContext)
        {
            _mBDbContext = mBDbContext;
        }

        public FotoModel AddFotoModel(FotoModel fotoModel)
        {
            var addedEntity = _mBDbContext.FotoModellen.Add(fotoModel);
            _mBDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void DeleteFotoModel(int fotoModelId)
        {
            var foundFotoModel = _mBDbContext.FotoModellen.FirstOrDefault(p => p.FotoModelId == fotoModelId);
            if (foundFotoModel == null) return;

            _mBDbContext.FotoModellen.Remove(foundFotoModel);
            _mBDbContext.SaveChanges();
        }

        public IEnumerable<FotoModel> GetAllFotoModellen()
        {
            return _mBDbContext.FotoModellen;
        }

        public FotoModel GetFotoModelById(int fotoModelId)
        {
            return _mBDbContext.FotoModellen.FirstOrDefault(p => p.FotoModelId == fotoModelId);
        }

        public FotoModel UpdateFotoModel(FotoModel fotoModel)
        {
            var foundFotoModel = _mBDbContext.FotoModellen.FirstOrDefault(p => p.FotoModelId == fotoModel.FotoModelId);

            if (foundFotoModel != null)
            {
                foundFotoModel.Leeftijd = fotoModel.Leeftijd;
                foundFotoModel.Geboortedatum = fotoModel.Geboortedatum;
                foundFotoModel.Geslacht = fotoModel.Geslacht;
                foundFotoModel.Bovenwijdte = fotoModel.Bovenwijdte;
                foundFotoModel.Taillewijdte = fotoModel.Taillewijdte;
                foundFotoModel.Heupwijdte = fotoModel.Heupwijdte;
                foundFotoModel.Lengte = fotoModel.Lengte;
                foundFotoModel.Fotos = fotoModel.Fotos;
                foundFotoModel.Voornaam = fotoModel.Voornaam;
                foundFotoModel.Achternaam = fotoModel.Achternaam;
                foundFotoModel.Adres = fotoModel.Adres;
                foundFotoModel.Postcode = fotoModel.Postcode;
                foundFotoModel.Stad = fotoModel.Stad;
                foundFotoModel.Fotos = fotoModel.Fotos;

                _mBDbContext.SaveChanges();

                return foundFotoModel;
            }

            return null;
        }

   
    }
}
