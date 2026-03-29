using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___Snake
{
    //standard food worth 1 point that increases the length of the snake by 1
    internal class StandardFood : Food
    {

        public StandardFood(List<Food> fruits) : base(fruits)
        {

            Color = Color.Yellow;
            score=1;
            ChangeSnakeLength=1;

        }
    }

}
