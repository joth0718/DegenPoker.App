using DegenPokerApp.App.Models;
using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Pages
{
    public partial class SessionsOverview
    {

        public List<PokerSession>? PokerSessions { get; set; } = default!;

        protected override void OnInitialized()
        {
            PokerSessions = MockDataService.PokerSessions;
        }

    }
}
