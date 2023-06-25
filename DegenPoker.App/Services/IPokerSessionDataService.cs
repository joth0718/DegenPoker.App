using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Services
{
    public interface IPokerSessionDataService
    {
        Task<IEnumerable<PokerSession>> GetAllPokerSessions();
        Task<PokerSession> GetPokerSessionDetails(string id, string userId);
    }
}
