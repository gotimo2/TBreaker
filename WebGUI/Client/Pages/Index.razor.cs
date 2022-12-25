using TBreaker.Service;

namespace WebGUI.Client.Pages
{
    public partial class Index
    {

        private TBClient _client;

        public TBClient Client { 
            
            get
            {
                _client = buildClient();
                return _client;
            }  
        }

        private string token;

        private string playerId;

        private string gameId;

        private int lastGameId;


        private int desiredScore;

        private string outputText;


        private async void getScore()
        {
            var savedata = await Client.GetPlayerSaveData();

            outputText = $"High score: {savedata.game.overall.highscore} \n total score: {savedata.game.overall.totalScore}";

        }


        private async void getScoreboard()
        {
            var scoreboard = await Client.GetScoreboardScoreEntries();

            var text = "";
            foreach (var entry in scoreboard)
            {
                text += $"{entry.rank} : {entry.name}: \n {entry.score}";
            }

            outputText = text;
        }

        private async void startGame()
        {
            var result = await Client.startGame();
            lastGameId = result;

            outputText = $"game started! id {lastGameId}";
        }

        private async void stopGame()
        {
            var result = await Client.endGame(lastGameId, desiredScore, desiredScore, desiredScore + new Random().Next(200, 250));
            outputText = "Game ended!";
        }

        
        private TBClient buildClient()
        {
            HttpClient http = new HttpClient();
            return new TBClient(http, Int32.Parse(playerId), gameId, token);
        }


    }
}
