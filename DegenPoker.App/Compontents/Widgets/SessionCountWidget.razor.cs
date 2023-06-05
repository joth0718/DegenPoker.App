using DegenPokerApp.App.Models;
namespace DegenPoker.App.Compontents.Widgets;

public partial class SessionCountWidget
{
    public int PokerSessionCounter { get; set; }

    protected override void OnInitialized()
    {
        PokerSessionCounter = MockDataService.PokerSessions.Count;
    }
}
