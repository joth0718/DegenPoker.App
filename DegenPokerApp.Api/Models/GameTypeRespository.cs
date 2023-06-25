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
        public async Task<IEnumerable<GameType>> GetAllGameTypes()
        {
            return await _context.GetAllGameTypes();
        }
    }
}
