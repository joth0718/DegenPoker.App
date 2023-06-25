using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public interface IGameTypeRepository
    {
        Task<IEnumerable<GameType>> GetAllGameTypes();
    }
}
