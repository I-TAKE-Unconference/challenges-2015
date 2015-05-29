using System;
using System.IO;

namespace legacytictactoe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Tic tic = new Tic();
            try
            {
                tic.EvaluateGame();
                DrawGameMatrixService.DrawGameMatrix(tic.GetPlayersMoves());
                Console.ReadLine();

            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }


    }
}
