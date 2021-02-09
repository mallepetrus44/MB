using MB.API.Models;
using MB.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoModelController : Controller
    {
        public readonly IFotoModelRepository _fotoModelRepository;

        public FotoModelController(IFotoModelRepository fotoModelRepository)
        {

            _fotoModelRepository = fotoModelRepository;
        }

        [HttpGet]
        public IActionResult GetAllFotoModels()
        {
            return Ok(_fotoModelRepository.GetAllFotoModellen());
        }

        [HttpGet("{id}")]
        public IActionResult GetFotoModelById(int id)
        {
            return Ok(_fotoModelRepository.GetFotoModelById(id));
        }

        [HttpPost]
        public IActionResult CreateFotoModel([FromBody] FotoModel fotoModel)
        {
            if (fotoModel == null)
                return BadRequest();

            //if (fotoModel.Voornaam == string.Empty || fotoModel.Achternaam == string.Empty)
            //{
            //    ModelState.AddModelError("Naam/Voornaam", "De naam kan niet leeg zijn");
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdFotoModel = _fotoModelRepository.AddFotoModel(fotoModel);

            return Created("fotomodel", createdFotoModel);
        }

        [HttpPut]
        public IActionResult UpdateFotoModel([FromBody] FotoModel fotoModel)
        {
            if (fotoModel == null)
                return BadRequest();

            //if (fotoModel.Voornaam == string.Empty || fotoModel.Achternaam == string.Empty)
            //{
            //    ModelState.AddModelError("Naam/Voornaam", "De naam kan niet leeg zijn");
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var FotoModelToUpdate = _fotoModelRepository.GetFotoModelById(fotoModel.FotoModelId);

            if (FotoModelToUpdate == null)
                return NotFound();

            _fotoModelRepository.UpdateFotoModel(fotoModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFotoModel(int id)
        {
            if (id == 0)
                return BadRequest();

            var fotoModelToDelete = _fotoModelRepository.GetFotoModelById(id);

            if (fotoModelToDelete == null)
                return NotFound();

            _fotoModelRepository.DeleteFotoModel(id);

            return NoContent();
        }
    }
}
