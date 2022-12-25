namespace TBreaker.Model
{
    [Serializable]
    public partial class EndGamePayload
    {
        public string endTime { get; set; }
        public string gameId { get; set; }
        public int score { get; set; }
        public GameData gameData { get; set; }

        public EndGamePayload(DateTime endTime, string gameId, int score, int totalScore, int highScore, int stat1, string resultType = "failed")
        {

            this.endTime = endTime.ToString("yyyy'-'MM'-'dd'T'HH:mm:ss.fff'Z'"); ;
            this.gameId = gameId;
            this.score = score;
            gameData = new GameData
            {
                highscore = highScore,
                EnemiesKilled = stat1,
                totalScore = totalScore,
                resultType = resultType
            };
        }


    }
}
