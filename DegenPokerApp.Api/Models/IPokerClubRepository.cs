using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public interface IPokerClubRepository
    {
        Task<PokerClub> CreatePokerClub(PokerClub pokerClub);
        Task DeletePokerClub(string id, string pokerClubId);
        Task<IEnumerable<PokerClub>> GetAllPokerClubs();
        Task<PokerClub> GetPokerClubDetails(string id, string pokerClubId);
        Task<PokerClub> UpdatePokerClub(PokerClub pokerClub);

    }
}
