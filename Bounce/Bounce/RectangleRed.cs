using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    public class RectangleRed : Rectangle
    {

        public RectangleRed(int xposition, int yposition, int width, int height) : base(xposition, yposition, width, height)
        {
            //Vilken hastighet som bollar skall ha
            //Ökar hastigheten på bollen 
            speedFactor = 1.1f;

            //Färg på rektangeln
            Color = Color.Red;
        }
    }
       
}

