using System;
using System.IO;

namespace legacytictactoe
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Tic tic = new Tic();
			try {
				tic.eval();
				for (int i = 1; i <= 9; i++) {
					Console.Write(tic.tab[i]);
					if (i == 3 || i == 6 || i == 9)
						Console.Write("\n");
				}
			} catch (IOException exc){
				Console.WriteLine (exc.StackTrace);
			}
		}
	}
}
