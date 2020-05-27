using System;
using System.Collections.Generic;

namespace PacmanGame
{
    class StupidGhost : Object
    {
        //Ghost constructor
        public StupidGhost(int x, int y, direction Direction)
        {
            this.X = x;
            this.Y = y;
            currentStatePlace = Program.map.EmptySpace;
            objectDirection = Direction;
            Program.map.RenderChar(x, y, GetSymbol());
        }

        //Ghost symbol
        public override char GetSymbol()
        {
            return Map.stupidGhostSymbol;
        }

        //Detect possible directions
        public void DetectDirection()
        {
            List<direction> variantsOfDirection = new List<direction>();
            if (objectDirection == direction.up)
            {
                if (Program.map[x, y - 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.up);
                }
                if (Program.map[x - 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.left);
                }
                if (Program.map[x + 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.right);
                }
            }
            else if (objectDirection == direction.down)
            {
                if (Program.map[x, y + 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.down);
                }
                if (Program.map[x - 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.left);
                }
                if (Program.map[x + 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.right);
                }
            }
            else if (objectDirection == direction.left)
            {
                if (Program.map[x, y - 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.up);
                }
                if (Program.map[x - 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.left);
                }
                if (Program.map[x, y + 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.down);
                }
            }
            else
            {
                if (Program.map[x, y - 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.up);
                }
                if (Program.map[x, y + 1] != Map.wall)
                {
                    variantsOfDirection.Add(direction.down);
                }
                if (Program.map[x + 1, y] != Map.wall)
                {
                    variantsOfDirection.Add(direction.right);
                }
            }

            //Random choise of direction
            Random random = new Random();
            int index = random.Next(variantsOfDirection.Count);
            objectDirection = variantsOfDirection[index];
        }

        //Next Step
        public override void Step()
        {
            KillPacman();
            DetectDirection();
            ChangePositionByDirection(objectDirection);
            KillPacman();
        }
    }
}
