using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGame
{
    public class Snake
    {
        private Pixel _snakeHead;
        public Pixel SnakeHead
        {
            get => _snakeHead;
        }
        private Direction _currentDirection = Direction.Right;
        public Direction CurrentDirection
        {
            get => _currentDirection;
            set
            {
                if (_currentDirection == Direction.Down && value != Direction.Up)
                    _currentDirection = value;
                if (_currentDirection == Direction.Up && value != Direction.Down)
                    _currentDirection = value;
                if (_currentDirection == Direction.Left && value != Direction.Right)
                    _currentDirection = value;
                if (_currentDirection == Direction.Right && value != Direction.Left)
                    _currentDirection = value;
            }

        }

        private List<Pixel> _snakeBody;

        public Snake()
        {
            var beginPosX = Console.WindowWidth / 2;
            var beginPosY = Console.WindowHeight / 2;
            _snakeHead = new Pixel(beginPosX, beginPosY, ConsoleColor.DarkGreen);
            _snakeBody = new List<Pixel>(100);
            _snakeBody.Add(_snakeHead);
            for (int i = 0; i < 12; i++)
            {
                _snakeBody.Add(new Pixel(--beginPosX, beginPosY, ConsoleColor.DarkBlue));
            }
        }

        public void Eat(Cherry cherry)
        {
            Pixel pixel = new Pixel(cherry.CherryPos().PixelPosX, cherry.CherryPos().PixelPosY, ConsoleColor.DarkBlue);
            _snakeBody.Add(pixel);
        }

        public void DrawSnake()
        {
            foreach (Pixel item in _snakeBody)
            {
                item.DrawPixel();
            }
        }

        public bool IsCollapsed()
        {
            return _snakeBody.Any(x => (x.PixelPosY == _snakeHead.PixelPosY && x.PixelPosX == _snakeHead.PixelPosX) &&
                                       _snakeHead != x);
        }

        public void SnakeMove()
        {
            int tempX = _snakeHead.PixelPosX,
                tempY = _snakeHead.PixelPosY;

            if (CurrentDirection == Direction.Down)
                _snakeHead.PixelPosY++;
            else if (CurrentDirection == Direction.Up)
                _snakeHead.PixelPosY--;
            else if (CurrentDirection == Direction.Left)
                _snakeHead.PixelPosX--;
            else if (CurrentDirection == Direction.Right)
                _snakeHead.PixelPosX++;

            foreach (Pixel item in _snakeBody)
            {
                if (item != _snakeHead)
                {
                    var x = item.PixelPosX;
                    var y = item.PixelPosY;

                    item.PixelPosX = tempX;
                    item.PixelPosY = tempY;

                    tempX = x;
                    tempY = y;
                }
            }
        }
    }
}
