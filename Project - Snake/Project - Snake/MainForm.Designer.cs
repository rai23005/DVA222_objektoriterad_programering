namespace Project___Snake
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Player1StartButton = new Button();
            Player2StartButton = new Button();
            Player1ScoreLabel = new Label();
            Player2ScoreLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            HowManyPlayerText = new Label();
            GAMEOVER = new Label();
            GameBord = new PictureBox();
            Winner = new Label();
            PlayAgain = new Button();
            ((System.ComponentModel.ISupportInitialize)GameBord).BeginInit();
            SuspendLayout();
            // 
            // Player1StartButton
            // 
            Player1StartButton.Location = new Point(680, 47);
            Player1StartButton.Name = "Player1StartButton";
            Player1StartButton.Size = new Size(130, 71);
            Player1StartButton.TabIndex = 0;
            Player1StartButton.Text = "Player 1";
            Player1StartButton.UseVisualStyleBackColor = true;
            Player1StartButton.Click += Player1StartButton_Click;
            // 
            // Player2StartButton
            // 
            Player2StartButton.Location = new Point(680, 124);
            Player2StartButton.Name = "Player2StartButton";
            Player2StartButton.Size = new Size(130, 71);
            Player2StartButton.TabIndex = 1;
            Player2StartButton.Text = "Player 2";
            Player2StartButton.UseVisualStyleBackColor = true;
            Player2StartButton.Click += Player2StartButton_Click;
            // 
            // Player1ScoreLabel
            // 
            Player1ScoreLabel.Location = new Point(680, 14);
            Player1ScoreLabel.Name = "Player1ScoreLabel";
            Player1ScoreLabel.Size = new Size(130, 71);
            Player1ScoreLabel.TabIndex = 3;
            Player1ScoreLabel.Text = "Player 1 Score : 0";
            Player1ScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            Player1ScoreLabel.Visible = false;
            // 
            // Player2ScoreLabel
            // 
            Player2ScoreLabel.Location = new Point(680, 85);
            Player2ScoreLabel.Name = "Player2ScoreLabel";
            Player2ScoreLabel.Size = new Size(130, 71);
            Player2ScoreLabel.TabIndex = 4;
            Player2ScoreLabel.Text = "Player 2 Score : 0";
            Player2ScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            Player2ScoreLabel.Visible = false;
            // 
            // timer1
            // 
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // HowManyPlayerText
            // 
            HowManyPlayerText.AutoSize = true;
            HowManyPlayerText.Location = new Point(680, 24);
            HowManyPlayerText.Name = "HowManyPlayerText";
            HowManyPlayerText.Size = new Size(131, 20);
            HowManyPlayerText.TabIndex = 5;
            HowManyPlayerText.Text = "How many players";
            // 
            // GAMEOVER
            // 
            GAMEOVER.Font = new Font("Segoe UI", 45F);
            GAMEOVER.Location = new Point(103, 37);
            GAMEOVER.Margin = new Padding(2, 0, 2, 0);
            GAMEOVER.Name = "GAMEOVER";
            GAMEOVER.Size = new Size(458, 116);
            GAMEOVER.TabIndex = 6;
            GAMEOVER.Text = "GAME OVER";
            GAMEOVER.TextAlign = ContentAlignment.MiddleCenter;
            GAMEOVER.Visible = false;
            // 
            // GameBord
            // 
            GameBord.BackColor = SystemColors.ScrollBar;
            GameBord.Location = new Point(16, 14);
            GameBord.Name = "GameBord";
            GameBord.Size = new Size(640, 640);
            GameBord.TabIndex = 2;
            GameBord.TabStop = false;
            // 
            // Winner
            // 
            Winner.Location = new Point(213, 178);
            Winner.Name = "Winner";
            Winner.Size = new Size(238, 95);
            Winner.TabIndex = 7;
            Winner.Text = "Winner:";
            Winner.TextAlign = ContentAlignment.MiddleCenter;
            Winner.Visible = false;
            // 
            // PlayAgain
            // 
            PlayAgain.Enabled = false;
            PlayAgain.Location = new Point(262, 300);
            PlayAgain.Margin = new Padding(2, 2, 2, 2);
            PlayAgain.Name = "PlayAgain";
            PlayAgain.Size = new Size(149, 98);
            PlayAgain.TabIndex = 8;
            PlayAgain.Text = "Play again?";
            PlayAgain.UseVisualStyleBackColor = true;
            PlayAgain.Visible = false;
            PlayAgain.Click += PlayAgain_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 703);
            Controls.Add(PlayAgain);
            Controls.Add(Winner);
            Controls.Add(GAMEOVER);
            Controls.Add(HowManyPlayerText);
            Controls.Add(Player2ScoreLabel);
            Controls.Add(Player1ScoreLabel);
            Controls.Add(GameBord);
            Controls.Add(Player2StartButton);
            Controls.Add(Player1StartButton);
            Name = "MainForm";
            Text = "Snake!";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)GameBord).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Player1StartButton;
        private Button Player2StartButton;
        private Label Player1ScoreLabel;
        private Label Player2ScoreLabel;
        private System.Windows.Forms.Timer timer1;
        private Label HowManyPlayerText;
        private Label GAMEOVER;
        private PictureBox GameBord;
        private Label Winner;
        private Button PlayAgain;
    }
}