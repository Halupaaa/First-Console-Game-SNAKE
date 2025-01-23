using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    class Game
    {
        Snake snake;

        Apple apple;
        Flower flower;
        Worm worm;
        Fly fly;

        Area area;

        public Game()
        {
            apple = new Apple();
            flower = new Flower();
            worm = new Worm();
            fly = new Fly();
            area = new Area();
            snake = new Snake(15, 7);
            snake.AddSegment();
            snake.SetArea(area);
            area.SetApple(apple);
            area.SetFlower(flower);
            area.SetWorm(worm);
            area.SetFly(fly);

            apple.SetSnake(snake);
            apple.GenerateFood();

            flower.SetSnake(snake);
            flower.GenerateFood();

            worm.SetSnake(snake);
            worm.GenerateFood();

            fly.SetSnake(snake);
            fly.GenerateFood();
        }

        public void Start()
        {
            area.DrawIntro();
            ConsoleKeyInfo keyInfoStart = Console.ReadKey(true);
            if (keyInfoStart.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                ConsoleKey currentDir = ConsoleKey.RightArrow;
                int score = snake.score;

                area.DrawFrame();
                while (!snake.Death() && snake.IsAlive)
                {
                    if (Console.KeyAvailable) currentDir = Console.ReadKey(true).Key;

                    snake.Move(currentDir);

                    score = snake.score;
                    apple.DetectFoodEaten();
                    flower.DetectFoodEaten();
                    worm.DetectFoodEaten();
                    fly.DetectFoodEaten();

                    area.Draw(snake);

                    Thread.Sleep(snake.speed);
                    
                }
                
                Console.Clear();
                area.DrawGameOverScreen(score);

            }
            
        }
    }
}
