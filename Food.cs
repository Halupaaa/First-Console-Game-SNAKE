﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace First_Console_Game_SNAKE
{
    abstract class Food
    {
        public int X {  get; set; }
        public int Y { get; set; }

        private Snake _snake;

        public void SetSnake(Snake snake)
        {
            _snake = snake;
        }

        public void GenerateFood()
        {
            Random random = new Random();
            do
            {
                X = random.Next(1, Area.XSizeOfArea - 1);
                Y = random.Next(1, Area.YSizeOfArea - 1);
            } while (_snake.segments.Any(segment => X == segment.X && Y == segment.Y));

        }

        public virtual void DetectFoodEaten()
        {
            (int X, int Y) head = _snake.segments.First();

            if (head.X == X && head.Y == Y)
            {
                GenerateFood();
                _snake.AddSegment();
            }
        }


    }
}
