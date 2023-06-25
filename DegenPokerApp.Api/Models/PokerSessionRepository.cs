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

        public async Task<PokerSession> AddOrUpdatePokerSession(PokerSession session)
        {
            return await _context.AddOrUpdatePokerSession(session);
        }

        public async Task DeletePokerSession(string id, string userId)
        {
            await _context.DeletePokerSession(id, userId);
        }

        public async Task<IEnumerable<PokerSession>> GetAllPokerSessions()
        {
            return await _context.GetAllPokerSessions();
        }

        public async Task<PokerSession> GetPokerSessionDetails(string id, string userId)
        {
            var result = await _context.GetPokerSessionDetails(id, userId);
            return result;
        }
    }
}
