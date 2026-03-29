using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static Project___Snake.Snake;



namespace Project___Snake
{
    public class Snake
    {
        List<Rectangle> body;
        List<Snake> allSnakes;
        Direction direction;
        public Color Color { get; private set; }

        public int Score { get; set; }

        //Spelplan storlek
        int maxWidth = 600;
        int maxHeight = 480;

        int squareSize = 7;

        public bool IsAlive { get; private set; } = true;

        public Snake(int x, int y, Color color, List<Snake> allSnakes)
        {
            //Skapar en ny orm med längd 5
            body = new List<Rectangle>();
            for (int i = 0; i < 15; i++)
            {
                body.Add(new Rectangle(x - i * squareSize, y, squareSize, squareSize));
            }
            //Startvärden, 
            direction = Direction.Up;
            this.Color = color;
            this.allSnakes = allSnakes;
        }

        //Vilket håll ormen rör sig
        public void Move()
        {
            // Spara den aktuella positionen för huvudet
            Rectangle head = body[0];

            // Skapa en ny position för det nya huvudet beroende på riktningen
            Rectangle newHead = new Rectangle(head.Location, head.Size);
            switch (direction)
            {
                case Direction.Left:
                    newHead.X -= squareSize;
                    if (newHead.X < 0)
                        newHead.X = maxWidth - squareSize; 
                    break;
                case Direction.Right:
                    newHead.X += squareSize;
                    if (newHead.X >= maxWidth)
                        newHead.X = 0; 
                    break;
                case Direction.Down:
                    newHead.Y += squareSize;
                    if (newHead.Y >= maxHeight)
                        newHead.Y = 0; 
                    break;
                case Direction.Up:
                    newHead.Y -= squareSize;
                    if (newHead.Y < 0)
                        newHead.Y = maxHeight - squareSize; 
                    break;
            }

            // Flytta resten av kroppen för att följa det nya huvudet
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }

            // Uppdatera huvudets position
            body[0] = newHead;
        }
        //Ändra ormens riktning, Se till att det kan bara röra sig "höger eller vänster"
        public void ChangeDirection(Direction newDirection)
        {
            if ((direction == Direction.Up && newDirection == Direction.Down) ||
                (direction == Direction.Down && newDirection == Direction.Up) ||
                (direction == Direction.Left && newDirection == Direction.Right) ||
                (direction == Direction.Right && newDirection == Direction.Left))
            {
                return;
            }
            direction = newDirection;
        }

        //Ha koll vart huvudet är 
        public RectangleF GetHead()
        {
            if (body.Count > 0)
                return body[0];
            else
                return RectangleF.Empty; 
        }

        //Rita ut ormen
        public void Draw(Graphics graphics)
        {
            Brush bodyColor = new SolidBrush(Color);
            foreach (Rectangle segment in body)
            {
                graphics.FillRectangle(bodyColor, segment);
            }
        }

        //Om ormen kolidera med sig själv
        public void IsCollidingWithSelf()
        {
            RectangleF head = GetHead();
            for (int i = 1; i < body.Count; i++)
            {
                RectangleF segment = body[i];
                if (head.IntersectsWith(segment))
                {
                    Death();
                    break;
                }
            }
        }


        //Krockar med en annan orm 
        public void CollidingWithOtherSnake(List<Snake> allSnakes)
        {
            foreach (Snake otherSnake in allSnakes)
            {
                if (otherSnake != this)
                {
                    RectangleF head = GetHead();

                    foreach (RectangleF segment in otherSnake.body)
                    {
                        if (head.IntersectsWith(segment))
                        {
                            HandleCollision(otherSnake);
                            return; 
                        }
                    }
                }
            }
        }

        private void HandleCollision(Snake otherSnake)
        {
            // Ge den andra ormen poäng
            otherSnake.Score += 5;

            // Ta bort den aktuella ormen
            Death();
        }

        //Vad händer när ormen äter en frukt
        public void EatFood(int score, int GrowBody)
        {
            Score+=score;

            if (GrowBody == 1)
            {
                Grow();
            }
            else if (GrowBody == 2)
            {
                Grow();
                Grow();
            }
            else if (GrowBody == -1)
            {
                Shrink();
            }

        }

        //Ormen växer 
        private void Grow()
        {
            
            Rectangle tail = body[body.Count - 1];

            
            Rectangle newTail = new Rectangle(tail.X + squareSize, tail.Y, squareSize, squareSize);

            
            body.Add(newTail);
        }
        //Ormen krymper
        private void Shrink()
        {
            body.RemoveAt(body.Count - 1);

        }
        //Vad händer när ormen dör
        public void Death()
        {
            allSnakes.Remove(this);

            
        }


        //Inre klass för ha koll på positionen
        public class Position
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(Position other)
            {
                return X == other.X && Y == other.Y;
            }
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            None
        }


    }
}
