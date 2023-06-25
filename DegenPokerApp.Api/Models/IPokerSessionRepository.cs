using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public interface IPokerSessionRepository
    {
        Task<PokerSession> AddOrUpdatePokerSession(PokerSession session);
        Task DeletePokerSession(string id, string userId);
        Task<IEnumerable<PokerSession>> GetAllPokerSessions();
        Task<PokerSession> GetPokerSessionDetails(string id, string userId);
    }
}
