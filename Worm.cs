using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    class Worm : Food
    {
        //Unic Property eaten? snake slower

        private Snake snake;
        public void SetSnake(Snake snake)
        {
            this.snake = snake;
        }

        public void GenerateFood()
        {
            Random random = new Random();
            do
            {
                X = random.Next(1, Area.XSizeOfArea - 1);
                Y = random.Next(1, Area.YSizeOfArea - 1);
            } while (snake.segments.Any(segment => X == segment.X && Y == segment.Y));
        }

        public override void DetectFoodEaten()
        {
            (int X, int Y) head = snake.segments.First();

            if (head.X == X && head.Y == Y)
            {
                snake.speed += 50;
                GenerateFood();
                snake.AddSegment();
            }
        }
    }
}
