using System.IO;
using legacytictactoe;
using NSubstitute;
using NUnit.Framework;

namespace TicTacToe.Tests
{
    public class TicTacToeSpecs
    {
        public Tic CreateSUT()
        {
            var inputStream = Substitute.For<TextReader>();

            inputStream.ReadLine().Returns("1", "3", "5", "6", "9", "2", "4", "7", "8");
            return new Tic(inputStream);
        }


        [TestFixture]
        public class When_TicTacToeSpecs : TicTacToeSpecs
        {
            [Test]
            public void Should_Behavior()
            {
                var sut = CreateSUT();
                sut.eval();
            }
        }
    }
}