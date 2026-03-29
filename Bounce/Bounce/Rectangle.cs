using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    public abstract class Rectangle : Obstacle
    {

        //Vilken hastighet som bollar skall ha vid träff av objekt
        protected float speedFactor;
        public Rectangle(int xposition, int yposition, int width, int height) : base(xposition, yposition, width, height)
        {

        }

        public override void HandleCollision(Ball ball)
        {

            ball.Speed.Y = (ball.Speed.Y* speedFactor);
            ball.Speed.X = (ball.Speed.X* speedFactor);
        }

    }
}
