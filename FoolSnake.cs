using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    public class FoolSnake
    {
        private Snake snake;
        private Food food;

        public void getSnake(Snake snake)
        {
            this.snake = snake;
        }
        public void getFood(Food food)
        {
            this.food = food;
        }

        private List<(int X, int Y)> segmentesOfSnake = new List<(int X, int Y)>();

        public void AddSegment(Snake snake)
        {
            segmentesOfSnake.Add((snake.X, snake.Y));
        }
        public List<(int X, int Y)> GetSegments()
        {
            return segmentesOfSnake;
        }


    }
}
