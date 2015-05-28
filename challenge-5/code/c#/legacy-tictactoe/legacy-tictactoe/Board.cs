using System;

namespace legacytictactoe
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


        public char GetMoveAtPosition(int position)
        {
            return board[position];
        }
    }
}