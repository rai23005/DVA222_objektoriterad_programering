using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bounce
{
    public class Engine
    {
        MainForm Form = new MainForm();
        Timer Timer = new Timer();
        List<Ball> Balls = new List<Ball>();
        List<Obstacle> Obstacles = new List<Obstacle>();
        Random Random = new Random();

        public void Run()
        {
            Form.Paint += Draw;
            Timer.Tick += TimerEventHandler;
            Timer.Interval = 1000 / 25;
            Timer.Start();

            AddObstacles();

            Application.Run(Form);
        }

        void TimerEventHandler(Object obj, EventArgs args)
        {
            if (Random.Next(100) < 25)
            {
                var ball = new Ball(400, 300, 10);
                Balls.Add(ball);
            }

            foreach (var ball in Balls) ball.Move(Obstacles);

            Form.Refresh();
        }
        //Ritar ut allt på skärmen
        void Draw(Object obj, PaintEventArgs args)
        {
            foreach (var rectangle in Obstacles) rectangle.Draw(args.Graphics);
            foreach (var ball in Balls) ball.Draw(args.Graphics);
        }

        //Lägger till objekt 
        void AddObstacles()
        {
          
            Obstacles.Add(new RectangleBlue(400, 450, 175, 50));

            Obstacles.Add(new RectangleRed(100, 100, 100, 50));
            Obstacles.Add(new RectangleRed(250, 100, 150, 100));

            Obstacles.Add(new YellowLine(200, 200, 200));
            Obstacles.Add(new YellowLine(600, 200, 200));
            Obstacles.Add(new YellowLine(100, 200, 800));

            Obstacles.Add(new GreenLine(100, 50, 600));
            Obstacles.Add(new GreenLine(450, 100, 100));
            Obstacles.Add(new GreenLine(100, 450, 100));
           
        }

    }
}
