using MB.API.Models;
using MB.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlantController : Controller
    {
        private readonly IKlantRepository _klantRepository;

        public KlantController(IKlantRepository klantRepository)
        {
            _klantRepository = klantRepository;
        }

        [HttpGet]
        public IActionResult GetAllKlants()
        {
            return Ok(_klantRepository.GetAllKlanten());
        }

        [HttpGet("{id}")]
        public IActionResult GetKlantById(int id)
        {
            return Ok(_klantRepository.GetKlantById(id));
        }

        [HttpPost]
        public IActionResult CreateKlant([FromBody] Klant klant)
        {
            if (klant == null)
                return BadRequest();

            //if (klant.Voornaam == string.Empty || klant.Achternaam == string.Empty)
            //{
            //    ModelState.AddModelError("Voornaam", "Voornaam is een verplicht veld");
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdKlant = _klantRepository.AddKlant(klant);

            return Created("klant", createdKlant);
        }

        [HttpPut]
        public IActionResult UpdateKlant([FromBody] Klant klant)
        {
            if (klant == null)
                return BadRequest();

            //if (klant.Voornaam == string.Empty || klant.Achternaam == string.Empty)
            //{
            //    ModelState.AddModelError("Achternaam", "Achternaam is een verplicht veld");
            //}

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var klantToUpdate = _klantRepository.GetKlantById(klant.KlantId);

            if (klantToUpdate == null)
                return NotFound();

            _klantRepository.UpdateKlant(klant);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKlant(int id)
        {
            if (id == 0)
                return BadRequest();

            var klantToDelete = _klantRepository.GetKlantById(id);
            if (klantToDelete == null)
                return NotFound();

            _klantRepository.DeleteKlant(id);

            return NoContent();//success
        }
    }
}
