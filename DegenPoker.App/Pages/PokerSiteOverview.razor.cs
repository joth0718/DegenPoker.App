using DegenPokerApp.App.Models;
using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Pages
{
    public partial class PokerSiteOverview
    {
        public List<PokerClub>? PokerClubs { get; set; } = default!;

        protected override void OnInitialized()
        {
            PokerClubs = MockDataService.PokerClubs;
        }

    }
}
