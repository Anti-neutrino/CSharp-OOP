namespace Computers.Tests
{
    using System;
    using Computers.Logic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class SquareNumberTests
    {
        [TestMethod]
        public void SquareNumberShouldOutputCorrectNumbers()
        {
            var cpu = new Cpu32(4);
            var motherBoard = new Mock<IMotherBoard>();
            motherBoard.Setup(x => x.LoadRamValue()).Returns(123);
            cpu.AttachTo(motherBoard.Object);
            cpu.SquareNumber();
            motherBoard.Verify(x => x.DrawOnVideoCard(It.Is<string>(param => param.Contains("15129"))));
        }

        [TestMethod]
        public void SquareNumberShouldDrawErrorMessageZero()
        {
            var cpu = new Cpu32(4);
            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(-1);
            cpu.AttachTo(motherBoardMock.Object);
            cpu.SquareNumber();
            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(param => param == Cpu.NumberToLow)));
        }

        [TestMethod]
        public void SquareNumberShouldReturnErrorMessageGreater()
        {
            var cpu = new Cpu32(4);
            var motherBoardMock = new Mock<IMotherBoard>();
            motherBoardMock.Setup(x => x.LoadRamValue()).Returns(501);
            cpu.AttachTo(motherBoardMock.Object);
            cpu.SquareNumber();
            motherBoardMock.Verify(x => x.DrawOnVideoCard(It.Is<string>(param => param == Cpu.NumberToHigh)));
        }
    }
}
