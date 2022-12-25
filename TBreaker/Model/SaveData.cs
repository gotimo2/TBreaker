namespace TBreaker.Model
{
    [Serializable]
    public struct SaveData
    {

        public Game game { get; set; }

        public Ui ui { get; set; }

        [Serializable]
        public struct Game
        {
            public string[] maps { get; set; }

            public Overall overall { get; set; }



        }

        [Serializable]
        public struct Ui
        {
            public bool shown_walkthrough { get; set; }
        }

        [Serializable]
        public struct Overall
        {
            public int totalScore { get; set; }
            public int highscore { get; set; }
        }

        public override string ToString()
        {
            return $"total score: {game.overall.totalScore} high score: {game.overall.highscore}";
        }
    }
}