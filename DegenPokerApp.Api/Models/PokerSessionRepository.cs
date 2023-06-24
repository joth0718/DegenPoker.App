using DegenPokerApp.Api.Data;
using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public class PokerSessionRepository : IPokerSessionRepository
    {
        private readonly DegenPokerContext _context;
        public PokerSessionRepository(DegenPokerContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PokerSession>> GetAllPokerSessions()
        {
            return await _context.GetAllPokerSessions();
        }

        public async Task<PokerSession> GetPokerSessionDetails(string id, string userId)
        {
            return await _context.GetPokerSessionDetails(id, userId);
        }
    }
}
