namespace DegenPokerApp.Shared.Domain
{
    public class PokerSession
    {
        public string id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string StakesId { get; set; } = string.Empty;
        public string PokerClubId { get; set; } = string.Empty;
        public string GameTypeId { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public int NrOfHands { get; set; }
        public string? Comment { get; set; }
        public decimal Result { get; set; }
        public string Type = nameof(PokerSession);
    }
}
