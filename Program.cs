namespace First_Console_Game_SNAKE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            bool flag = false;
            do
            {
                Console.Clear();
                Game game = new Game();
                game.Start();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (keyInfo.Key == ConsoleKey.Enter)  flag = true; 
            } while (flag);
        }
    }
}

