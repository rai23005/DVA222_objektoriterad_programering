namespace Project___Snake
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            var Game = new GameEngine();
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(Game));
        }
    }
}