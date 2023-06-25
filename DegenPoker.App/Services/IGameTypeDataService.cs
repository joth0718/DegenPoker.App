using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Services
{
    public interface IGameTypeDataService
    {
        Task<IEnumerable<GameType>> GetAllGameTypes();
    }
}
