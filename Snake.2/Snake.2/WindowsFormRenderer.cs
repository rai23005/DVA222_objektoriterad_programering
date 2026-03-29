using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___Snake
{
    internal class WindowsFormRenderer
    {
        private readonly PictureBox pictureBox;

        public WindowsFormRenderer(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
        }

        public void Draw(GameEngine engine)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                List<Snake> snakeList = engine.ReturnSnakes();
                List<Food> foodList = engine.ReturnFood();

                // Rita ut alla ormar
                foreach (Snake snake in snakeList)
                {
                    snake.Draw(graphics); // Anropa Draw-metoden för varje orm
                }

                // Rita ut frukter
                foreach (Food food in foodList)
                {
                    food.Draw(graphics); // Anropa Draw-metoden för varje frukt
                }
            }

            pictureBox.Image = bitmap;
        }
    }
}

