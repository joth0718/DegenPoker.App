﻿using DegenPoker.App.Compontents.Widgets;

namespace DegenPoker.App.Pages
{
    public partial class Index
    {
        public List<Type> Widgets { get; set; } = new List<Type>() { typeof
            (SessionCountWidget), typeof (InboxWidget) };


    }
}
