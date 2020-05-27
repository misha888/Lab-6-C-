using System;
using System.Threading;

namespace PacmanGame
{
    class Pacman : Object
    {
        //Pacman constructor
        public Pacman(int x, int y)
        {
            this.X = x;
            this.Y = y;
            currentStatePlace = Program.map.EmptySpace;
            objectDirection = direction.left;
            Program.map.RenderChar(x, y, GetSymbol());
        }

        //Processing keystrokes
        static ConsoleKeyInfo KeyInfo = new ConsoleKeyInfo();

        public void Control(Thread background)
        {
            while (background.IsAlive)
            {
                KeyInfo = Console.ReadKey(true);

                if (KeyInfo.Key == ConsoleKey.LeftArrow)
                {
                    objectDirection = direction.left;
                }
                else if (KeyInfo.Key == ConsoleKey.RightArrow)
                {
                    objectDirection = direction.right;
                }
                else if (KeyInfo.Key == ConsoleKey.UpArrow)
                {
                    objectDirection = direction.up;
                }
                else if (KeyInfo.Key == ConsoleKey.DownArrow)
                {
                    objectDirection = direction.down;
                }
            }
        }

        //Pacman symbol
        public override char GetSymbol()
        {
            return '@';
        }

        //Moving pacman
        public override void ChangePositionByDirection(direction Direction)
        {
            if (x > 27) x = 0;
            else if (x < 0) x = 27;
            Program.map.RenderChar(x, y, currentStatePlace);
            if (Direction == direction.left) x--;
            if (Direction == direction.right) x++;
            if (Direction == direction.up) y--;
            if (Direction == direction.down) y++;
            CalcScore();
            Program.map.RenderChar(x, y, GetSymbol());
        }

        //Score for jewels
        public void CalcScore()
        {
            if (Program.map[x, y] == Map.jewel)
            {
                Program.score += 10;
            }
        }

        //Next Step
        public override void Step()
        {
            Char newPosition = GetSymbolByDirection(objectDirection);

            if (newPosition != Map.wall)
            {
                ChangePositionByDirection(objectDirection);
                previousObjectDirection = objectDirection;
            }
            else
            {
                newPosition = GetSymbolByDirection(previousObjectDirection);
                if (newPosition != Map.wall)
                {
                    ChangePositionByDirection(previousObjectDirection);
                }
            }

        }
    }
}
