using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project___Snake
{
    //worth 1 point that decreases the length of the snake by 1
    
    internal class DietFood : Food
    {
        public DietFood(List<Food> fruits) : base(fruits)
        {

            //Egenskaper för frukten
            Color = Color.Pink;
            score=1;
            ChangeSnakeLength=-1;
        }

    }

}
