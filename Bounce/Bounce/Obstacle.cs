using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    public abstract class Obstacle
    {
        protected int Xposition;
        protected int Yposition;
        protected int Width;
        protected int Height;

        protected Color Color;

        public Obstacle(int xposition, int yposition, int width, int height)
        {
            Xposition = xposition;
            Yposition = yposition;
            Width = width;
            Height = height;

            
        }

        //Rita ut objekt
        public virtual void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color))
            {
                graphics.DrawRectangle(pen, Xposition, Yposition, Width, Height);
            }
        }

        //Kollar om det är en krock
        public bool Intersects(Ball ball)
        {
            RectangleF obstacleRect = new RectangleF(Xposition, Yposition, Width, Height);
            RectangleF ballRect = new RectangleF(ball.Position.X - ball.Radius, ball.Position.Y - ball.Radius, 2 * ball.Radius, 2 * ball.Radius);
            return obstacleRect.IntersectsWith(ballRect);
        }

        //Vad som skall ske vid krock
        public virtual void HandleCollision(Ball ball)
        {
            // Vare färg har egen egenskap vid krock
        }
    }
}
