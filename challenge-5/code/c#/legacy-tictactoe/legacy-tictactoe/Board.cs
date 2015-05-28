using System;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        private readonly char[] board = new char[10];

        public void AddPlayerMove(Player player, string move)
        {
            var position = Int32.Parse(move);
            board[position] = player.Token;
        }

        public bool HasPlayerWon(char playerToken)
        {
            return (board[1] == playerToken) && (board[2] == playerToken) && (board[3] == playerToken) ||
                   (board[4] == playerToken) && (board[5] == playerToken) && (board[6] == playerToken) ||
                   (board[7] == playerToken) && (board[8] == playerToken) && (board[9] == playerToken) ||
                   (board[1] == playerToken) && (board[4] == playerToken) && (board[7] == playerToken) ||
                   (board[2] == playerToken) && (board[5] == playerToken) && (board[8] == playerToken) ||
                   (board[3] == playerToken) && (board[6] == playerToken) && (board[9] == playerToken) ||
                   (board[1] == playerToken) && (board[5] == playerToken) && (board[9] == playerToken) ||
                   (board[3] == playerToken) && (board[5] == playerToken) && (board[7] == playerToken);
        }


        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 1; i <= 9; i++)
            {
                stringBuilder.Append(board[i]);
                if (i%3 == 0)
                {
                    stringBuilder.Append("\n");
                }
            }
            return stringBuilder.ToString();
        }
    }
}