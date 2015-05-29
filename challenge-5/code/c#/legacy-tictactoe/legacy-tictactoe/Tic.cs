using System;

namespace legacytictactoe
{
    public class Tic
    {
        private char[] tab;

        public Tic()
        {
            tab = new char[10];
        }
        public char[] GetPlayersMoves()
        {
            return tab;
        }
        public void EvaluateGame()
        {
            Play();
            WinnerService.CheckWinner(Player.A, tab);
            WinnerService.CheckWinner(Player.B, tab);
            Console.ReadLine();
        }
        private void Play()
        {
            var playerToMove = GetStartingPlayer();
            for (var i = 1; i <= 9; i++)
            {
                Console.Write(playerToMove.PlayerName + ": ");
                var a = int.Parse(Console.ReadLine());
                tab[a] = playerToMove.PlayerCharacter;
                playerToMove = GetNextPlayer(playerToMove);
            }
        }
        private Player GetStartingPlayer()
        {
            double tirage = 0;
            Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            tirage = random.NextDouble();
            return tirage < 0.5 ? Player.A : Player.B;
        }
        private Player GetNextPlayer(Player currentPlayer)
        {
            return currentPlayer.PlayerName == Player.A.PlayerName ? Player.B : Player.A;
        }        
        
        
    }
}