using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class SessionsOverview
    {
        [Inject]
        public IPokerSessionDataService SessionDataService { get; set; } = default!;
        [Inject]
        public IPokerClubDataService ClubDataService { get; set; } = default!;
        [Parameter]
        public string PokerClubId { get; set; } = default!;
        [Parameter]
        public string Id { get; set; } = default!;
        [Parameter]
        public string UserId { get; set; } = default!;
        public List<PokerSession>? PokerSessions { get; set; } = default!;
        public List<PokerClub> Clubs { get; set; } = default!;

        private string Title = "Session overview";

        protected override async Task OnInitializedAsync()
        {
            PokerSessions = (await SessionDataService.GetAllPokerSessions()).ToList();
            Clubs = (await ClubDataService.GetAllPokerClubs()).ToList();
        }

    }
}
