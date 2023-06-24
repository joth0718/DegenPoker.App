using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Compontents
{
    public partial class SessionCard
    {
        [Parameter]
        public PokerSession PokerSession { get; set; } = default!;

        [Parameter]
        public EventCallback<PokerSession> PokerSessionQuickViewClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public void NavigateToDetails(PokerSession selectedSession)
        {
            NavigationManager.NavigateTo($"/sessiondetail/{selectedSession.id}");
        }
    }
}
