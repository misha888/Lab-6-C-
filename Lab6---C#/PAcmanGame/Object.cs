using System;

namespace PacmanGame
{
    //Absract class for game characters
    abstract class Object
    {
        public char currentStatePlace;
        public int x, y; //coordinates
        char objectSymbol;
        public enum direction { left, up, right, down }
        public direction objectDirection = direction.right;
        public direction previousObjectDirection = direction.right;
        public int X
        {
            set
            {
                x = value;
            }
            get
            {
                return x;
            }
        }
        public int Y
        {
            set
            {
                y = value;
            }
            get
            {
                return y;
            }
        }
        public Random randomize = new Random();

        public abstract char GetSymbol();

        public abstract void Step();

        public char GetSymbolByDirection(direction Direction)
        {
            if (Direction == direction.left) return Program.map[x - 1, y];
            if (Direction == direction.right) return Program.map[x + 1, y];
            if (Direction == direction.up) return Program.map[x, y - 1];
            return Program.map[x, y + 1];
        }

        public void KillPacman()
        {
            if (Program.pacman.x == x && Program.pacman.y == y)
            {
                Program.gameOver = true;
            }
        }

        public virtual void ChangePositionByDirection(direction Direction)
        {
            //edge of game area
            if (x > 27) x = 0;
            else if (x < 0) x = 27;

            Program.map.RenderChar(x, y, currentStatePlace);
            if (Direction == direction.left) x--;
            if (Direction == direction.right) x++;
            if (Direction == direction.up) y--;
            if (Direction == direction.down) y++;

            //When ghosts meet
            if (Program.map[x, y] != Map.stupidGhostSymbol && Program.map[x, y] != Map.smartGhostSymbol)
            {
                currentStatePlace = Program.map[x, y];
            }
            //Render game character
            Program.map.RenderChar(x, y, GetSymbol());
        }
    }
}
