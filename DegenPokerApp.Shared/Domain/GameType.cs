namespace DegenPokerApp.Shared.Domain
{
    public class GameType
    {
        public string id { get; set; } = default!;
        public string Type { get; set; } = "GameType";
        public string? GameTypeName { get; set; }
        public string UserId { get; set; } = default!;

    }
}
