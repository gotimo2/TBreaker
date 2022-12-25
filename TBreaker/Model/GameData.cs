using System.Text.Json.Serialization;

namespace TBreaker.Model
{
    [Serializable]
    public class GameData
    {
        public int highscore { get; set; }
        public int totalScore { get; set; }

        [JsonPropertyName("stat1")]
        public int EnemiesKilled { get; set; }
        public string resultType { get; set; }
    }
}
