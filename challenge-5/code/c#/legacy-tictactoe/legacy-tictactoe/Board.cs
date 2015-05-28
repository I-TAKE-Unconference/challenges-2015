using System;
using System.Collections.Generic;
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

        private IEnumerable<char[]> GetWinningLines()
        {
            var possibleWinners = new[]
            {
                new[]{1,2,3},
                new[]{4,5,6},
                new[]{7,8,9},
                new[]{1,4,7},
                new[]{2,5,8},
                new[]{3,6,9},
                new[]{1,5,9},
                new[]{3,5,7}
            };
            foreach (var possibleWinner in possibleWinners)
            {
                if (board[possibleWinner[0]] == board[possibleWinner[1]] &&
                    board[possibleWinner[1]] == board[possibleWinner[2]])
                {
                    yield return new[]
                    {
                        board[possibleWinner[0]],
                        board[possibleWinner[1]],
                        board[possibleWinner[2]],
                    };
                }
            }
        }

        public IEnumerable<Player> GetWinningPlayers()
        {
            if (HasPlayerWon(Player.A))
            {
                yield return Player.A;
            }

            if (HasPlayerWon(Player.B))
            {
                yield return Player.B;
            }
        }

        private bool HasPlayerWon(Player player)
        {
            var playerToken = player.Token;
            bool result = false;
            foreach (var p in GetWinningLines())
            {
                if (p[0] == playerToken)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}