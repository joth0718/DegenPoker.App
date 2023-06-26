using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public interface IGameTypeRepository
    {
        Task<GameType> AddOrUpdateGameType(GameType game);
        Task DeleteGameType(string id, string userId);
        Task<IEnumerable<GameType>> GetAllGameTypes();
        Task<GameType> GetGameTypeDetails(string id, string userId);
    }
}
