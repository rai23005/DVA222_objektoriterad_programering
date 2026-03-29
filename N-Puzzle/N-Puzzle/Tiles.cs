using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    internal class Tiles
    {
     
        int Number; 
      
        public Tiles(int number)
        {
            Number = number;
        }

       public int GetNumber() {  return Number; }        
        public void ShowTiles()
        {
            // Spelbricka 0 är helt svart
            if (Number == 0)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                
            }
            //Jämna spelbrickor har svart bakrund och vitt färg
            else if (Number % 2 == 0)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                
            }
            // Udda spelbrikor får Vittbakrund och svart text
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                
            }

            // Skriv ut Nummret med två siffror
            Console.Write($" {Number:D3} ");

            // Återställ färginställningarna
            Console.ResetColor();

            
        }
    }
}

