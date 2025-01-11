using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace First_Console_Game_SNAKE
{
    public class Food
    {
        public int FoodX {  get; set; }
        public int FoodY { get; set; }

        private Snake snake;
        private Area area;
        public int score = -1;

        public void getSnake (Snake snake)
        {
            this.snake = snake;
        }
        public void getArea(Area area)
        {
            this.area = area;
        }

        public void generateFood()
        {
            Random random = new Random();
            FoodX = random.Next(1, area.XSizeOfArea - 1);
            FoodY = random.Next(1, area.YSizeOfArea - 1);
            ++score;
        }

        public void DetectFoodEaten(Food food)
        {
            (int X, int Y) head = snake.GetSegments().First();

            if (head.X == FoodX && head.Y == FoodY)
            {
                generateFood();
                snake.AddSegment();
            }
        }
    }
}
