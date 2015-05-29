using System;
using System.Collections.Generic;
using System.IO;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly TextReader inputStream;
        private readonly TextWriter outStream;
        private readonly Board board;

        public TicTacToeGame(TextReader input, TextWriter output, Player[] playerOrder)
        {
            inputStream = input;
            outStream = output;

            board = new Board(new PlayerOrder(playerOrder));
        }

        public Board Board
        {
            get { return board; }
        }

        public void WriteWinners()
        {
            foreach (var winningPlayer in Board.GetWinningPlayers())
            {
                outStream.WriteLine(string.Format("\nthe winner is : {0}\n", winningPlayer.ToString()));
            }
        }

        public void ReadPlayerMoves()
        {
            for (var i = 1; i <= 9; i++)
            {
                var currentPlayer = Board.CurrentPlayer;
                outStream.Write(currentPlayer + ":");

                var position = inputStream.ReadLine();

                Board.AddPlayerMove(position);
            }
        }
    }
}