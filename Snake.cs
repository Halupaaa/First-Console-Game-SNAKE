using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Console_Game_SNAKE
{
    class Snake
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public List<(int X, int Y)> segments = new ();
        public bool IsAlive = true;
        public int speed = 150;
        public int score = -1; 

        private Area _area;

        public Snake(int x, int y)
        {
            X = x;
            Y = y;
            segments.Add((x, y));
        }
        public void SetArea(Area area)
        {
            _area = area;
        }

        public void AddSegment()
        {
            segments.Add(segments.Last());
            score++;
        }

        public void PositionOfHead(ConsoleKey? key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Y--;
                    break;
                case ConsoleKey.DownArrow:
                    Y++;
                    break;
                case ConsoleKey.RightArrow:
                    X++;
                    break;
                case ConsoleKey.LeftArrow:
                    X--;
                    break;
            }
            segments[0] = (X, Y);
        }

        public void Move(ConsoleKey? key)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i] = segments[i - 1];
            }
            PositionOfHead(key);
        }

        public bool Death()
        {
            (int X, int Y) head = segments.First();

            for (int i = 2; i < segments.Count; i++)
            {
                if (head.X == segments[i].X && head.Y == segments[i].Y)
                {
                    IsAlive = false; 
                    return true;
                }
            }

            if (head.X == 1 || head.X == Area.XSizeOfArea - 2 || head.Y == 1 || head.Y == Area.YSizeOfArea - 2)
            {
                IsAlive = false; 
                return true;
            }

            return false;
        }

    }
}
