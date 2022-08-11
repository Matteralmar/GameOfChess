using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfChess
{
    public static class Map //this class is created to know figure difference from each other and to know whose figure it is
    {
        public static int[,] map =
        {

                {15,14,13,11,12,13,14,15},
                {16,16,16,16,16,16,16,16},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {26,26,26,26,26,26,26,26},
                {25,24,23,21,22,23,24,25},

        };
    }
}
