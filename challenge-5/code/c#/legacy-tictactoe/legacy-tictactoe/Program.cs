using System;
using System.IO;
using System.Text;

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
            var ticTacToeGame = new TicTacToeGame(inputStream, outputStream);
            try
            {
                ticTacToeGame.Evaluate();
                outputStream.Write(ticTacToeGame.Board.ToString());
            }
            catch (IOException exc)
            {
                outputStream.WriteLine(exc.StackTrace);
            }
        }
    }
}