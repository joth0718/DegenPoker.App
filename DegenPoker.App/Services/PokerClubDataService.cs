using DegenPokerApp.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace DegenPoker.App.Services
{
    public class PokerClubDataService : IPokerClubDataService
    {
        private readonly HttpClient _httpClient;

        public PokerClubDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokerClub> AddPokerClub(PokerClub pokerClub)
        {
            var pokerClubJson =
                new StringContent(JsonSerializer.Serialize(pokerClub), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("api/PokerClub", pokerClubJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<PokerClub>(await
                    response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task DeletePokerClub(string id, string userId)
        {
            await _httpClient.DeleteAsync($"api/PokerClub/{id}/{userId}");
        }

        public async Task<IEnumerable<PokerClub>> GetAllPokerClubs()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<PokerClub>>(
                await _httpClient.GetStreamAsync("api/PokerClub"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<PokerClub> GetPokerClubDetails(string id, string userId)
        {
            return await JsonSerializer.DeserializeAsync<PokerClub>(
                await _httpClient.GetStreamAsync($"api/PokerClub/{id}/{userId}"), new
                JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        public async Task<PokerClub> UpdatePokerClub(PokerClub pokerClub)
        {
            var pokerClubJson =
                new StringContent(JsonSerializer.Serialize(pokerClub), Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PutAsync("api/PokerClub", pokerClubJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<PokerClub>(await
                    response.Content.ReadAsStreamAsync());
            }
            return null;

        }
    }
}
