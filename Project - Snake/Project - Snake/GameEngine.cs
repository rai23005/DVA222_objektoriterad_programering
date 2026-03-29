using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project___Snake
{
    internal class GameEngine
    {

        List<Snake> snakes = new List<Snake>();
        List<Food> foodList = new List<Food>();
        List<GameController> gameControllers = new List<GameController>();
        
        bool aliveCount;


        public GameEngine()
        {

        }

        public void Run(int playerCount)
        {
            if (playerCount == 1)
            {
                
                Snake snake1 = new Snake(400, 300, Color.Red, snakes);
                snakes.Add(snake1);
                GameController gameController1 = new GameController(snake1, ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D);
                gameControllers.Add(gameController1);
                aliveCount = true;
            }
            else if (playerCount == 2)
            {
                
                Snake snake2 = new Snake(200, 300, Color.Red, snakes);
                Snake snake3 = new Snake(400, 300, Color.Blue, snakes);

                snakes.Add(snake2);
                snakes.Add(snake3);

                GameController gameController2 = new GameController(snake2, ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D);
                GameController gameController3 = new GameController(snake3, ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L);

                gameControllers.Add(gameController2);
                gameControllers.Add(gameController3);

                aliveCount = true;
            }


        }

        public bool Tick()
        {

            List<Snake> snakesCopy = new List<Snake>(snakes);
            List<Food> foodListCopy = new List<Food>(foodList);


            RandomizeFood();

            foreach (Snake snake in snakesCopy)
            {
                snake.Move();
                snake.IsCollidingWithSelf();
                snake.CollidingWithOtherSnake(snakes);
            }

            foreach (Food food in foodListCopy)
            {
               
                food.Eaten(snakes);
                               
            }
            CheckAllSnakesIsAlive();
            if (aliveCount==false)
            {
                return false;
            }

            return true;

        }

        //Kontroll om alla ormar är vid liv
        private void CheckAllSnakesIsAlive()
        {
            if (snakes.Count == 0)
            {
                aliveCount = false;
            }

        }

        private void RandomizeFood()
        {
            int makeFood = new Random().Next(1, 45);

            if (makeFood==1)
            {
                MakeNewFood();
            }

        }
        private void MakeNewFood() 
        {
            // Skapa en slumpmässig siffra mellan 1 och 10
            int randomFood = new Random().Next(1, 11);


            Food newFood;

            if (randomFood <= 6)
            {
                newFood = new StandardFood(foodList);
            }
            else if (randomFood <= 8)
            {
                newFood = new DietFood(foodList);
            }
            else
            {
                newFood = new ValuableFood(foodList);
            }

            foodList.Add(newFood);


        }

        public void RevmoveFoodList()
        {
            foodList.Clear();
            
        }

        public List<Snake> ReturnSnakes()
        {
            return snakes;
        }

        public List<Food> ReturnFood()
        {
            return foodList;
        }

        public List<GameController> ReturnGameController()
        {
            return gameControllers;
        }

    }
}
