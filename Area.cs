using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    public class Area
    {
        public int XSizeOfArea = 30;
        public int YSizeOfArea = 15;

        private Food food;
        private Snake snake;
        public void getFood (Food food)
        {
            this.food = food;
        }
        public void getSnake(Snake snake)
        {
            this.snake = snake;
        }
        public void Draw(Snake snake)
        {
            for (int y = 0; y < YSizeOfArea; y++)
            {
                for (int x = 0; x < XSizeOfArea; x++)
                {
                    if (x == 0 || x == XSizeOfArea - 1 || y == 0 || y == YSizeOfArea - 1)
                    {
                        Console.Write("#");
                    }
                    else if (x == snake.X && y == snake.Y)
                    {
                        Console.Write("O");
                    }
                    else if (snake.GetSegments().Any(segment => segment.X == x && segment.Y == y))
                    {
                        Console.Write("o"); 
                    }
                    else if (x == food.FoodX && y == food.FoodY)
                    {
                        Console.Write("@");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("Score: " + food.score);
        }

        public const int XGameOver = 10;
        public const int YGameOver = 6;
        public const int XTotalScore = 5;
        public const int YTotalScore = 7;

        public void DrawGameOverScreen()
        {
            for (int y = 0; y < YSizeOfArea; y++)
            {
                for (int x = 0; x < XSizeOfArea; x++)
                {
                    if (x == 0 || x == XSizeOfArea - 1 || y == 0 || y == YSizeOfArea - 1)
                    {
                        Console.Write("X");
                    }
                    else if (x == XGameOver && y == YGameOver)
                    {
                        Console.Write("Game Over");
                        x += "Game Over".Length - 1;
                    }
                    else if (x == XTotalScore && y == YTotalScore)
                    {
                        Console.Write("Your total score is " + food.score);
                        x += "Your total score is ".Length + Convert.ToString(food.score).Length - 1;
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
    
}
