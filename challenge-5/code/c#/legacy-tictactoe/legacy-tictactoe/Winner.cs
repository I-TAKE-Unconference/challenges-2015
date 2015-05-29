using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace legacytictactoe
{
    internal class WinnerService
    {
        public static void CheckWinner(Player player, char[] tab)
        {
            bool winner = LineWinner(player, tab) || ColumnWinner(player, tab) || DiagonalWinner(player, tab);
            if (winner)
            {
                Console.WriteLine("\nThe winner is : " + player.PlayerName);
            }
        }
        private static bool LineWinner(Player player, char[] tab)
        {
            int position = 0;
            while (position < 9)
            {
                if (tab[position + 1] == tab[position + 2] && tab[position + 2] == tab[position + 3] && tab[position + 1] == player.PlayerCharacter)
                {
                    return true;
                }
                position += 3;
            }
            return false;
        }
        private static bool ColumnWinner(Player player, char[] tab)
        {
            int position = 0;
            while (position < 3)
            {
                if (tab[position + 1] == tab[position + 4] && tab[position + 4] == tab[position + 7] && tab[position + 1] == player.PlayerCharacter)
                {
                    return true;
                }
                position += 1;
            }
            return false;
        }
        private static bool DiagonalWinner(Player player, char[] tab)
        {
            if (tab[1] == tab[5] && tab[5] == tab[9] && tab[1] == player.PlayerCharacter)
            {
                return true; ;
            }
            if (tab[3] == tab[5] && tab[5] == tab[7] && tab[3] == player.PlayerCharacter)
            {
                return true;
            }
            return false;
        }
    }
}
