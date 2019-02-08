using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class BorderField
    {
        private List<Pixel> _borderPixels;

        public BorderField()
        {
            _borderPixels = new List<Pixel>();
            FormBorder();

            void FormBorder()
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Pixel px = new Pixel(i, 0, ConsoleColor.DarkRed);
                    _borderPixels.Add(px);
                    px = new Pixel(i, Console.WindowHeight - 1, ConsoleColor.DarkRed);
                    _borderPixels.Add(px);
                }
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    Pixel px = new Pixel(0, i, ConsoleColor.DarkRed);
                    _borderPixels.Add(px);
                    px = new Pixel(Console.WindowWidth - 1, i, ConsoleColor.DarkRed);
                    _borderPixels.Add(px);
                }
            }
        }

        public void DrawBorder()
        {
            foreach (Pixel item in _borderPixels)
            {
                item.DrawPixel();
            }
        }

        public bool IsCollapsed(Pixel pixel)
        {
            return _borderPixels.Any((x) => x.PixelPosX == pixel.PixelPosX && x.PixelPosY == pixel.PixelPosY);
        }
    }
}
