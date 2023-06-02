namespace DegenPokerApp.Shared.Domain
{
    public class PokerSession
    {
        public int PokerSessionId { get; set; }
        public int UserId { get; set; }
        public int StakesId { get; set; }
        public int PokerClubId { get; set; }
        public int GameTypeId { get; set; }
        public int GameId { get; set; }
        public DateTime SessionDate { get; set; }
        public int NrOfHands { get; set; }
        public string? Comment { get; set; }
        public decimal Result { get; set; }
    }
}
