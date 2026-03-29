using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Project___Snake
{
    public partial class MainForm : Form
    {
        GameEngine engine;
        WindowsFormRenderer renderer;

        //Poäng räknare
        int player1Score;
        int player2Score;

        //***********************************
        //Utökning för mig
        //***********************************
        int player3Score;



        bool MoreThenOnePlayer;

        internal MainForm(GameEngine engine)
        {
            InitializeComponent();
            this.engine = engine;


            Controls.Add(GameBord);

            // Skapa en instans av WindowsFormRenderer och skicka med PictureBox
            renderer = new WindowsFormRenderer(GameBord);


            this.KeyDown += MainForm_KeyDown!;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            foreach (GameController controller in engine.ReturnGameController())
            {

                if (e.KeyCode == Keys.W || e.KeyCode == Keys.A ||
    e.KeyCode == Keys.S || e.KeyCode == Keys.D ||
    e.KeyCode == Keys.I || e.KeyCode == Keys.J ||
    e.KeyCode == Keys.K || e.KeyCode == Keys.L || e.KeyCode == Keys.T || e.KeyCode == Keys.F || e.KeyCode == Keys.G || e.KeyCode == Keys.H)
                {
                    ConsoleKey consoleKey = MapKeysToConsoleKey(e.KeyCode);
                    controller.HandleInput(consoleKey);
                }
            }
        }

        private ConsoleKey MapKeysToConsoleKey(Keys key)
        {
            switch (key)
            {
                case Keys.W:
                    return ConsoleKey.W;
                case Keys.A:
                    return ConsoleKey.A;
                case Keys.S:
                    return ConsoleKey.S;
                case Keys.D:
                    return ConsoleKey.D;
                case Keys.I:
                    return ConsoleKey.I;
                case Keys.J:
                    return ConsoleKey.J;
                case Keys.K:
                    return ConsoleKey.K;
                case Keys.L:
                    return ConsoleKey.L;

                //***********************************
                //Utökning för mig
                //***********************************
                //Spelplan för tre spelare

                case Keys.T:
                    return ConsoleKey.T;
                case Keys.F:
                    return ConsoleKey.F;
                case Keys.G:
                    return ConsoleKey.G;
                case Keys.H:
                    return ConsoleKey.H;

                default:
                    return (ConsoleKey)key;
            }
        }
        private void Player1StartButton_Click(object sender, EventArgs e)
        {
            Player1StartButton.Enabled = false;
            Player1StartButton.Visible = false;
            Player2StartButton.Enabled = false;
            Player2StartButton.Visible = false;
            Player1ScoreLabel.Visible = true;

            Player3StartButton.Visible = false;
            Player3StartButton.Enabled = false;
            Player3ScoreLabel.Visible = false;

            HowManyPlayerText.Visible = false;
            engine.Run(1);
            timer1.Enabled = true;
            List<Snake> snakes = engine.ReturnSnakes();

        }

        private void Player2StartButton_Click(object sender, EventArgs e)
        {
            MoreThenOnePlayer = true;
            Player1StartButton.Enabled = false;
            Player1StartButton.Visible = false;
            Player2StartButton.Enabled = false;
            Player2StartButton.Visible = false;
            Player1ScoreLabel.Visible = true;
            Player2ScoreLabel.Visible = true;

            Player3StartButton.Visible = false;
            Player3StartButton.Enabled = false;
            Player3ScoreLabel.Visible = false;

            HowManyPlayerText.Visible = false;
            engine.Run(2);
            timer1.Enabled = true;
        }

        //***********************************
        //Utökning för mig
        //***********************************
        //Spelplan för tre spelare
        private void Player3StartButton_Click(object sender, EventArgs e)
        {
            MoreThenOnePlayer = true;
            Player1StartButton.Enabled = false;
            Player1StartButton.Visible = false;
            Player2StartButton.Enabled = false;
            Player2StartButton.Visible = false;
            Player1ScoreLabel.Visible = true;
            Player2ScoreLabel.Visible = true;

            Player3StartButton.Visible = false;
            Player3StartButton.Enabled = false;
            Player3ScoreLabel.Visible = true;

            HowManyPlayerText.Visible = false;
            engine.Run(3);
            timer1.Enabled = true;
        }

        public void ScoreBord()
        {
            List<Snake> snakes = engine.ReturnSnakes();

            if (MoreThenOnePlayer == true)
            {

                foreach (var snake in snakes)
                {
                    if (snake.Color == Color.Red)
                    {
                        player1Score = snake.Score;
                    }
                    if (snake.Color == Color.Blue)
                    {
                        player2Score = snake.Score;
                    }
                    //***********************************
                    //Utökning för mig
                    //***********************************
                    if (snake.Color == Color.Purple)
                    {
                        player3Score = snake.Score;
                    }
                }
                Player1ScoreLabel.BackColor = Color.Red;
                Player2ScoreLabel.BackColor = Color.Blue;
                //***********************************
                //Utökning för mig
                //***********************************
                Player3ScoreLabel.BackColor = Color.Purple;

                Player1ScoreLabel.Text = "Player 1 Score: " + player1Score;
                Player2ScoreLabel.Text = "Player 2 Score: " + player2Score;
                //***********************************
                //Utökning för mig
                //***********************************
                Player3ScoreLabel.Text = "Player 3 Score: " + player3Score;
            }
            else
            {
                foreach (var snake in snakes)
                {
                    if (snake.Color == Color.Red) // Om orm ett är röd
                    {
                        player1Score = snake.Score;
                    }
                }

                Player1ScoreLabel.Text = "Score: " + player1Score;

            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        public void timer1_Tick(object sender, EventArgs e)
        {
            bool alive = engine.Tick();
            renderer.Draw(engine);
            ScoreBord();


            if (alive == false)
            {
                engine.RestGame();

                renderer.Draw(engine);

                timer1.Enabled = false;
                GAMEOVER.Visible = true;

                //***********************************
                //Utökning för mig
                //***********************************
                if (MoreThenOnePlayer == true)
                {
                    if (player1Score > player2Score && player1Score > player3Score)
                    {
                        Winner.Text = "Player 1 Wins with: " + player1Score;
                    }
                    else if (player2Score > player1Score && player2Score > player3Score)
                    {
                        Winner.Text = "Player 2 Wins with: " + player2Score;
                    }
                    else if (player3Score > player1Score && player3Score > player2Score)
                    {
                        Winner.Text = "Player 3 Wins with: " + player3Score;
                    }
                    else
                    {
                        Winner.Text = "It's a draw with: " + player1Score + " Points";
                    }

                    Winner.Visible = true;

                }
                PlayAgain.Enabled = true;
                PlayAgain.Visible = true;
            }
        }


        private void PlayAgain_Click(object sender, EventArgs e)
        {
            player1Score=0;
            player2Score=0;


            Winner.Visible = false;
            PlayAgain.Visible = false;
            PlayAgain.Enabled = false;
            GAMEOVER.Visible = false;
            Player1ScoreLabel.Visible = false;
            Player2ScoreLabel.Visible = false;
            Player1StartButton.Enabled = true;
            Player1StartButton.Visible = true;
            Player2StartButton.Enabled = true;
            Player2StartButton.Visible = true;

            //***********************************
            //Utökning för mig
            //***********************************
            player3Score=0;
            Player3StartButton.Visible = true;
            Player3StartButton.Enabled = true;
            Player3ScoreLabel.Visible = false;

            HowManyPlayerText.Visible = true;


        }

        private void GAMEOVER_Click(object sender, EventArgs e)
        {

        }
    }
}
