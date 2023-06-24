using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public interface IPokerSessionRepository
    {
        Task<IEnumerable<PokerSession>> GetAllPokerSessions();
        Task<PokerSession> GetPokerSessionDetails(string id, string userId);
    }
}
