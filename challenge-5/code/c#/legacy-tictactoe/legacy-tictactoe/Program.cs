using System;
using System.IO;

namespace TicTacToe
{
    public class TicTacToeController
    {
        private readonly TextReader inputStream;
        private readonly TextWriter outputStream;

        public TicTacToeController(TextReader inputStream, TextWriter outputStream)
        {
            this.inputStream = inputStream;
            this.outputStream = outputStream;
        }

        public static void Main()
        {
            new TicTacToeController(Console.In, Console.Out).Play();
        }


        public void Play()
        {
            var ticTacToeGame = new TicTacToeGame(inputStream, outputStream, GetPlayerOrder());
            try
            {
                ticTacToeGame.ReadPlayerMoves();

                foreach (var winner in ticTacToeGame.GetWinners())
                {
                    outputStream.WriteLine(winner);
                }

                outputStream.Write(ticTacToeGame.GetBoardState());
            }
            catch (IOException exc)
            {
                outputStream.WriteLine(exc.StackTrace);
            }
        }

        private static Player[] GetPlayerOrder()
        {
            var isFirstPlayerA = new Random((int) DateTime.Now.Ticks & 0x0000FFFF).NextDouble() < 0.5;
            if (isFirstPlayerA)
            {
                return new[]
                {
                    Player.A,
                    Player.B
                };
            }
            return new[]
            {
                Player.B,
                Player.A
            };
        }
    }
}