using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TBreaker.Service;

namespace TBreaker.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TBClient _client;

        public TBClient client { get 
            {
                if (_client == null) { client = new TBClient(new System.Net.Http.HttpClient(), 0, "000", TokenTextBox.Text); }

                return _client;
            }
            set { _client = value; }
        }

        private int lastSessionId;
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sender == GetScoreBtn)
            {
                string output = "";
                try
                {

                    var saveData = await client.GetPlayerSaveData();
                    output = $"Score: {saveData.game.overall.totalScore} \n High score: {saveData.game.overall.highscore} ";
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }
                var outputDialog = new dialog(output);
                outputDialog.Show();
            }

            if (sender == GetScoreBtn_Copy)
            {
                string output = "";
                try
                {
                    var saveData = await client.GetScoreboardScoreEntries();
                    foreach (var item in saveData)
                    {
                        output += $" #{item.rank} : {item.name} ({item.playerId}) \n score: {item.score} \n"; 
                    }
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }
                var outputDialog = new dialog(output);
                outputDialog.Show();
            }




        }

        private async void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == StartGameButton)
            {

                string output = "";
                try
                {
                    var response = await client.startGame();
                    output = "game started! session id: " + response.ToString();
                    lastSessionId = response;
                }
                catch (Exception ex)
                {
                    output = ex.Message;
                }
                var outputDialog = new dialog(output);
                outputDialog.Show();
            }
        }

        private async void EndGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender == EndGameButton)
            {
                string output = "";
                try
                {
                    var response = await client.endGame(lastSessionId, Int32.Parse(ScoreTextBox.Text), Int32.Parse(ScoreTextBox.Text), Int32.Parse(ScoreTextBox.Text) + 200);
                    
                    output = $"Game ended: \n id : {response.id} \n level: {response.level}";
                }
                catch (Exception ex)
                {
                    output = ex.Message;

                }
                var outputDialog = new dialog(output);
                outputDialog.Show();
            }
        }
    }
}
