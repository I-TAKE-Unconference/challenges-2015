namespace TicTacToe
{
    public class PlayerOrder
    {
        private Node<Player> currentPlayer;
        public Player CurrentPlayer { get { return currentPlayer.Value; } }

        public void ChangeRound()
        {
            currentPlayer = currentPlayer.Next;
        }

        private class Node<T>
        {
            public T Value { get; private set; }
            public Node<T> Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }

            public Node(T value, Node<T> next)
            {
                Value = value;
                Next = next;
            }
        }

        public PlayerOrder(Player[] playerOrder)
        {
            var first = new Node<Player>(playerOrder[0]);
            var second = new Node<Player>(playerOrder[1], first);
            first.Next = second;
            this.currentPlayer = first;
        }
    }
}