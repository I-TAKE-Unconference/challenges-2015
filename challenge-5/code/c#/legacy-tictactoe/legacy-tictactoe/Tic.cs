using System;
using System.IO;

namespace legacytictactoe
{
    public class Tic
    {
        public char[] tab = new char[10];
        private readonly TextReader inputStream;
        private readonly TextWriter outStream;

        public Tic(TextReader input, TextWriter output)
        {
            inputStream = input;
            outStream = output;
        }

        private void Choice()
        {
            var isFirstPlayerA = IsFirstPlayerA();
            var firstPlayer = isFirstPlayerA ? Player.A : Player.B;
            var secondPlayer = isFirstPlayerA ? Player.B : Player.A;
            for (var i = 1; i <= 9; i++)
            {
                var currentPlayer = i%2 != 0 ? firstPlayer : secondPlayer;
                outStream.Write(currentPlayer.ToString());
                AddPlayerMove(currentPlayer, inputStream.ReadLine());
            }
        }

        private static bool IsFirstPlayerA()
        {
            return new Random((int) DateTime.Now.Ticks & 0x0000FFFF).NextDouble() < 0.5;
        }

        private void AddPlayerMove(Player player, string move)
        {
            var position = int.Parse(move);
            tab[position] = player.Token;
        }

        public void Evaluate()
        {
            //SRP: choice, evaluate, output
            Choice();
            if (HasPlayerWon('x'))
            {
                outStream.WriteLine("\nthe winner is : player A\n");
            }

            if (HasPlayerWon('o'))
            {
                outStream.WriteLine("\nthe winner is : player B\n");
            }
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