namespace TBreaker.Model
{
    [Serializable]
    public struct scoreboardScoreEntry
    {
        public int playerId { get; set; }
        public string name { get; set; }    
        public int score { get; set; }
        public int rank { get; set; }   
    }

    public class scoreboardResponse
    {
        public scoreboardScoreEntry[] result { get; set; }

    }
}