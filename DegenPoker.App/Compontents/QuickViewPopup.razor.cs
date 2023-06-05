using DegenPokerApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Compontents
{
    public partial class QuickViewPopup
    {
        [Parameter]
        public PokerSession? PokerSession { get; set; }

        private PokerSession? _session;

        protected override void OnParametersSet()
        {
            _session = PokerSession;
        }

        public void Close()
        {
            _session = null;
        }
    }
}
