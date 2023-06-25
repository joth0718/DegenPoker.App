using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Services
{
    public interface IPokerSessionDataService
    {
        Task<PokerSession> AddOrUpdatePokerSession(PokerSession session);
        Task DeletePokerSession(string id, string userId);
        Task<IEnumerable<PokerSession>> GetAllPokerSessions();
        Task<PokerSession> GetPokerSessionDetails(string id, string userId);
    }
}
