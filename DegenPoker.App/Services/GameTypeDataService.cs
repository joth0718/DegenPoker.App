using DegenPokerApp.Shared.Domain;
using System.Text;
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

        public async Task<GameType> AddOrUpdateGameType(GameType game)
        {
            var addGameTypeJson =
                new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/GameType", addGameTypeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<GameType>(await
                    response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeletePokerSession(string id, string userId)
        {
            await _httpClient.DeleteAsync($"api/GameType/{id}/{userId}");
        }

        public async Task<IEnumerable<GameType>> GetAllGameTypes()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<GameType>>(
                await _httpClient.GetStreamAsync("api/GameType"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<GameType?> GetGameTypeDetails(string id, string userId)
        {
            return await JsonSerializer.DeserializeAsync<GameType>(
                await _httpClient.GetStreamAsync($"api/GameType/{id}/{userId}"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }
    }
}
