using System;

namespace legacytictactoe
{
    internal class Player
    {

        private readonly char _playerCharacter;
        private readonly string _playerName;

        public Player(char playerCharacter, string playerName)
        {
            _playerCharacter = playerCharacter;
            _playerName = playerName;
        }

        public void Play(char[] gameMatrix)
        {
            Console.Write(_playerName + ":");
            var cellSelected = int.Parse(Console.ReadLine());
            gameMatrix[cellSelected] = _playerCharacter;
        }
    }
}
