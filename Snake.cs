using SkiaSharp;
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

        private List<(int X, int Y)> segments = new List<(int X, int Y)>();

        private Area area;
        private Food food;

        public Snake(int x, int y)
        {
            X = x;
            Y = y;
            segments.Add((x, y));
        }
        public void getArea(Area area)
        {
            this.area = area;
        }

        public void getFood (Food food)
        {
            this.food = food;
        }
        public void PositionOfHead()
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
            segments[0] = (X, Y);
        }
        public void AddSegment()
        {
            segments.Add(segments.Last());
        }

        public List<(int X, int Y)> GetSegments()
        {
            return segments;
        }

        public void Move ()
        {
            for (int i = GetSegments().Count - 1; i > 0; i--)
            {
                GetSegments()[i] = GetSegments()[i - 1];
            }
            PositionOfHead();
        }

        public bool Death()
        {
            (int X, int Y) head = GetSegments().First();

            for (int i = 2; i < GetSegments().Count; i++)
            {
                if ((head.X == GetSegments()[i].X) && (head.Y == GetSegments()[i].Y)) return true;  
            }
            return false;

        }
            
    }
}
