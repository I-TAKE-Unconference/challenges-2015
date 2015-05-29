using System;
using System.IO;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly TextReader inputStream;
        private readonly TextWriter outStream;
        private readonly Board board;

        public TicTacToeGame(TextReader input, TextWriter output, Player[] getPlayerOrder)
        {
            inputStream = input;
            outStream = output;
            board = new Board();
        }

        public Board Board
        {
            get { return board; }
        }

        public void Evaluate(Player[] playOrder)
        {
            //SRP: choice, evaluate, output
            Choice(playOrder);

            foreach (var winningPlayer in Board.GetWinningPlayers())
            {
                outStream.WriteLine(string.Format("\nthe winner is : {0}\n", winningPlayer.ToString()));
            }
        }

        private void Choice(Player[] playerOrder)
        {
            for (var i = 1; i <= 9; i++)
            {
                var currentPlayer = playerOrder[(i + 1)%2];
                outStream.Write(currentPlayer + ":");
                Board.AddPlayerMove(currentPlayer, inputStream.ReadLine());
            }
        }
    }
}