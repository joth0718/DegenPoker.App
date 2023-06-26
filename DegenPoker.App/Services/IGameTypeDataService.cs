using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Services
{
    public interface IGameTypeDataService
    {
        Task<GameType> AddOrUpdateGameType(GameType game);
        Task DeletePokerSession(string id, string userId);
        Task<IEnumerable<GameType>> GetAllGameTypes();
        Task<GameType?> GetGameTypeDetails(string id, string userId);
    }
}
