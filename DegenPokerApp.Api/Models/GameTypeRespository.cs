using DegenPokerApp.Api.Data;
using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public class GameTypeRespository : IGameTypeRepository
    {
        private readonly DegenPokerContext _context;

        public GameTypeRespository(DegenPokerContext context)
        {
            _context = context;
        }

        public async Task<GameType> AddOrUpdateGameType(GameType game)
        {
            return await _context.AddOrUpdateGameType(game);
        }

        public async Task DeleteGameType(string id, string userId)
        {
            await _context.DeleteGameType(id, userId);
        }

        public async Task<IEnumerable<GameType>> GetAllGameTypes()
        {
            return await _context.GetAllGameTypes();
        }

        public async Task<GameType> GetGameTypeDetails(string id, string userId)
        {
            return await _context.GetGameTypeDetails(id, userId);
        }
    }
}
