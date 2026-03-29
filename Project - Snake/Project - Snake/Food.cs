using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project___Snake.Snake;

namespace Project___Snake
{

    //Huvud klass på maten, maten ärver från denna klass.
    abstract class Food
    {
        // Positionen på frukten
        public int Xposition {get; private set;}
        public int Yposition { get; private set;}

        //Olika frukt olika färger 
        public Color Color { get; protected set; }

        //Vad frukten är värd 
        protected int score;

        int maxWidth = 400;
        int maxHeight = 400;

        // Vad händer med längden på ormen när frukten äts

        protected int ChangeSnakeLength;

        // Referens till fruktlistan
        private List<Food> fruits;

        public Food(List<Food> fruits)
        {
            Xposition = GenerateRandomPositionX();
            Yposition = GenerateRandomPositionY();
            this.fruits = fruits;
        }


        // Rita ut frukten
        public virtual void Draw(Graphics graphics)
        {
            using (SolidBrush brush = new SolidBrush(Color))
            {
                graphics.FillEllipse(brush, Xposition, Yposition, 15, 15); 
            }
        }

        //När ormen äter frukten
        public void Eaten(List<Snake> snakes)
        {
            foreach (Snake snake in snakes)
            {
                var SnakePoint = snake.GetHead();
                var foodBox = new Rectangle(Xposition, Yposition, 15, 15);
                if (SnakePoint.IntersectsWith(foodBox))
                {
                    snake.EatFood(score, ChangeSnakeLength);
                    RemoveFood();
                                        
                    break;
                }
            }
        }

        // Metod för att ta bort frukten från spelplanen
        protected void RemoveFood()
        {
            fruits.Remove(this);

        }

      
        // Generera slumpmässiga positioner för frukten
        private int GenerateRandomPositionY()
        {
            // Kolla över spel planen 
            return new Random().Next(0, maxHeight - 30);
        }
        private int GenerateRandomPositionX()
        {
            // Kolla över spel planen 
            return new Random().Next(0, maxWidth - 30);
        }
    }
}
