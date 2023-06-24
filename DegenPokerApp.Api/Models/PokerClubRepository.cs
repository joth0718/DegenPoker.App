using DegenPokerApp.Api.Data;
using DegenPokerApp.Shared.Domain;

namespace DegenPokerApp.Api.Models
{
    public class PokerClubRepository : IPokerClubRepository
    {
        private readonly DegenPokerContext _context;

        public PokerClubRepository(DegenPokerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PokerClub>> GetAllPokerClubs()
        {
            return await _context.GetAllPokerClubs();
        }

        public async Task<PokerClub> CreatePokerClub(PokerClub pokerClub)
        {
            return await _context.AddPokerClub(pokerClub);
        }

        public async Task<PokerClub> GetPokerClubDetails(string id, string pokerClubId)
        {
            return await _context.GetPokerClubDetails(id, pokerClubId);
        }

        public async Task<PokerClub> UpdatePokerClub(PokerClub pokerClub)
        {
            return await _context.UpdatePokerClub(pokerClub);
        }

        public async Task DeletePokerClub(string id, string pokerClubId)
        {
            await _context.DeletePokerClub(id, pokerClubId);
        }
    }



}


