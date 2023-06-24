using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Services
{
    public interface IPokerClubDataService
    {
        Task<IEnumerable<PokerClub>> GetAllPokerClubs();
        Task<PokerClub> GetPokerClubDetails(string id, string pokerClubId);
        Task<PokerClub> AddPokerClub(PokerClub pokerClub);
        Task<PokerClub> UpdatePokerClub(PokerClub pokerClub);
        Task DeletePokerClub(string id, string pokerClubId);
    }
}
