﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    public class Snake
    {
        public int X {  get; private set; }
        public int Y { get; private set; }

        private Area area;
        private Food food;
        public Snake(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void getArea(Area area)
        {
            this.area = area;
        }

        public void getFood (Food food)
        {
            this.food = food;
        }

        private FoolSnake foolSnake;

        public void getFoolSnake(FoolSnake foolSnake)
        {
            this.foolSnake = foolSnake;
        }

        public void Move (int x, int y)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Y == 0) Y = area.YSizeOfArea - 1;
                    else Y = (Y - 1) % area.YSizeOfArea;
                    
                    break;
                case ConsoleKey.DownArrow:
                    Y = (Y + 1) % area.YSizeOfArea;
                    break;
                case ConsoleKey.RightArrow:
                    X = (X + 1) % area.XSizeOfArea;
                    break;
                case ConsoleKey.LeftArrow:
                    if (X == 0) X = area.XSizeOfArea - 1;
                    else X = (X - 1) % area.XSizeOfArea;
                    break;
            }

            for (int i = foolSnake.GetSegments().Count - 1; i > 0; i--)
            {
                foolSnake.GetSegments()[0] = (X, Y);
                foolSnake.GetSegments()[i] = foolSnake.GetSegments()[i - 1];
            }
        }
    }
}
