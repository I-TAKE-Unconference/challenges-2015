using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace legacytictactoe
{
    public static class DrawGameMatrixService
    {
        public static void DrawGameMatrix(char[] tab)
        {
            for (int i = 1; i <= 9; i++)
            {
                Console.Write(tab[i]);
                if (i == 3 || i == 6 || i == 9)
                    Console.Write("\n");
            }
        }
    }
}
