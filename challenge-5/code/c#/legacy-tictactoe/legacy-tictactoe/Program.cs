using System;
using System.IO;

namespace TicTacToe
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
		    RunGame(Console.In, Console.Out);
		}

	    public static void RunGame(TextReader inputStream, TextWriter outputStream)
	    {
	        TicTacToeGame ticTacToeGame = new TicTacToeGame(inputStream, outputStream);
	        try
	        {
	            ticTacToeGame.Evaluate();
	            for (int i = 1; i <= 9; i++)
	            {
	                var move = ticTacToeGame.Board.GetMoveAtPosition(i);

	                outputStream.Write(move);
	                if (i == 3 || i == 6 || i == 9)
	                {
	                    outputStream.Write("\n");
	                }
	            }
	        }
	        catch (IOException exc)
	        {
	            outputStream.WriteLine(exc.StackTrace);
	        }
	    }
	}
}
