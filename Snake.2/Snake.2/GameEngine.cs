using Snake._2;
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

        //Hur många spelare som väljs olika inställningar 
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

            //***********************************
            //Utökning för mig, för kunna spela tre seplare
            //***********************************
            // Tredje seplare orm är lila och kontrollen är T,F,G,H
            else if (playerCount == 3)
            {
                Snake snake4 = new Snake(200, 300, Color.Red, snakes);
                Snake snake5 = new Snake(300, 300, Color.Blue, snakes);
                Snake snake6 = new Snake(400, 300, Color.Purple, snakes);

                snakes.Add(snake4);
                snakes.Add(snake5);
                snakes.Add(snake6);

                GameController gameController4 = new GameController(snake4, ConsoleKey.W, ConsoleKey.A, ConsoleKey.S, ConsoleKey.D);
                GameController gameController5 = new GameController(snake5, ConsoleKey.I, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L);
                GameController gameController6 = new GameController(snake6, ConsoleKey.T, ConsoleKey.F, ConsoleKey.G, ConsoleKey.H);

                gameControllers.Add(gameController4);
                gameControllers.Add(gameController5);
                gameControllers.Add(gameController6);

                aliveCount = true;


            }


        }

        //För varje tick i spelet
        public bool Tick()
        {

            List<Snake> snakesCopy = new List<Snake>(snakes);
            List<Food> foodListCopy = new List<Food>(foodList);

            //Skapa ev en frukt
            RandomizeFood();

            //För varje orm
            foreach (Snake snake in snakesCopy)
            {
                snake.Move();
                snake.IsCollidingWithSelf();
                snake.CollidingWithOtherSnake(snakes);

                //***********************************
                //Utökning för mig
                //***********************************
                //Kollar om någon orm har ätit specialfrukt, om ja ta bort ett värde. 250-1 och intervall är 40 blir det 10 sek
                if (snake.SpecialMushroomTimer >= 0)
                {
                    snake.SpecialMushroomTimer -= 1;
                }

            }

            //för varje mat på spelet
            foreach (Food food in foodListCopy)
            {

                food.Eaten(snakes);

            }

            //Koll om alla ormar är i livet, om spelet skall fortsätta köras
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

        //HUr ofta de skall komma ut en ny mat på spel planen
        private void RandomizeFood()
        {

            int makeFood = new Random().Next(1, 45);

            if (makeFood==1)
            {
                MakeNewFood();
            }

        }

        //Gör ny mat
        private void MakeNewFood()
        {
            //Slumpar fram vilken mat de skall bli
            int randomFood = new Random().Next(1, 11);


            Food newFood;

            if (randomFood == 1)
            {
                newFood = new SpecialMushroom(foodList);
            }
            else if (randomFood <= 6)
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

        //Noll ställer spelet 
        public void RestGame()
        {
            foodList.Clear();
            snakes.Clear();
            gameControllers.Clear();
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
