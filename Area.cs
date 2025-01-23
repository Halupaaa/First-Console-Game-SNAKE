using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;


namespace First_Console_Game_SNAKE
{
     class Area
     {
        public static int XSizeOfArea = 70;
        public static int YSizeOfArea = 20;

        private (int X, int Y) Welcome = (25, 9);
        private (int X, int Y) PressEnter = (22, 10);

        private (int X, int Y) GameOver = (28, 9);
        private (int X, int Y) TotalScore = (23, 10);
        private (int X, int Y) EndOrRestart = (15, 11);

        private Snake _snake;
        private Apple _apple;
        private Flower _flower;
        private Worm _worm;
        private Fly _fly;

        public void SetApple(Apple apple)
        {
            _apple = apple;
        }
        public void SetFlower(Flower flower)
        {
            _flower = flower;
        }
        public void SetWorm(Worm worm)
        {
            _worm = worm;
        }
        public void SetFly(Fly fly)
        {
            _fly = fly;
        }
        public void SetSnake(Snake snake)
        {
            _snake = snake;
        }

        public void DrawFrame()
        {

            for (int x = 0; x < XSizeOfArea; x++)
            {
                Console.SetCursorPosition(x, 0);
                AnsiConsole.MarkupLine("[#434343]#[/]");
                Console.SetCursorPosition(x, YSizeOfArea - 1);
                AnsiConsole.MarkupLine("[#434343]#[/]");
            }
            for (int y = 0; y < YSizeOfArea; y++)
            {
                Console.SetCursorPosition(0, y);
                AnsiConsole.MarkupLine("[#434343]#[/]");
                Console.SetCursorPosition(XSizeOfArea - 1, y);
                AnsiConsole.MarkupLine("[#434343]#[/]");
            }
        }
        private static void ClearRegion()
        {
            for (int y = 1; y < 1 + 18; y++)
            {
                Console.SetCursorPosition(1, y);
                Console.Write(new string(' ', 68));
            }
            Console.SetCursorPosition(0, 0); 
        }

        public void Draw(Snake snake)
        {
            
            ClearRegion();

            Console.SetCursorPosition(_apple.X, _apple.Y);
            AnsiConsole.MarkupLine("[red]@[/]");
 
            Console.SetCursorPosition(_flower.X, _flower.Y);
            AnsiConsole.MarkupLine("[#fc0]*[/]");

            Console.SetCursorPosition(_worm.X, _worm.Y);
            AnsiConsole.MarkupLine("[#dc506c]~[/]");

            Console.SetCursorPosition(_fly.X, _fly.Y);
            AnsiConsole.MarkupLine("[#afeeee]%[/]");


            for (int i = 0; i < snake.segments.Count; i++)
            {
                Console.SetCursorPosition(snake.segments[i].X, snake.segments[i].Y);
                if (i == 0) AnsiConsole.MarkupLine("[#7fff00]0[/]");
                else AnsiConsole.MarkupLine("[#7fff00]o[/]"); 
            }

            Console.SetCursorPosition(0, YSizeOfArea);
            Console.Write($"Score: {snake.score}");
        }
        

        public void DrawIntro()
        {
            DrawFrame(); 

            Console.SetCursorPosition(Welcome.X, Welcome.Y);
            AnsiConsole.MarkupLine("[bold]WELCOME TO SNAKE GAME![/]");

            Console.SetCursorPosition(PressEnter.X, PressEnter.Y);
            AnsiConsole.MarkupLine("[blink]Press ENTER to start the game[/]");
        }

        public void DrawGameOverScreen(int score)
        {
            DrawFrame();

            Console.SetCursorPosition(GameOver.X, GameOver.Y);
            AnsiConsole.MarkupLine("[bold]GAME OVER[/]");

            Console.SetCursorPosition(TotalScore.X, TotalScore.Y);
            AnsiConsole.MarkupLine($"[#94a0ac]Your total score is [/] {score}");

            Console.SetCursorPosition(EndOrRestart.X, EndOrRestart.Y);
            AnsiConsole.MarkupLine("[blink]Press ENTER to restart and ESC to exit[/]");

        }
    }


}
    

