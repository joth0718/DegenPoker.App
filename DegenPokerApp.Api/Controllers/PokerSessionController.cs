using DegenPokerApp.Api.Models;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DegenPokerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerSessionController : Controller
    {
        private readonly IPokerSessionRepository _pokerSessionRepository;
        public PokerSessionController(IPokerSessionRepository pokerSessionRepository)
        {
            _pokerSessionRepository = pokerSessionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPokerSessions()
        {
            var result = await _pokerSessionRepository.GetAllPokerSessions();
            return Ok(result);
        }
        [HttpGet("{id}/{userId}")]
        public async Task<IActionResult> GetPokerSessionDetails(string id, string userId)
        {
            var result = await _pokerSessionRepository.GetPokerSessionDetails(id, userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdatePokerSession([FromBody] PokerSession session)
        {
            if (session == null)
                return BadRequest();

            if (session.SessionDate == DateTime.MinValue)
            {
                ModelState.AddModelError("Pokersession Date", "There must be a date of the poker session");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOrUpdatedPokerSession = await _pokerSessionRepository.AddOrUpdatePokerSession(session);

            return Created("pokersession", createdOrUpdatedPokerSession);
        }

        [HttpDelete("{id}/{userId}")]
        public async Task DeletePokerSession(string id, string userId)
        {
            await _pokerSessionRepository.DeletePokerSession(id, userId);
        }
    }


}
