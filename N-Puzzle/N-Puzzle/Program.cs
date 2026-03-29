// See https://aka.ms/new-console-template for more information
/*using N_Puzzle;



Console.Write("Enter a number to make a square puzzel game:");
int size = Convert.ToInt16(Console.ReadLine());
int bordsize = size*size;


Console.WriteLine("Game bord");
Console.WriteLine("Move the brick with arrow key");


Skapa array för kolla som man kan jämföra om spelet är slut eller ej
int[] finishbord = new int[bordsize];
for (int i = 0; i < bordsize; i++)
{
    finishbord[i] = i; 
}



int [,] puzzelgamebord = new Bord(size);

do
{
    ConsoleKeyInfo tangentInfo = Console.ReadKey(true);
    Gamecontrol mygamecontrol = new Gamecontrol(puzzelgamebord);

    switch (tangentInfo.Key)
    {
        case ConsoleKey.UpArrow:
            Gamecontrol.
            matrisHanterare.FlyttaMarkering(-1, 0);
            break;
        case ConsoleKey.DownArrow:
            matrisHanterare.FlyttaMarkering(1, 0);
            break;
        case ConsoleKey.LeftArrow:
            matrisHanterare.FlyttaMarkering(0, -1);
            break;
        case ConsoleKey.RightArrow:
            BytPlatsOmMarkerad(matrisHanterare);
            break;
        case ConsoleKey.Escape:
            return;
    }
} while (true);

puzzelgamebord.Printgamebord();
*/

using N_Puzzle;

Console.WriteLine("N-Puzzle-game!");

// Fråga användaren efter storleken på spelbordet
Console.Write("How big will the game bord be? (t.ex. 3 for 3x3): ");

int count = 0;
int bordSize = Convert.ToInt16(Console.ReadLine());


// Skapa ett GameBoard med storlek bordSize och en referens spelplan
GameBoard gameBordForPuzzel = new GameBoard(bordSize);
GameBoard bordToCompare = new GameBoard(bordSize);


// Rensa Consol skärmen 
Console.Clear();

//Blanda spel planen 
gameBordForPuzzel.Shufflebord();

// Visa spel information och spel planen
Gameinfo();

// Låt användaren  flytta brickan med värdet "0" dvs hel svarta brickan
while (IsGameComplete(bordToCompare, gameBordForPuzzel))
{
    char input = Console.ReadKey().KeyChar;

    // Avsluta loopen om användaren trycker på 'q'
    if (input == 'q')
    { break; }

    //räkna antal drag i spelet
    count++;
    // Flytta brickan baserat på användarens input
    gameBordForPuzzel.MoveZeroTile(input);

    // Rensa konsolfönstret för att visa det nya brädet
    Console.Clear();

    Gameinfo();


}

//Splet spel, rensa spel planen och visa antal moves som har gjorts
Console.Clear();
Console.WriteLine("End of the game");
Console.WriteLine($"Total of move: {count}");
Console.WriteLine("Pres enter key to exit");
Console.ReadLine(); // Håll konsolfönstret öppet

//Vissa spel information
void Gameinfo()
{
    bordToCompare.DisplayBoard();
    Console.WriteLine("\nMove the black brick so lover bord match with upper bord");
    Console.WriteLine("Move the black brick with (w/a/s/d) or use 'q' to quit the game:\n");
    gameBordForPuzzel.DisplayBoard();

}
//Funktion För kolla om spelet är slut eller inte
bool IsGameComplete(GameBoard currentBoard, GameBoard targetBoard)
{
    // Loopa igenom varje position i brädet och jämför spelborden
    for (int row = 0; row < bordSize; row++)
    {
        for (int col = 0; col < bordSize; col++)
        {
            if (currentBoard.GetTileNumber(row, col) != targetBoard.GetTileNumber(row, col))
            {
                // Om någon bricka har ett annat nummer, returnera true
                return true;
            }
        }
    }

    // Om alla brickor har samma nummer och placering, returnera true
    return false;
}