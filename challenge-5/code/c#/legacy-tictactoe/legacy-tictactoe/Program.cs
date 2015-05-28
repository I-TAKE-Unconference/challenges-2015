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
                outputStream.Write(GetBoardText(ticTacToeGame));
            }
            catch (IOException exc)
            {
                outputStream.WriteLine(exc.StackTrace);
            }
        }

        private static string GetBoardText(TicTacToeGame ticTacToeGame)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 1; i <= 9; i++)
            {
                var move = ticTacToeGame.Board.GetMoveAtPosition(i);
                stringBuilder.Append(move);
                if (i == 3 || i == 6 || i == 9)
                {
                    stringBuilder.Append("\n");
                }
            }
            var boardText = stringBuilder.ToString();
            return boardText;
        }
    }
}