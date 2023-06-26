using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{

    public partial class GameTypeEdit
    {
        [Parameter]
        public string? Id { get; set; } = default!;
        [Parameter]
        public GameType Game { get; set; } = new GameType();
        [Parameter]
        public string UserId { get; set; } = default!;
        [Inject]
        public IGameTypeDataService GameTypeDataService { get; set; } = default!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;


        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;


            if (Id == null)
            {
                Game = new GameType
                {
                    id = Guid.NewGuid().ToString(),
                    UserId = Guid.NewGuid().ToString(),
                    GameTypeName = string.Empty,
                    Type = "GameType"
                };
            }
            else
            {
                Game = await GameTypeDataService.GetGameTypeDetails(Id, UserId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            var addedGameType = await GameTypeDataService.AddOrUpdateGameType(Game);
            if (addedGameType != null)
            {
                StatusClass = "alert-success";
                Message = "New Game Type added/updated successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Somethign went wrong adding/updating the new Game type. Please try again.";
                Saved = false;
            }

        }
        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteGameType()
        {
            await GameTypeDataService.DeletePokerSession(Game.id, Game.UserId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/gametypes");
        }
    }
}
