using System;
using System.Collections.Generic;

namespace PacmanGame
{
    class SmartGhost : Object
    {
        //Ghost constructor
        public SmartGhost(int x, int y, direction Direction)
        {
            this.X = x;
            this.Y = y;
            currentStatePlace = Program.map.Jewel;
            objectDirection = Direction;
            Program.map.RenderChar(x, y, GetSymbol());
        }

        //Ghost symbol
        public override char GetSymbol()
        {
            return Map.smartGhostSymbol;
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

            //Choise direction by Pacman position
            Pacman pacman = Program.pacman;

            if (x < pacman.x && objectDirection != direction.left && variantsOfDirection.Contains(direction.right))
            {
                objectDirection = direction.right;
            }
            else if (x > pacman.x && objectDirection != direction.right && variantsOfDirection.Contains(direction.left))
            {
                objectDirection = direction.left;
            }
            else if (y > pacman.y && objectDirection != direction.down && variantsOfDirection.Contains(direction.up))
            {
                objectDirection = direction.up;
            }
            else if (y < pacman.y && objectDirection != direction.up && variantsOfDirection.Contains(direction.down))
            {
                objectDirection = direction.down;
            }
            else
            {
                Random random = new Random();
                int index = random.Next(variantsOfDirection.Count);
                objectDirection = variantsOfDirection[index];
            }
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
