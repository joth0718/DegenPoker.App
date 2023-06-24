using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Pages
{
    public partial class SessionsOverview
    {

        public List<PokerSession>? PokerSessions { get; set; } = default!;

        private PokerSession? _selectedSession;

        private string Title = "Session overview";

        protected override void OnInitialized()
        {
            PokerSessions = new List<PokerSession> { _selectedSession };
        }

        public void ShowQuickViewPopup(PokerSession selectedSession)
        {
            _selectedSession = selectedSession;
        }

    }
}
