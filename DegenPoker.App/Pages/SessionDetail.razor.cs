using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class SessionDetail
    {
        [Parameter]
        public string? SessionId { get; set; }

        public PokerSession? Session { get; set; } = new PokerSession();

        protected override Task OnInitializedAsync()
        {
            // Session = MockDataService.PokerSessions.FirstOrDefault(s => s.PokerSessionId == SessionId);

            return base.OnInitializedAsync();
        }
    }
}
