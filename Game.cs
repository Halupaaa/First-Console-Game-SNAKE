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
        FoolSnake foolSnake;

        public Game()
        {
            food = new Food();
            area = new Area();
            snake = new Snake(10, 10);
            foolSnake = new FoolSnake();
            snake.getArea(area);
            snake.getFood(food);
            snake.getFoolSnake(foolSnake);
            area.getFood(food);
            food.getArea(area);
            food.getSnake(snake);
            food.generateFood();
            foolSnake.getSnake(snake);
            foolSnake.getFood(food);
            area.getFoolSnake(foolSnake);

            food.FoodEaten += OnFoodEaten;
        }
        private void OnFoodEaten()
        {                              
            foolSnake.AddSegment(snake);
        }
        public void Start ()
        {
            while (true)
            {
                Console.Clear();
                area.Draw(snake, foolSnake);
                snake.Move(snake.X, snake.Y);
                food.checkIfEaten(food);

            }
        }
    }
}
