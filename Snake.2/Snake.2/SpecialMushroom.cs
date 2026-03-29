using Project___Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake._2
{
    internal class SpecialMushroom : Food
    { //***********************************
        //Utökning för mig
        //***********************************
        //Special frukten som gör att det blir slumpval på kontroll för en spelare 
        public SpecialMushroom(List<Food> fruits) : base(fruits)
        {

            //Egenskaper för frukten
            Color = Color.Black;
            ChangeSnakeLength=5;
        }

    }
}
