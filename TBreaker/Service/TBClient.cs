using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using TBreaker.Model;

namespace TBreaker.Service
{
    public class TBClient
    {
        private HttpClient client { get; set; }


        private string gameId { get; set; }

        private string token { get; set; }


        public TBClient(HttpClient client, string gameId, string token)
        {
            client.BaseAddress = new UriBuilder("https://engagement-games-api.lwprod.nl").Uri;
            client.DefaultRequestHeaders.Add("authorization", "Bearer " + token);
            client.DefaultRequestHeaders.Add("Origin", "https://letshittheroad.thuisbezorgd.nl");
            client.DefaultRequestHeaders.Add("accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("dnt", "1");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            this.client = client;

            this.gameId = gameId;
            this.token = token;
        }


        public async Task<scoreboardScoreEntry[]> GetScoreboardScoreEntries()
        {
            var response = await client.GetAsync("/score/leaderboard/weekly?gameId=" + gameId);
            var content = await response.Content.ReadFromJsonAsync<DataResponse<scoreboardResponse>>();
            return content.Data.result;
        }


        public async Task<SaveData> GetPlayerSaveData()
        {
            var response = await client.GetAsync("/player?gameId=" + gameId);

            SaveData outSaveData = new SaveData();

            var content = await response.Content.ReadFromJsonAsync<DataResponse<PlayerContainer>>();

            return content.Data.player.saveData;

        }

        public async Task<int> startGame()
        {
            StartGamePayload payload = new StartGamePayload(gameId, 1, DateTime.UtcNow);
            var response = await client.PostAsJsonAsync("/score", payload);
            var content = await response.Content.ReadFromJsonAsync<DataResponse<StartGameResponse>>();
            return content.Data.Id;
        }


        public async Task<EndGameResponse> endGame(int sessionId, int score, int highScore, int enemiesKilled)
        {
  
            EndGamePayload payload = new EndGamePayload(DateTime.UtcNow, gameId, score, score, highScore, enemiesKilled);
            var response = await client.PutAsJsonAsync("/score/" + sessionId, payload);
            Console.WriteLine(JsonSerializer.Serialize(payload));
            Console.WriteLine(response.IsSuccessStatusCode);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var content = await response.Content.ReadFromJsonAsync<DataResponse<EndGameResponse>>();
            return content.Data;
            
        }

    }
}
