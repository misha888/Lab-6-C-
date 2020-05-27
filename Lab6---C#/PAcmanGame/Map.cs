using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    public class Map
    {
        int x, y; //coordinates
        public static char wall = '█'; //symbol of wall
        public static char emptySpace = ' '; //symbol of empty space
        public static char jewel = '·'; //symbol of jewel
        public static char smartGhostSymbol = 'X'; //symbol of ghost
        public static char stupidGhostSymbol = 'Y'; //symbol of ghost
        public char[,] area = new char[31, 28]; //array of map

        public char Wall { get; set; }
        public char EmptySpace { get; set; }
        public char Jewel { get; set; }

        //Indexer of map
        public char this[int x, int y]
        {
            get
            {
                if (x < 0) return area[y, 27];
                else if (x > 27) return area[y, 0];
                else return area[y, x];
            }
            set
            {
                area[y, x] = value;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x + 1, y + 1);
                Console.Write(value);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Render of something
        public void RenderChar(int x, int y, char symbol)
        {
            if (x < 0) x = 27;
            else if (x > 27) x = 0;

            if (symbol == '@') Console.ForegroundColor = ConsoleColor.Green;
            else if (symbol == 'X') Console.ForegroundColor = ConsoleColor.Red;
            else if (symbol == 'Y') Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(symbol);
            Console.ForegroundColor = ConsoleColor.White;

            area[y, x] = symbol;
        }

        //Methods for new maps
        private void RenderWall(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(wall);
            Console.ForegroundColor = ConsoleColor.White;
            area[y, x] = wall;
        }
        public void RenderEmptySpace(int x, int y)
        {
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(emptySpace);
            area[y, x] = emptySpace;
        }
        public void RenderJewel(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(jewel);
            Console.ForegroundColor = ConsoleColor.White;
            area[y, x] = jewel;
        }

        //Manually render of map
        public void RenderMap()
        {
            //Border
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < 28; i++)
            {
                Console.Write(wall);
                area[0, i] = wall;
            }
            Console.SetCursorPosition(1, 31);
            for (int i = 0; i < 28; i++)
            {
                Console.Write(wall);
                area[30, i] = wall;
            }
            for (int i = 2; i < 15; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(wall);
                area[i - 1, 0] = wall;
                Console.SetCursorPosition(28, i);
                Console.Write(wall);
                area[i - 1, 27] = wall;
            }
            for (int i = 16; i < 31; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(wall);
                area[i - 1, 0] = wall;
                Console.SetCursorPosition(28, i);
                Console.Write(wall);
                area[i - 1, 27] = wall;
            }

            //Walls

            //left 1/3 part
            for (int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(3, i);
                for (int j = 3; j < 7; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(3, i);
                for (int j = 3; j < 7; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 15; i++)
            {
                Console.SetCursorPosition(2, i);
                for (int j = 2; j < 7; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                Console.SetCursorPosition(2, i);
                for (int j = 2; j < 7; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(2, i);
                for (int j = 2; j < 4; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(3, i);
                for (int j = 3; j < 7; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 24; i < 27; i++)
            {
                Console.SetCursorPosition(5, i);
                for (int j = 5; j < 7; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }

            //left 2/3 part
            for (int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(8, i);
                for (int j = 8; j < 13; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 15; i++)
            {
                Console.SetCursorPosition(8, i);
                for (int j = 8; j < 10; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 12; i++)
            {
                Console.SetCursorPosition(10, i);
                for (int j = 10; j < 13; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                Console.SetCursorPosition(8, i);
                for (int j = 8; j < 10; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(8, i);
                for (int j = 8; j < 13; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 28; i++)
            {
                Console.SetCursorPosition(8, i);
                for (int j = 8; j < 10; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(3, i);
                for (int j = 3; j < 13; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }

            //left 3/3 part
            for (int i = 2; i < 6; i++)
            {
                Console.SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 12; i++)
            {
                Console.SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 13; i < 14; i++)
            {
                Console.SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 14; i < 17; i++)
            {
                Console.SetCursorPosition(11, i);
                for (int j = 11; j < 12; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 17; i < 18; i++)
            {
                Console.SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 19; i < 21; i++)
            {
                Console.SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 21; i < 24; i++)
            {
                Console.SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(11, i);
                for (int j = 11; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 27; i < 30; i++)
            {
                Console.SetCursorPosition(14, i);
                for (int j = 14; j < 15; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }

            //right 1/3 part
            for (int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(23, i);
                for (int j = 23; j < 27; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(23, i);
                for (int j = 23; j < 27; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 15; i++)
            {
                Console.SetCursorPosition(23, i);
                for (int j = 23; j < 28; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                Console.SetCursorPosition(23, i);
                for (int j = 23; j < 28; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(26, i);
                for (int j = 26; j < 28; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(23, i);
                for (int j = 23; j < 27; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 24; i < 27; i++)
            {
                Console.SetCursorPosition(23, i);
                for (int j = 23; j < 25; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }

            //right 2/3 part
            for (int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(17, i);
                for (int j = 17; j < 22; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 15; i++)
            {
                Console.SetCursorPosition(20, i);
                for (int j = 20; j < 22; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 10; i < 12; i++)
            {
                Console.SetCursorPosition(17, i);
                for (int j = 17; j < 20; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 16; i < 21; i++)
            {
                Console.SetCursorPosition(20, i);
                for (int j = 20; j < 22; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(17, i);
                for (int j = 17; j < 22; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 28; i++)
            {
                Console.SetCursorPosition(20, i);
                for (int j = 20; j < 22; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(17, i);
                for (int j = 17; j < 27; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }

            //right 3/3 part
            for (int i = 2; i < 6; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 7; i < 12; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 13; i < 14; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 14; i < 17; i++)
            {
                Console.SetCursorPosition(18, i);
                for (int j = 18; j < 19; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 17; i < 18; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 19; i < 21; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 21; i < 24; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 19; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }
            for (int i = 27; i < 30; i++)
            {
                Console.SetCursorPosition(15, i);
                for (int j = 15; j < 16; j++)
                {
                    Console.Write(wall);
                    area[i - 1, j - 1] = wall;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        //Manually render of jewels
        public void RenderJewels()
        {
            //top horizontal lines
            Console.SetCursorPosition(2, 2);
            for (int i = 1; i < 13; i++)
            {
                Console.Write(jewel);
                area[1, i] = jewel;
            }
            Console.SetCursorPosition(16, 2);
            for (int i = 15; i < 27; i++)
            {
                Console.Write(jewel);
                area[1, i] = jewel;
            }
            //second top horizontal line
            Console.SetCursorPosition(2, 6);
            for (int i = 1; i < 27; i++)
            {
                Console.Write(jewel);
                area[5, i] = jewel;
            }
            //top vertical lines
            for (int i = 3; i < 10; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.Write(jewel);
                area[i - 1, 1] = jewel;
            }
            for (int i = 3; i < 28; i++)
            {
                Console.SetCursorPosition(7, i);
                Console.Write(jewel);
                area[i - 1, 6] = jewel;
            }
            for (int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(13, i);
                Console.Write(jewel);
                area[i - 1, 12] = jewel;
            }
            for (int i = 3; i < 6; i++)
            {
                Console.SetCursorPosition(16, i);
                Console.Write(jewel);
                area[i - 1, 15] = jewel;
            }
            for (int i = 3; i < 28; i++)
            {
                Console.SetCursorPosition(22, i);
                Console.Write(jewel);
                area[i - 1, 21] = jewel;
            }
            for (int i = 3; i < 10; i++)
            {
                Console.SetCursorPosition(27, i);
                Console.Write(jewel);
                area[i - 1, 26] = jewel;
            }
            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(10, i);
                Console.Write(jewel);
                area[i - 1, 9] = jewel;
            }
            for (int i = 7; i < 9; i++)
            {
                Console.SetCursorPosition(19, i);
                Console.Write(jewel);
                area[i - 1, 18] = jewel;
            }
            //third top horizontal lines
            Console.SetCursorPosition(3, 9);
            for (int i = 2; i < 6; i++)
            {
                Console.Write(jewel);
                area[8, i] = jewel;
            }
            Console.SetCursorPosition(23, 9);
            for (int i = 22; i < 26; i++)
            {
                Console.Write(jewel);
                area[8, i] = jewel;
            }
            Console.SetCursorPosition(10, 9);
            for (int i = 9; i < 13; i++)
            {
                Console.Write(jewel);
                area[8, i] = jewel;
            }
            Console.SetCursorPosition(16, 9);
            for (int i = 15; i < 19; i++)
            {
                Console.Write(jewel);
                area[8, i] = jewel;
            }
            //bottom horizontal line
            Console.SetCursorPosition(2, 30);
            for (int i = 1; i < 27; i++)
            {
                Console.Write(jewel);
                area[29, i] = jewel;
            }
            //second bottom horizontal lines
            Console.SetCursorPosition(2, 27);
            for (int i = 1; i < 7; i++)
            {
                Console.Write(jewel);
                area[26, i] = jewel;
            }
            Console.SetCursorPosition(22, 27);
            for (int i = 21; i < 27; i++)
            {
                Console.Write(jewel);
                area[26, i] = jewel;
            }
            Console.SetCursorPosition(10, 27);
            for (int i = 9; i < 13; i++)
            {
                Console.Write(jewel);
                area[26, i] = jewel;
            }
            Console.SetCursorPosition(16, 27);
            for (int i = 15; i < 19; i++)
            {
                Console.Write(jewel);
                area[26, i] = jewel;
            }
            //bottom vertical lines
            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.Write(jewel);
                area[i - 1, 1] = jewel;
            }
            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(13, i);
                Console.Write(jewel);
                area[i - 1, 12] = jewel;
            }
            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(16, i);
                Console.Write(jewel);
                area[i - 1, 15] = jewel;
            }
            for (int i = 28; i < 30; i++)
            {
                Console.SetCursorPosition(27, i);
                Console.Write(jewel);
                area[i - 1, 26] = jewel;
            }
            //second bottom vertical lines
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(4, i);
                Console.Write(jewel);
                area[i - 1, 3] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(10, i);
                Console.Write(jewel);
                area[i - 1, 9] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(19, i);
                Console.Write(jewel);
                area[i - 1, 18] = jewel;
            }
            for (int i = 25; i < 27; i++)
            {
                Console.SetCursorPosition(25, i);
                Console.Write(jewel);
                area[i - 1, 24] = jewel;
            }

            //third bottom horizontal lines
            Console.SetCursorPosition(2, 24);
            for (int i = 1; i < 4; i++)
            {
                Console.Write(jewel);
                area[23, i] = jewel;
            }
            Console.SetCursorPosition(25, 24);
            for (int i = 24; i < 27; i++)
            {
                Console.Write(jewel);
                area[23, i] = jewel;
            }
            Console.SetCursorPosition(8, 24);
            for (int i = 7; i < 13; i++)
            {
                Console.Write(jewel);
                area[23, i] = jewel;
            }
            Console.SetCursorPosition(16, 24);
            for (int i = 15; i < 21; i++)
            {
                Console.Write(jewel);
                area[23, i] = jewel;
            }

            //third bottom vertical lines
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.Write(jewel);
                area[i - 1, 1] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(13, i);
                Console.Write(jewel);
                area[i - 1, 12] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(16, i);
                Console.Write(jewel);
                area[i - 1, 15] = jewel;
            }
            for (int i = 22; i < 24; i++)
            {
                Console.SetCursorPosition(27, i);
                Console.Write(jewel);
                area[i - 1, 26] = jewel;
            }

            //fourth horizontal lines
            Console.SetCursorPosition(2, 21);
            for (int i = 1; i < 13; i++)
            {
                Console.Write(jewel);
                area[20, i] = jewel;
            }
            Console.SetCursorPosition(16, 21);
            for (int i = 15; i < 27; i++)
            {
                Console.Write(jewel);
                area[20, i] = jewel;
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
