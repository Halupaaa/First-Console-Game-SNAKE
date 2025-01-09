using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    public class Area
    {
        public int XSizeOfArea = 40;
        public int YSizeOfArea = 20;

        private Food food;
        private FoolSnake foolSnake;
        public void getFood (Food food)
        {
            this.food = food;
        }
        public void getFoolSnake(FoolSnake foolSnake)
        {
            this.foolSnake = foolSnake;
        }

        public void Draw(Snake snake, FoolSnake foolSnake)
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
                    else if (foolSnake.GetSegments().Any(segment => segment.X == x && segment.Y == y))
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


    }
}
