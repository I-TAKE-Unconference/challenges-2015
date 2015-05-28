using System;
using System.IO;

namespace legacytictactoe
{
	public class Tic
	{
		int i, a;
	    public char[] tab = new char[10];
	    private TextReader inputStream;
	    private TextWriter outStream;

	    public Tic(TextReader input, TextWriter output)
	    {
	        inputStream = input;
	        outStream = output;
	    }

	    private void Choice(){
			double tirage = 0;
			Random random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
			tirage = random.NextDouble();

			if (tirage < 0.5) {
				for (i = 1; i <= 9; i++)
				{
				    if (i % 2 != 0) {
						outStream.Write("player A:");
						a = int.Parse(inputStream.ReadLine());
						tab[a] = 'x';
					} else {
						outStream.Write("player B:");
						a = int.Parse(inputStream.ReadLine());
						tab[a] = 'o';
					}
				}
			}

			if (tirage >= 0.5) {
				for (i = 1; i <= 9; i++) {
					if (i % 2 != 0) {
						outStream.Write("player B:");
						a = int.Parse(inputStream.ReadLine());
						tab[a] = 'o';
					} else {
						outStream.Write("player A:");
						a = int.Parse(inputStream.ReadLine());
						tab[a] = 'x';
					}
				}
			}
		}

		public void Evaluate() {
			Choice();
			if (HasPlayerWon('x'))

				outStream.WriteLine("\nthe winner is : player A\n");

			if (HasPlayerWon('o'))

				outStream.WriteLine("\nthe winner is : player B\n");
		}

	    private bool HasPlayerWon(char playerToken)
	    {
	        return (tab[1] == playerToken) && (tab[2] == playerToken) && (tab[3] == playerToken) ||
	               (tab[4] == playerToken) && (tab[5] == playerToken) && (tab[6] == playerToken) ||
	               (tab[7] == playerToken) && (tab[8] == playerToken) && (tab[9] == playerToken) ||
	               (tab[1] == playerToken) && (tab[4] == playerToken) && (tab[7] == playerToken) ||
	               (tab[2] == playerToken) && (tab[5] == playerToken) && (tab[8] == playerToken) ||
	               (tab[3] == playerToken) && (tab[6] == playerToken) && (tab[9] == playerToken) ||
	               (tab[1] == playerToken) && (tab[5] == playerToken) && (tab[9] == playerToken) ||
	               (tab[3] == playerToken) && (tab[5] == playerToken) && (tab[7] == playerToken);
	    }
	}
}