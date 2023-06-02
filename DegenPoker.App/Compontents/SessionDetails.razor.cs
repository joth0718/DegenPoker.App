using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Compontents
{
    public partial class SessionDetails
    {
        [Parameter]
        public PokerSession PokerSession { get; set; } = default!;
    }
}
