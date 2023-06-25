using DegenPokerApp.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DegenPokerApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTypeController : Controller
    {
        private readonly IGameTypeRepository _gameTypeRepository;

        public GameTypeController(IGameTypeRepository repository)
        {
            _gameTypeRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGameTypes()
        {
            var result = await _gameTypeRepository.GetAllGameTypes();
            return Ok(result);
        }
    }
}
