using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bounce
{
    public class Ball
    {
        Pen Pen = new Pen(Color.Black);

        public PointF Position;
        public PointF Speed;

        public float Radius;

        static Random Random = new Random();

        public Ball(float x, float y, float radius)
        {
            Position = new PointF(x, y);
            var xd = Random.Next(1, 6);
            var yd = Random.Next(1, 6);
            if (Random.Next(0, 2) == 0) xd = -xd;
            if (Random.Next(0, 2) == 0) yd = -yd;

            Speed = new PointF(xd, yd);
            Radius = radius;

        }
        //Rita ut bollen
        public void Draw(Graphics g)
        {
            g.DrawEllipse(Pen, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
        }

        //Bollens rörsle
        public void Move(List<Obstacle> obstacles)
        {
            Position.X += Speed.X;
            Position.Y += Speed.Y;

            //Kollar om den krockar med något 
            foreach (var obstacle in obstacles)
            {
                if (obstacle.Intersects(this))
                {
                    obstacle.HandleCollision(this);
                }
            }
        }
    }
}
