using System;
using System.IO;
using System.Linq;
using legacytictactoe;
using NSubstitute;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    public class TicTacToeSpecs
    {
        private TextWriter outputStream;
        private TextReader inputStream;

        public Tic CreateSUT()
        {
            return new Tic(inputStream, outputStream);
        }

        [TestFixture]
        public class WrongInput : TicTacToeSpecs
        {
            [SetUp]
            public virtual void SetUp()
            {
                inputStream = Substitute.For<TextReader>();
                outputStream = Substitute.For<TextWriter>();
            }

            [Test]
            [ExpectedException(typeof (FormatException))]
            public void FailsForLetters()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("a");

                sut.eval();
            }

            [Test]
            [ExpectedException(typeof (FormatException))]
            public void FailsForSpecialCharacters()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns(".");

                sut.eval();
            }
            [Test]
            [ExpectedException(typeof(IndexOutOfRangeException))]
            public void FailsForSmallerNumbers()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("-1");

                sut.eval();
            }          
            
            [Test]
            [ExpectedException(typeof(IndexOutOfRangeException))]
            public void FailsForBiggerNumbers()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("10");

                sut.eval();
            }

            [Test]
            public void ZeroPositionIsAccepted()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("0", "3", "2", "4", "6", "5", "7", "8", "9");

                sut.eval();
            }
        }


        [TestFixture]
        public class GameIsADraw : TicTacToeSpecs
        {
            [SetUp]
            public virtual void SetUp()
            {
                inputStream = Substitute.For<TextReader>();
                outputStream = Substitute.For<TextWriter>();
            }

            [Test]
            public void NoOneWins()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "3", "2", "4", "6", "5", "7", "8", "9");

                sut.eval();
                outputStream.Received(0).WriteLine(Arg.Is((string str) => str.Contains("the winner is")));
            }

            [Test]
            public void NoOneWins_ForSameRepeatedPosition()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "1", "1", "1", "1", "1", "1", "1", "1");

                sut.eval();
                outputStream.Received(0).WriteLine(Arg.Is((string str) => str.Contains("the winner is")));
            }
        }

        [TestFixture]
        public class FirstPlayerWins : TicTacToeSpecs
        {
            [SetUp]
            public virtual void SetUp()
            {
                inputStream = Substitute.For<TextReader>();
                outputStream = Substitute.For<TextWriter>();
            }

            private object GetFirstPlayerName()
            {
                var firstPlayerText = outputStream.ReceivedCalls().First().GetArguments().First().ToString();
                return firstPlayerText[firstPlayerText.Length - 2];
            }

            private string WinningPlayerMessage()
            {
                return string.Format("\nthe winner is : player {0}\n", GetFirstPlayerName());
            }


            [Test]
            public void LeftToRightDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "3", "5", "6", "9", "2", "4", "7", "8");

                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Equals(WinningPlayerMessage())));
            }

            [Test]
            public void RightToLeftDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("3", "2", "5", "1", "7", "9", "4", "6", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Equals(WinningPlayerMessage())));
            }

            [Test]
            public void LeftToRightFirstLine()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "4", "2", "6", "3", "5", "9", "7", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Equals(WinningPlayerMessage())));
            }
        }

        [TestFixture]
        public class SecondPlayerWins : TicTacToeSpecs
        {
            [SetUp]
            public virtual void SetUp()
            {
                inputStream = Substitute.For<TextReader>();
                outputStream = Substitute.For<TextWriter>();
            }

            private object GetSecondPlayerName()
            {
                var firstPlayerText = outputStream.ReceivedCalls().Skip(1).First().GetArguments().First().ToString();
                return firstPlayerText[firstPlayerText.Length - 2];
            }

            private string WinningPlayerMessage()
            {
                return string.Format("\nthe winner is : player {0}\n", GetSecondPlayerName());
            }

            [Test]
            public void LeftToRightDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "1", "3", "5", "6", "9", "2", "4", "7");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Equals(WinningPlayerMessage())));
            }

            [Test]
            public void RightToLeftDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "3", "2", "5", "1", "7", "9", "4", "6", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Equals(WinningPlayerMessage())));
            }

            [Test]
            public void LeftToRightFirstLine()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "1", "4", "2", "6", "3", "5", "9", "7", "8");
                sut.eval();
                outputStream.Received(1).WriteLine(Arg.Is((string str) => str.Equals(WinningPlayerMessage())));
                Console.Out.WriteLine("WinningPlayerMessage = {0}", WinningPlayerMessage());
            }
        }
    }
}