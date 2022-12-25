using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace TBreaker.Model
{
    [Serializable]
    public class Player
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        public int gameId { get; set; }

        public bool emailVerified { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string language { get; set; }

        public string name { get; set; }

        public bool terms { get; set; }

        public bool optIn { get; set; }

        public SaveData saveData { get; set; }

        public override string ToString()
        {
            return $"player {firstName} {lastName} (full name) {name} with id {Id} and gameId {gameId}"; 
        }
    }

    [Serializable]
    public class PlayerContainer
    {
        [JsonPropertyName("player")]
        public Player player { get; set; }
    }
}
