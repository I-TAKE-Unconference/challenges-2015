using System;
using System.IO;

namespace TicTacToe
{
    public class MainClass
    {
        private readonly TextReader inputStream;
        private readonly TextWriter outputStream;

        public MainClass(TextReader inputStream, TextWriter outputStream)
        {
            this.inputStream = inputStream;
            this.outputStream = outputStream;
        }

        public static void Main(string[] args)
        {
            new MainClass(Console.In, Console.Out).Evaluate();
        }


        public  void Evaluate()
        {
            var ticTacToeGame = new TicTacToeGame(inputStream, outputStream, GetPlayerOrder());
            try
            {
                //SRP: choice, evaluate, output
                ticTacToeGame.ReadPlayerMoves();

                ticTacToeGame.WriteWinners();

                outputStream.Write(ticTacToeGame.Board.ToString());
            }
            catch (IOException exc)
            {
                outputStream.WriteLine(exc.StackTrace);
            }
        }

        public static Player[] GetPlayerOrder()
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