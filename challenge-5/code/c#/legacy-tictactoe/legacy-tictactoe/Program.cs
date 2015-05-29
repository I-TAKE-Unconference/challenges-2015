using System;
using System.IO;

namespace TicTacToe
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            RunGame(Console.In, Console.Out);
        }

        public static void RunGame(TextReader inputStream, TextWriter outputStream)
        {
            var ticTacToeGame = new TicTacToeGame(inputStream, outputStream, GetPlayerOrder());
            try
            {
                ticTacToeGame.Evaluate(GetPlayerOrder());
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