using DegenPokerApp.App.Models;
using DegenPokerApp.Shared.Domain;

namespace DegenPoker.App.Pages
{
    public partial class StakesOverview
    {

        public List<Stakes>? Stakes { get; set; } = default!;

        protected override void OnInitialized()
        {
            Stakes = MockDataService.Stakes;
        }

    }
}
