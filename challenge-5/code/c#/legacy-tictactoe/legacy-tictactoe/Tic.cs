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
            if (IsAFirstPlayer())
            {
                for (var i = 1; i <= 9; i++)
                {
                    if (i%2 != 0)
                    {
                        AddPlayerAMove(inputStream.ReadLine());
                    }
                    else
                    {
                        AddPlayerBMove(inputStream.ReadLine());
                    }
                }
            }
            else
            {
                for (var i = 1; i <= 9; i++)
                {
                    if (i%2 != 0)
                    {
                        AddPlayerBMove(inputStream.ReadLine());
                    }
                    else
                    {
                        AddPlayerAMove(inputStream.ReadLine());
                    }
                }
            }
        }

        private static bool IsAFirstPlayer()
        {
            return new Random((int) DateTime.Now.Ticks & 0x0000FFFF).NextDouble() < 0.5;
        }

        private void AddPlayerAMove(string move)
        {
            var player = Player.A;
            outStream.Write(player.ToString());
            var position = int.Parse(move);
            tab[position] = player.Token;
        }

        private void AddPlayerBMove(string move)
        {
            var player = Player.B;
            outStream.Write(player.ToString());
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