using DegenPokerApp.Shared.Domain;
using System.Text.Json;

namespace DegenPoker.App.Services
{
    public class GameTypeDataService : IGameTypeDataService
    {
        private readonly HttpClient _httpClient;

        public GameTypeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GameType>> GetAllGameTypes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<GameType>>(
                await _httpClient.GetStreamAsync("api/GameType"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }
    }
}
