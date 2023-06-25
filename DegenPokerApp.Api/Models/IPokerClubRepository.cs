using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public interface IPokerClubRepository
    {
        Task<PokerClub> AddOrUpdatePokerClub(PokerClub pokerClub);
        Task DeletePokerClub(string id, string userId);
        Task<IEnumerable<PokerClub>> GetAllPokerClubs();
        Task<PokerClub> GetPokerClubDetails(string id, string userId);

    }
}
