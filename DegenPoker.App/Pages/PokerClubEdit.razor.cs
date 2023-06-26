using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class PokerClubEdit
    {
        [Inject]
        public IPokerClubDataService PokerClubDataService { get; set; } = default!;
        [Parameter]
        public string? Id { get; set; }
        [Parameter]
        public string PokerClubId { get; set; } = default!;
        [Parameter]
        public string UserId { get; set; } = default!;
        public PokerClub PokerClub { get; set; } = new PokerClub();

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
                PokerClub = new PokerClub
                {
                    id = Guid.NewGuid().ToString(),
                    PokerClubId = Guid.NewGuid().ToString(),
                    PokerClubName = "",
                    UserId = Guid.NewGuid().ToString(),
                    Type = "PokerClub"
                };
            }
            else
            {
                PokerClub = await PokerClubDataService.GetPokerClubDetails(Id, UserId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            var addedPokerClub = await PokerClubDataService.AddOrUpdatePokerClub(PokerClub);
            if (addedPokerClub != null)
            {
                StatusClass = "alert-success";
                Message = "New Pokerclub added/updated successfully.";
                Saved = true;
            }
            else
            {
                StatusClass = "alert-danger";
                Message = "Somethign went wrong adding/updating the new pokerclub. Please try again.";
                Saved = false;
            }
        }

        protected async Task HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeletePokerclub()
        {
            await PokerClubDataService.DeletePokerClub(PokerClub.id, PokerClub.UserId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/sites");
        }
    }
}
