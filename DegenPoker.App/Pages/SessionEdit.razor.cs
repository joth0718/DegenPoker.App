using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class SessionEdit
    {
        [Inject]
        public IPokerSessionDataService SessionDataService { get; set; } = default!;
        [Parameter]
        public string? Id { get; set; }
        [Parameter]
        public string UserId { get; set; } = default!;
        public PokerSession PokerSession { get; set; } = new PokerSession();

        protected bool Saved;

        public PokerSession? Session { get; set; } = new PokerSession();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (Id == null)
            {
                PokerSession = new PokerSession
                {
                    id = Guid.NewGuid().ToString(),
                    UserId = UserId,
                    PokerClubId = Guid.NewGuid().ToString(),
                    Comment = "",
                    GameTypeId = Guid.NewGuid().ToString(),
                    NrOfHands = 0,
                    Result = 0,
                    SessionDate = DateTime.Now,
                    StakesId = Guid.NewGuid().ToString()
                };
            }
            else
            {
                PokerSession = await SessionDataService.GetPokerSessionDetails(Id, UserId);
            }

        }
    }
}
