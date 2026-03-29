using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    public class RectangleBlue : Rectangle
    {

        public RectangleBlue(int xposition, int yposition, int width, int height) : base(xposition, yposition, width, height)
        {
            //Vilken hastighet som bollar skall ha
            //Sakta ner bolen
            speedFactor = 0.98f;

            //Färg på rektangeln
            Color = Color.Blue;
        }

             
      
    }

}
