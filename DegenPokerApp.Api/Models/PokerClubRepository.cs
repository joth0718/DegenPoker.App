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

        public async Task<PokerClub> AddOrUpdatePokerClub(PokerClub pokerClub)
        {
            return await _context.AddOrUpdatePokerClub(pokerClub);
        }

        public async Task<PokerClub> GetPokerClubDetails(string id, string userId)
        {
            return await _context.GetPokerClubDetails(id, userId);
        }

        public async Task DeletePokerClub(string id, string userId)
        {
            await _context.DeletePokerClub(id, userId);
        }
    }



}


