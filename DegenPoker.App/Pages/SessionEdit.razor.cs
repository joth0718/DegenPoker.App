using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class SessionEdit
    {
        [Inject]
        public IPokerSessionDataService SessionDataService { get; set; } = default!;
        [Inject]
        public IPokerClubDataService ClubDataService { get; set; } = default!;
        [Parameter]
        public string? Id { get; set; }
        [Parameter]
        public string UserId { get; set; } = default!;
        [Parameter]
        public string SessionId { get; set; } = default!;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected string selectedPokerClubId = string.Empty;
        string selectedPokerClubName = string.Empty;
        protected string SelectedPokerClubId
        {
            get => selectedPokerClubId;
            set { selectedPokerClubId = value; }
        }
        protected bool Saved;
        List<PokerClub> Clubs { get; set; } = new List<PokerClub>();
        public PokerSession? Session { get; set; } = new PokerSession();
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            Clubs = (await ClubDataService.GetAllPokerClubs()).ToList();


            if (Id == null)
            {
                Session = new PokerSession
                {
                    id = Guid.NewGuid().ToString(),
                    UserId = Guid.NewGuid().ToString(),
                    PokerClubId = Clubs.FirstOrDefault().PokerClubId,
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
                Session = await SessionDataService.GetPokerSessionDetails(Id, UserId);
            }
            selectedPokerClubName = Clubs.FirstOrDefault(c => c.PokerClubId == Session.PokerClubId).PokerClubName;
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            var addedPokerSession = await SessionDataService.AddOrUpdatePokerSession(Session);
            if (addedPokerSession != null)
            {
                StatusClass = "alert-success";
                Message = "New PokerSession added/updated successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Somethign went wrong adding/updating the new pokersession. Please try again.";
                Saved = false;
            }
        }
        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeletePokerSession()
        {
            await SessionDataService.DeletePokerSession(Session.id, Session.UserId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/sessions");
        }
    }
}
