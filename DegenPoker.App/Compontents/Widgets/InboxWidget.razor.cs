﻿namespace DegenPoker.App.Compontents.Widgets;

public partial class InboxWidget
{
    public int MessageCount { get; set; } = 0;

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(10);
    }
}
