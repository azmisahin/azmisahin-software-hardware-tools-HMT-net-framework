namespace HMT.Hardware.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class PrinterJobTests {
        [TestMethod()]
        public void PrinterJobTest() {

            // mock
            Mock<PrinterJob> mock = new Mock<PrinterJob>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}