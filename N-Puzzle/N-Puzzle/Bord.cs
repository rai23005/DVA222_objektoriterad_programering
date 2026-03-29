using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    internal class GameBoard
    {
        Tiles[,] board;
        int size;
        int zeroRow;
        int zeroCol;

        public event EventHandler Event;

        public GameBoard(int size)
        {
            this.size = size;

            // Skapa ett nytt bräde med angiven storlek
            board = new Tiles[size, size];

            // Fyll brädet med Tiles-objekt
            FillGameBoardWithTiles();
        }

        //Fyll spelplanen med spelbrickor
        private void FillGameBoardWithTiles()
        {
            // Fyll brädet med Tiles-objekt baserat på dess position
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Skapa ett Tiles-objekt och använd dess position som nummer
                    int nummer = row * size + col;
                    board[row, col] = new Tiles(nummer);

                    // Håll reda på positionen för brickan med värdet 0
                    if (nummer == 0)
                    {
                        zeroRow = row;
                        zeroCol = col;
                    }
                }
            }
        }
        //Skriva ut spelbordet 
        public void DisplayBoard()
        {
            // Skriv ut spel planen för vare rad och kolum. 
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Anropa ShowTiles i klassen Tiles för skriva ut spel bricka
                    board[row, col].ShowTiles();
                }

                // Gör en ny rad för varje rad på brädet
                Console.WriteLine();
            }
        }

       
        //Få tag på värdet på en spelbricka
        public int GetTileNumber(int row, int col)
        {
            return board[row, col].GetNumber();
           
            
        }

        //Flytta spelbrikan med värde noll
        public void MoveZeroTile(char direction)
        {

            // Flytta brickan baserat på användarens input
            switch (direction)
            {
                case 'w': // Upp
                    MoveTile(zeroRow, zeroCol, zeroRow - 1, zeroCol);
                    break;
                case 'a': // Vänster
                    MoveTile(zeroRow, zeroCol, zeroRow, zeroCol - 1);
                    break;
                case 's': // Ner
                    MoveTile(zeroRow, zeroCol, zeroRow + 1, zeroCol);
                    break;
                case 'd': // Höger
                    MoveTile(zeroRow, zeroCol, zeroRow, zeroCol + 1);
                    break;
            }
        }
             
        //Blanda spelbordet
      

        //Flytta en spel bricka
        private void MoveTile(int fromRow, int fromCol, int toRow, int toCol)
        {
            // Kontroll att det är inom spel planen man vill flytta 
            
                if(toRow >= 0 && toRow < size && toCol >= 0 && toCol < size)
                { 
                    // Byt plats på brickorna
                Tiles temp = board[fromRow, fromCol];
                board[fromRow, fromCol] = board[toRow, toCol];
                board[toRow, toCol] = temp;

                // Uppdatera positionen för brickan med värdet 0
                zeroRow = toRow;
                zeroCol = toCol;
                }
            
        }

        public void Shufflebord() // Blanda spel planen med mellan size till size*size drag
        {
            Random random = new Random();
            int randomNumber = random.Next(size, size*size);

            for (int i = 0; i < randomNumber; i++)
            {
                //Flytta "0" x antal gånger
                int randomMove = random.Next(0, 4);

                if (randomMove == 0)
                { MoveZeroTile('w'); }
                if (randomMove == 1)
                { MoveZeroTile('a'); }
                if (randomMove == 2)
                { MoveZeroTile('s'); }
                if (randomMove == 3)
                { MoveZeroTile('d'); }

            }
        }
    }



}

