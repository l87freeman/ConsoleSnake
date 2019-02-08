using System;

namespace SnakeGame
{
    public class Cherry
    {
        private Pixel _cherry;
        public Cherry()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int x = rnd.Next(1, Console.WindowWidth - 1);
            int y = rnd.Next(1, Console.WindowHeight - 1);
            _cherry = new Pixel(x, y, ConsoleColor.DarkYellow);
        }

        public Pixel CherryPos()
        {
            return _cherry;
        }

        public void DrawCherry()
        {
            _cherry.DrawPixel();
        }

        public bool IsCollapsed(Pixel pixel)
        {
            return pixel.PixelPosY == _cherry.PixelPosY && _cherry.PixelPosX == pixel.PixelPosX;
        }
    }
}
