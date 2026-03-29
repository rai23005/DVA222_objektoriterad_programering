using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___Snake
{
    //valuable food worth 5 points that increases the length of the snake by 2
    internal class ValuableFood : Food
    {

        public ValuableFood(List<Food> fruits) : base(fruits)
        {

            Color = Color.DarkGreen;
            score=5;
            ChangeSnakeLength=2;


        }


    }

}
