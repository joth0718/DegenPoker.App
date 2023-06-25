using DegenPokerApp.Api.Models;
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
    }

}
