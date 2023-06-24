using DegenPokerApp.Api.Models;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DegenPokerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerClubController : Controller
    {

        private readonly IPokerClubRepository _pokerClubRepository;
        public PokerClubController(IPokerClubRepository pokerClubRepository)
        {
            _pokerClubRepository = pokerClubRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPokerClubs()
        {
            var result = await _pokerClubRepository.GetAllPokerClubs();
            return Ok(result);
        }

        [HttpGet("{id}/{pokerClubId}")]
        public async Task<IActionResult> GetPokerClubDetails(string id, string pokerClubId)
        {
            var result = await _pokerClubRepository.GetPokerClubDetails(id, pokerClubId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePokerClub([FromBody] PokerClub pokerClub)
        {
            if (pokerClub == null)
                return BadRequest();

            if (pokerClub.PokerClubName == string.Empty)
            {
                ModelState.AddModelError("Pokerclub Name", "The name shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPokerClub = await _pokerClubRepository.CreatePokerClub(pokerClub);

            return Created("pokerclub", createdPokerClub);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePokerClub([FromBody] PokerClub pokerClub)
        {
            if (pokerClub == null)
                return BadRequest();

            if (pokerClub.PokerClubName == string.Empty)
            {
                ModelState.AddModelError("Pokerclub Name", "The name shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedPokerClub = await _pokerClubRepository.UpdatePokerClub(pokerClub);

            return Ok(updatedPokerClub);
        }

        [HttpDelete("{id}/{pokerClubId}")]
        public async Task DeletePokerClub(string id, string pokerClubId)
        {
            await _pokerClubRepository.DeletePokerClub(id, pokerClubId);
        }
    }
}
