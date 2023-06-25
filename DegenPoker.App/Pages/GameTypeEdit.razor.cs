using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{

    public partial class GameTypeEdit
    {
        [Parameter]
        public string? Id { get; set; }
        [Parameter]
        public GameType? Game { get; set; }
        [Inject]
        public IGameTypeDataService GameTypeDataService { get; set; } = default!;


        protected bool Saved;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        List<GameType> GameTypes = new List<GameType>();

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
                // Game = await GameTypeDataService.GetPokerSessionDetails(Id, UserId);
            }
            // selectedPokerClubName = Clubs.FirstOrDefault(c => c.PokerClubId == Session.PokerClubId).PokerClubName;
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            /* var addedPokerSession = await SessionDataService.AddOrUpdatePokerSession(Session);
             if (addedPokerSession != null)
             {
                 StatusClass = "alert-success";
                 Message = "New PokerSessino added/updated successfully.";
                 Saved = true;
             }
             else
             {
                 StatusClass = "alert-danger";
                 Message = "Somethign went wrong adding/updating the new pokersession. Please try again.";
                 Saved = false;
             }*/
        }
        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeletePokerSession()
        {
            //   await SessionDataService.DeletePokerSession(Session.id, Session.UserId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            //    NavigationManager.NavigateTo("/sessions");
        }
    }
}
