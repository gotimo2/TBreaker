namespace TBreaker.Model
{
    [Serializable]
    public class StartGamePayload
    {
        public string gameId { get; set; }
        public int level { get; set; }

        public string startTime { get; set; }

        public StartGamePayload(string gameId, int level, DateTime startTime)
        {
            this.gameId = gameId;
            this.level = level;
            this.startTime = startTime.ToString("yyyy'-'MM'-'dd'T'HH:mm:ss.fff'Z'");
        }
    }
}
