
using System.Text.Json.Serialization;

namespace DegenPokerApp.Shared.Domain
{
    public class PokerClub
    {
        [JsonPropertyName("PokerClubId")]
        public string PokerClubId { get; set; } = Guid.NewGuid().ToString();
        [JsonPropertyName("id")]
        public string id { get; set; } = Guid.NewGuid().ToString();
        [JsonPropertyName("UserId")]
        public string UserId { get; set; } = string.Empty;
        public string PokerClubName { get; set; } = string.Empty;

    }
}
