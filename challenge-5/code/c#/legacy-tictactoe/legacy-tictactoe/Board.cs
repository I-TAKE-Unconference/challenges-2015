using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        private readonly PlayerOrder playerOrder;
        private readonly char[] board = new char[10];

        private static readonly int[][] WinningCombinations = {
            new[]{1,2,3},
            new[]{4,5,6},
            new[]{7,8,9},
            new[]{1,4,7},
            new[]{2,5,8},
            new[]{3,6,9},
            new[]{1,5,9},
            new[]{3,5,7}
        };

        public Board(PlayerOrder playerOrder)
        {
            this.playerOrder = playerOrder;
        }

        public PlayerOrder PlayerOrder
        {
            get { return playerOrder; }
        }

        public void AddPlayerMove(string position)
        {
            board[Int32.Parse(position)] = PlayerOrder.CurrentPlayer.Token;
            PlayerOrder.ChangeRound();
        }

        public IEnumerable<Player> GetWinningPlayers()
        {
            return GetWinningTokens().SelectMany(Player.IteratorFromToken);
        }

        private IEnumerable<char> GetWinningTokens()
        {
            return from possibleWinner in WinningCombinations 
                   where 
                        board[possibleWinner[0]] == board[possibleWinner[1]] && 
                        board[possibleWinner[1]] == board[possibleWinner[2]] 
                   select board[possibleWinner[0]];
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

        public Player CurrentPlayer
        {
            get { return PlayerOrder.CurrentPlayer; }
        }
    }
}