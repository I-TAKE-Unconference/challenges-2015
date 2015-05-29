using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace legacytictactoe
{
    public sealed class Player
    {
        public static readonly Player A = new Player("Player A", 'x');
        public static readonly Player B = new Player("Player B", 'o');

        public readonly string PlayerName;
        public readonly char PlayerCharacter; // x or o

        private Player(string name, char playerCharacter)
        {
            PlayerName = name;
            PlayerCharacter = playerCharacter;
        }
        public static Player GetPlayerByPlayingCharacter(char playingCharacter)
        {
            return playingCharacter == 'x' ? Player.A : Player.B;
        }
    }
}
