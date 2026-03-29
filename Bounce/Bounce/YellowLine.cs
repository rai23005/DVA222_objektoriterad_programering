using Bounce;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    internal class YellowLine : Obstacle
    {
        const int width = 1;

        public YellowLine(int xposition, int yposition, int height) : base(xposition, yposition, width, height)
        {
            //Färg på Linjen
            Color = Color.Yellow;
        }


        //Skall studsa mot den gula objektet
        public override void HandleCollision(Ball ball)
        {
            ball.Speed.X = -ball.Speed.X;

        }


    }
}

