using DegenPoker.App.Services;
using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Pages
{
    public partial class PokerSiteOverview
    {
        [Inject]
        public IPokerClubDataService ClubDataService { get; set; } = default!;
        [Parameter]
        public string PokerClubId { get; set; } = default!;
        [Parameter]
        public string Id { get; set; } = default!;
        [Parameter]
        public string UserId { get; set; } = default!;
        public List<PokerClub>? PokerClubs { get; set; } = default!;


        protected override async Task OnInitializedAsync()
        {
            PokerClubs = (await ClubDataService.GetAllPokerClubs()).ToList();
        }
        /*
        protected async Task<PokerClub> Delete(string pokerClubId)
        {


            return await PokerClubDataService.DeletePokerClub(pokerClubId);

        }*/

    }
}
