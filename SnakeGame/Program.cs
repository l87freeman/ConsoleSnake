using System;


namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame sg = new SnakeGame();
            sg.Play();

            Console.ReadKey();
        }
    }
}
