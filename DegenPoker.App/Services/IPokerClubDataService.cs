using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Services
{
    public interface IPokerClubDataService
    {
        Task<IEnumerable<PokerClub>> GetAllPokerClubs();
        Task<PokerClub> GetPokerClubDetails(string id, string userId);
        Task<PokerClub> AddPokerClub(PokerClub pokerClub);
        Task<PokerClub> UpdatePokerClub(PokerClub pokerClub);
        Task DeletePokerClub(string id, string userId);
    }
}
