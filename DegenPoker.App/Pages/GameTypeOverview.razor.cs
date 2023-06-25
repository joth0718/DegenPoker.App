using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class GameTypeOverview
    {
        [Inject]
        public IGameTypeDataService GameTypeDataService { get; set; } = default!;
        [Parameter]
        public string Id { get; set; } = default!;
        [Parameter]
        public string UserId { get; set; } = default!;
        public List<GameType>? GameTypes { get; set; } = default!;


        protected override async Task OnInitializedAsync()
        {
            GameTypes = (await GameTypeDataService.GetAllGameTypes()).ToList();
        }
    }
}
