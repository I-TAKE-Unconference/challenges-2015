using System;


namespace legacytictactoe
{
    public class TicTacToeGame
    {
        private const char PlayerACharacter = 'o';
        private const char PlayerBCharacter = 'x';
        private const int NumberOfCells = 10;
        private const string PlayerAName = "Player A";
        private const string PlayerBName = "Player B";

        private readonly char[] _gameMatrix = new char[NumberOfCells];

        private readonly Player[] _players = new Player[2];
        private readonly Player _playerA = new Player(PlayerACharacter, PlayerAName);
        private readonly Player _playerB = new Player(PlayerBCharacter, PlayerBName);

        public char[] GameMatrix
        {
            get { return _gameMatrix; }
        }

        private void StartMovements()
        {
            int turnNumber;

            for (turnNumber = 0; turnNumber < NumberOfCells - 1; turnNumber++)
            {
                int playerNumber = GetPlayerToPlay(turnNumber);
                _players[playerNumber].Play(_gameMatrix);
            }
        }

        private int GetPlayerToPlay(int turnNumber)
        {
            return turnNumber % 2;
        }

        private void GetPlayers()
        {
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            double tirage = random.NextDouble();

            if (tirage < 0.5)
            {
                _players[0] = _playerA;
                _players[1] = _playerB;
            }
            else
            {
                _players[0] = _playerB;
                _players[1] = _playerA;

            }
        }

        private bool CheckPlayerWin(char playerCharacter)
        {
            if (CheckFirstRowWinCondition(playerCharacter) ||
                CheckSecondRowWinCondition(playerCharacter) ||
                CheckThirdRowWinCondition(playerCharacter) ||
                CheckFirstColumnWinCondition(playerCharacter) ||
                CheckSecondColumnWinCondition(playerCharacter) ||
                CheckThirdColumnWinCondition(playerCharacter) ||
                CheckFirstDiagonalWinCondition(playerCharacter) ||
                CheckSecondDiagonalWinCondition(playerCharacter))
                return true;
            return false;
        }

        private bool CheckFirstRowWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[1] == playerCharacter) && (_gameMatrix[2] == playerCharacter) && (_gameMatrix[3] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckSecondRowWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[4] == playerCharacter) && (_gameMatrix[5] == playerCharacter) && (_gameMatrix[6] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckThirdRowWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[7] == playerCharacter) && (_gameMatrix[8] == playerCharacter) && (_gameMatrix[9] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckFirstColumnWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[1] == playerCharacter) && (_gameMatrix[4] == playerCharacter) && (_gameMatrix[7] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckSecondColumnWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[2] == playerCharacter) && (_gameMatrix[5] == playerCharacter) && (_gameMatrix[8] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckThirdColumnWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[3] == playerCharacter) && (_gameMatrix[6] == playerCharacter) && (_gameMatrix[9] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckFirstDiagonalWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[1] == playerCharacter) && (_gameMatrix[5] == playerCharacter) && (_gameMatrix[9] == playerCharacter))
                return true;
            return false;
        }

        private bool CheckSecondDiagonalWinCondition(char playerCharacter)
        {
            if ((_gameMatrix[3] == playerCharacter) && (_gameMatrix[5] == playerCharacter) && (_gameMatrix[7] == playerCharacter))
                return true;
            return false;
        }


        public void StartGame()
        {
            GetPlayers();
            StartMovements();
            if (CheckPlayerWin(PlayerBCharacter))
                Console.WriteLine("\nthe winner is : player A\n");

            if (CheckPlayerWin(PlayerACharacter))
                Console.WriteLine("\nthe winner is : player B\n");
        }
    }
}