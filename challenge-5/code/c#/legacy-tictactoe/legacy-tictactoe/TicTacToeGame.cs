using System;
using System.IO;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly TextReader inputStream;
        private readonly TextWriter outStream;
        private readonly Board board;

        public TicTacToeGame(TextReader input, TextWriter output)
        {
            inputStream = input;
            outStream = output;
            board = new Board();
        }

        public Board Board
        {
            get { return board; }
        }

        private void Choice()
        {
            var isFirstPlayerA = IsFirstPlayerA();
            var firstPlayer = isFirstPlayerA ? Player.A : Player.B;
            var secondPlayer = isFirstPlayerA ? Player.B : Player.A;
            for (var i = 1; i <= 9; i++)
            {
                var currentPlayer = i%2 != 0 ? firstPlayer : secondPlayer;
                outStream.Write(currentPlayer.ToString());
                Board.AddPlayerMove(currentPlayer, inputStream.ReadLine());
            }
        }

        private static bool IsFirstPlayerA()
        {
            return new Random((int) DateTime.Now.Ticks & 0x0000FFFF).NextDouble() < 0.5;
        }

        public void Evaluate()
        {
            //SRP: choice, evaluate, output
            Choice();
            if (Board.HasPlayerWon('x'))
            {
                outStream.WriteLine("\nthe winner is : player A\n");
            }

            if (Board.HasPlayerWon('o'))
            {
                outStream.WriteLine("\nthe winner is : player B\n");
            }
        }
    }
}