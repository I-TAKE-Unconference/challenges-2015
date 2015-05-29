using System;
using System.Collections.Generic;

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

        protected bool Equals(Player other)
        {
            return Token == other.Token && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Token.GetHashCode()*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static IEnumerable<Player> IteratorFromToken(char token)
        {
            if (A.Token == token)
            {
                yield return A;
            }
            if (B.Token == token)
            {
                yield return B;
            }
        }
    }
}