﻿namespace DegenPokerApp.Shared.Domain
{
    public class PokerClub
    {
        public int PokerClubId { get; set; }
        public int UserId { get; set; }
        public string PokerClubName { get; set; } = string.Empty;
    }
}
