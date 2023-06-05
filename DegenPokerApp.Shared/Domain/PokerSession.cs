namespace DegenPokerApp.Shared.Domain
{
    public class PokerSession
    {
        public string PokerSessionId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string StakesId { get; set; } = string.Empty;
        public string PokerClubId { get; set; } = string.Empty;
        public string GameTypeId { get; set; } = string.Empty;
        public string GameId { get; set; } = string.Empty;
        public DateTime SessionDate { get; set; }
        public int NrOfHands { get; set; }
        public string? Comment { get; set; }
        public decimal Result { get; set; }
    }
}
