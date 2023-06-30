using DegenPokerApp.Api.Models;
using DegenPokerApp.Shared.Domain;
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
        [HttpGet("{id}/{UserId}")]
        public async Task<GameType> GetGameTypeDetails(string id, string UserId)
        {
            return await _gameTypeRepository.GetGameTypeDetails(id, UserId);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateGameType([FromBody] GameType game)
        {
            if (game == null)
                return BadRequest();

            if (game.GameTypeName == string.Empty)
            {
                ModelState.AddModelError("GameType Name", "The name shouldn't be empty");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdGameType = await _gameTypeRepository.AddOrUpdateGameType(game);

            return Created("gametype", createdGameType);
        }

        [HttpDelete("{id}/{UserId}")]
        public async Task DeleteGameType(string id, string userId)
        {
            await _gameTypeRepository.DeleteGameType(id, userId);
        }
    }
}
