using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    internal class GreenLine : Obstacle
    {

        const int height = 1;

        public GreenLine(int xposition, int yposition, int width) : base(xposition, yposition, width, height)
        {
            //Färg på Linjen
            Color = Color.Green;

        }

      
        //Bollen studsar mot grön objekt 
        public override void HandleCollision(Ball ball)
        {
            ball.Speed.Y = -ball.Speed.Y;
        }


    }
}

