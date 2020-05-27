using System;
using System.Collections.Generic;
using System.Threading;

namespace PacmanGame
{
    class Program
    {
        public static bool gameOver = false;
        public static int score = 0;
        static int speed = 250;
        public enum direction { left, up, right, down }

        static Thread background = new Thread(BackgroundGame);
        public static Map map = new Map();
        public static Pacman pacman;
        public static List<StupidGhost> stupidGhosts = new List<StupidGhost>();
        public static List<SmartGhost> smartGhosts = new List<SmartGhost>();

        static void Main(string[] args)
        {
            //Introductory picture
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(12, 15);
            Console.WriteLine("PACMAN");
            Thread.Sleep(1500);

            map.RenderMap();
            map.RenderJewels();

            Program.pacman = new Pacman(13, 23);

            Program.stupidGhosts.Add(new StupidGhost(13, 11, Object.direction.left));

            Program.smartGhosts.Add(new SmartGhost(15, 11, Object.direction.right));

            background.Start();
            background.IsBackground = true;
        
            pacman.Control(background);

            Console.Clear();

            //Game over

            //You lose
            if (score < 2430)
            {
                Console.SetCursorPosition(12, 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Game Over");
                Console.SetCursorPosition(12, 8);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your score: {0}", score);
                Thread.Sleep(500);
                Console.SetCursorPosition(12, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            //You win
            else
            {
                Console.SetCursorPosition(12, 6);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("You win!");
                Console.SetCursorPosition(12, 8);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your score: {0}", score);
                Thread.Sleep(500);
                Console.SetCursorPosition(12, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        //Game process
        public static void BackgroundGame()
        {
            while (!Program.gameOver)
            {
                if (score == 2430) gameOver = true;

                //Pacman actions
                pacman.Step();

                //SmartGhost actions
                foreach (SmartGhost ghost in Program.smartGhosts) ghost.Step();

                //After 30 jewels start StupidGhost actions
                if (Program.score > 300)
                {
                    foreach (StupidGhost ghost in Program.stupidGhosts) ghost.Step();
                }

                //Show score
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(31, 1);
                Console.Write("Score: {0}", score);

                Thread.Sleep(speed);
            }
        }
    }
}
