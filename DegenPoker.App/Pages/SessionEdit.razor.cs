﻿using DegenPoker.App.Services;
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
        [Parameter]
        public string SessionId { get; set; } = default!;
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;
        public PokerSession? Session { get; set; } = new PokerSession();
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;

            if (Id == null)
            {
                Session = new PokerSession
                {
                    id = Guid.NewGuid().ToString(),
                    UserId = Guid.NewGuid().ToString(),
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
                Session = await SessionDataService.GetPokerSessionDetails(Id, UserId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            var addedPokerSession = await SessionDataService.AddOrUpdatePokerSession(Session);
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
