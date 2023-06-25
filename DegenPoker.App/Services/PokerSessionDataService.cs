using DegenPokerApp.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace DegenPoker.App.Services
{
    public class PokerSessionDataService : IPokerSessionDataService
    {
        private readonly HttpClient _httpClient;

        public PokerSessionDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokerSession> GetPokerSessionDetails(string id, string userId)
        {
            return await JsonSerializer.DeserializeAsync<PokerSession>(
                await _httpClient.GetStreamAsync($"api/PokerSession/{id}/{userId}"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<PokerSession>> GetAllPokerSessions()
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<PokerSession>>(
                await _httpClient.GetStreamAsync("api/PokerSession"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
            return result;
        }

        public async Task<PokerSession> AddOrUpdatePokerSession(PokerSession session)
        {
            var pokerSessionJson =
                new StringContent(JsonSerializer.Serialize(session), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/PokerSession", pokerSessionJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<PokerSession>(await
                    response.Content.ReadAsStreamAsync());
            }
            return null;
        }
        public async Task DeletePokerSession(string id, string userId)
        {
            await _httpClient.DeleteAsync($"api/PokerSession/{id}/{userId}");
        }

    }
}
