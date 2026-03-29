using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project___Snake.Snake;

namespace Project___Snake
{
    internal class GameController
    {
        Snake snake;
        public ConsoleKey up { get; private set; }
        public ConsoleKey left { get; private set; }
        public ConsoleKey down { get; private set; }
        public ConsoleKey right { get; private set; }

              

        
        public GameController(Snake snake, ConsoleKey Up, ConsoleKey Left, ConsoleKey Down, ConsoleKey Right)
        {
            this.snake = snake;
            up = Up; left = Left; down = Down; right = Right;
        }

        public void HandleInput(ConsoleKey key)
        {
            // Omvandla tangenttrycket till en ConsoleKey
            ConsoleKey keyPressed = key;

            if (keyPressed == up)
                snake.ChangeDirection(Snake.Direction.Up);
            else if (keyPressed == down)
                snake.ChangeDirection(Snake.Direction.Down);
            else if (keyPressed == left)
                snake.ChangeDirection(Snake.Direction.Left);
            else if (keyPressed == right)
                snake.ChangeDirection(Snake.Direction.Right);
            else
            {
                // Ignorera andra tangenttryckningar
            }
        }
    }
}



