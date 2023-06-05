using Microsoft.AspNetCore.Components;

namespace DegenPoker.App.Compontents
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
