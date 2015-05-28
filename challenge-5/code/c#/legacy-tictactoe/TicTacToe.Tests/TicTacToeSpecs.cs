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

            [Test]
            public void LeftToRightDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "3", "5", "6", "9", "2", "4", "7", "8");

                sut.eval();
                outputStream.Received()
                    .WriteLine(Arg.Is((string str) => str.Contains("the winner is : player " + GetFirstPlayerName())));
                outputStream.Write(Arg.Any<string>());
            }

            [Test]
            public void RightToLeftDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("3", "2", "5", "1", "7", "9", "4", "6", "8");
                sut.eval();
                outputStream.Received()
                    .WriteLine(Arg.Is((string str) => str.Contains("the winner is : player " + GetFirstPlayerName())));
            }

            [Test]
            public void LeftToRightFirstLine()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "4", "2", "6", "3", "5", "9", "7", "8");
                sut.eval();
                outputStream.Received()
                    .WriteLine(Arg.Is((string str) => str.Contains("the winner is : player " + GetFirstPlayerName())));
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

            [Test]
            public void LeftToRightDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "1", "3", "5", "6", "9", "2", "4", "7");
                sut.eval();
                outputStream.Received()
                    .WriteLine(Arg.Is((string str) => str.Contains("the winner is : player " + GetSecondPlayerName())));
            }

            [Test]
            public void RightToLeftDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "3", "2", "5", "1", "7", "9", "4", "6", "8");
                sut.eval();
                outputStream.Received()
                    .WriteLine(Arg.Is((string str) => str.Contains("the winner is : player " + GetSecondPlayerName())));
            }

            [Test]
            public void LeftToRightFirstLine()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "1", "4", "2", "6", "3", "5", "9", "7", "8");
                sut.eval();
                outputStream.Received()
                    .WriteLine(Arg.Is((string str) => str.Contains("the winner is : player " + GetSecondPlayerName())));
            }
        }
    }
}