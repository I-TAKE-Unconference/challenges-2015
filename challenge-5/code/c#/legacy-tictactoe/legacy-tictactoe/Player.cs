using System;

namespace TicTacToe
{
    public class Player
    {
        public static Player A = new Player("A", 'x');
        public static Player B = new Player("B", 'o');
        public char Token { get; private set; }
        private string Name { get; set; }

        private Player(string name, char token)
        {
            Name = name;
            Token = token;
        }

        public override string ToString()
        {
            return String.Format("player {0}", Name);
        }

        public static Player FromToken(char token)
        {
            if (A.Token==token)
            {
                return A;
            }
            if (B.Token==token)
            {
                return B;
            }
            return null;
        }
    }
}