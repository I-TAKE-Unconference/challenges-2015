using System;

namespace legacytictactoe
{
	public class Tic
	{
		int i, a;
		public char[] tab = new char[10];

		public void choice(){
			double tirage = 0;
			Random random = new Random((int) DateTime.Now.Ticks & 0x0000FFFF);
			tirage = random.NextDouble();

			if (tirage < 0.5) {
				for (i = 1; i <= 9; i++) {
					if (i % 2 != 0) {
						Console.Write("player A:");
						a = int.Parse(Console.ReadLine());
						tab[a] = 'x';
					} else {
						Console.Write("player B:");
						a = int.Parse(Console.ReadLine());
						tab[a] = 'o';
					}
				}
			}

			if (tirage >= 0.5) {
				for (i = 1; i <= 9; i++) {
					if (i % 2 != 0) {
						Console.Write("player B:");
						a = int.Parse(Console.ReadLine());
						tab[a] = 'o';
					} else {
						Console.Write("player A:");
						a = int.Parse(Console.ReadLine());
						tab[a] = 'x';
					}
				}
			}
		}

		public void eval() {
			choice();
			if ((tab[1] == 'x') && (tab[2] == 'x') && (tab[3] == 'x') ||
			    (tab[4] == 'x') && (tab[5] == 'x') && (tab[6] == 'x') ||
			    (tab[7] == 'x') && (tab[8] == 'x') && (tab[9] == 'x') ||
			    (tab[1] == 'x') && (tab[4] == 'x') && (tab[7] == 'x') ||
			    (tab[2] == 'x') && (tab[5] == 'x') && (tab[8] == 'x') ||
			    (tab[3] == 'x') && (tab[6] == 'x') && (tab[9] == 'x') ||
			    (tab[1] == 'x') && (tab[5] == 'x') && (tab[9] == 'x') ||
			    (tab[3] == 'x') && (tab[5] == 'x') && (tab[7] == 'x'))

				Console.WriteLine("\nthe winner is : player A\n");

			if ((tab[1] == 'o') && (tab[2] == 'o') && (tab[3] == 'o') ||
			    (tab[4] == 'o') && (tab[5] == 'o') && (tab[6] == 'o') ||
			    (tab[7] == 'o') && (tab[8] == 'o') && (tab[9] == 'o') ||
			    (tab[1] == 'o') && (tab[4] == 'o') && (tab[7] == 'o') ||
			    (tab[2] == 'o') && (tab[5] == 'o') && (tab[8] == 'o') ||
			    (tab[3] == 'o') && (tab[6] == 'o') && (tab[9] == 'o') ||
			    (tab[1] == 'o') && (tab[5] == 'o') && (tab[9] == 'o') ||
			    (tab[3] == 'o') && (tab[5] == 'o') && (tab[7] == 'o'))

				Console.WriteLine("\nthe winner is : player B\n");
		}
	}
}