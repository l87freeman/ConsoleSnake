using System;
using System.Diagnostics;

namespace SnakeGame
{
    public class SnakeGame
    {
        private BorderField _fieldBorder;
        private Snake _snake;
        private Cherry _cherry;
        private int _score = 0;

        public SnakeGame()
        {
            _fieldBorder = new BorderField();
            _snake = new Snake();
            _cherry = new Cherry();
        }

        private Direction UserSelectedDirection(Direction currDirr)
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        return Direction.Up;
                    case ConsoleKey.DownArrow:
                        return Direction.Down;
                    case ConsoleKey.LeftArrow:
                        return Direction.Left;
                    case ConsoleKey.RightArrow:
                        return Direction.Right;
                    default:
                        return currDirr;
                }
            }
            return currDirr;
        }

        public void Play()
        {
            while (true)
            {
                Console.Clear();
                _fieldBorder.DrawBorder();
                _snake.DrawSnake();
                _cherry.DrawCherry();

                Stopwatch stopwatch = Stopwatch.StartNew();
                while (stopwatch.ElapsedMilliseconds <= 300)
                {
                    _snake.CurrentDirection = UserSelectedDirection(_snake.CurrentDirection);
                }
                _snake.SnakeMove();

                if (_snake.IsCollapsed() || _fieldBorder.IsCollapsed(_snake.SnakeHead))
                {
                    DisplayGameOver();
                    break;
                }

                if (_cherry.IsCollapsed(_snake.SnakeHead))
                {
                    _snake.Eat(_cherry);
                    _cherry = new Cherry();
                    _score++;
                }
            }
        }

        private void DisplayGameOver()
        {
            Console.Clear();
            var beginPosX = Console.WindowWidth / 5;
            var beginPosY = Console.WindowHeight / 2;

            Console.SetCursorPosition(beginPosX, beginPosY);
            Console.WriteLine($"Game over, your result is {_score}");
        }
    }
}
