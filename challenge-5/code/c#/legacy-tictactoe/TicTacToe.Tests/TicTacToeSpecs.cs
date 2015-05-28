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
        }
    }
}