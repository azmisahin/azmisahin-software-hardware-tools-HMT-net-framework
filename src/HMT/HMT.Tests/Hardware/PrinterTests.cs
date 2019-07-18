namespace HMT.Hardware.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class PrinterTests {
        [TestMethod()]
        public void PrinterTest() {

            // mock
            Mock<Printer> mock = new Mock<Printer>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}