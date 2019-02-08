using System;

namespace SnakeGame
{
    public class Pixel
    {
        public ConsoleColor PixelColor { get; set; }
        public int PixelPosX { get; set; }
        public int PixelPosY { get; set; }
        public string _pixelSymb = "■";

        public Pixel(int x, int y, ConsoleColor color)
        {
            PixelColor = color;
            PixelPosX = x;
            PixelPosY = y;
        }

        public void DrawPixel()
        {
            var beckup = Console.ForegroundColor;
            Console.ForegroundColor = PixelColor;
            Console.SetCursorPosition(PixelPosX, PixelPosY);
            Console.Write(_pixelSymb);
            Console.ForegroundColor = beckup;
        }
    }
}
