namespace HMT.Hardware.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class PrinterTests {
        [TestMethod()]
        public void PrinterTest() {

            // mock
            var mock = new Mock<Printer>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}