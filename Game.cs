using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    public class Game
    {
        Snake snake;
        Food food;
        Area area;

        public Game()
        {
            food = new Food();
            area = new Area();
            snake = new Snake(15, 7);
            snake.getArea(area);
            snake.getFood(food);
            area.getFood(food);
            food.getArea(area);
            food.getSnake(snake);
            food.generateFood();
        }

        public void Start ()
        {
            while (!snake.Death())
            {
                Console.Clear();
                area.Draw(snake);
                snake.Move();
                food.DetectFoodEaten(food);
            }
            if (snake.Death())
            {
                Console.Clear();
                area.DrawGameOverScreen();
            }
        }
    }
}
