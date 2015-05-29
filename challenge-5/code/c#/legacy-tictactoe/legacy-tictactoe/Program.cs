using System;
using System.IO;

namespace legacytictactoe
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var ticTacToeGame = new TicTacToeGame();
			try {
				ticTacToeGame.StartGame();
				for (int i = 1; i <= 9; i++) {
					Console.Write(ticTacToeGame.GameMatrix[i]);
					if (i == 3 || i == 6 || i == 9)
						Console.Write("\n");
				}
			} catch (IOException exc){
				Console.WriteLine (exc.StackTrace);
			}
		}
	}
}
