using System.IO;
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

            [Test]
            public void LeftToRightDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "3", "5", "6", "9", "2", "4", "7", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Contains("the winner is :")));
            }

            [Test]
            public void RightToLeftDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("3", "2", "5", "1", "7", "9", "4", "6", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Contains("the winner is :")));
            }

            [Test]
            public void LeftToRightFirstLine()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("1", "4", "2", "6", "3", "5", "9", "7", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Contains("the winner is :")));
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

            [Test]
            public void LeftToRightDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "1", "3", "5", "6", "9", "2", "4", "7");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Contains("the winner is :")));
            }

            [Test]
            public void RightToLeftDiagonal()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "3", "2", "5", "1", "7", "9", "4", "6", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Contains("the winner is :")));
            }

            [Test]
            public void LeftToRightFirstLine()
            {
                var sut = CreateSUT();
                inputStream.ReadLine().Returns("8", "1", "4", "2", "6", "3", "5", "9", "7", "8");
                sut.eval();
                outputStream.Received().WriteLine(Arg.Is((string str) => str.Contains("the winner is :")));
            }
        }
    }
}