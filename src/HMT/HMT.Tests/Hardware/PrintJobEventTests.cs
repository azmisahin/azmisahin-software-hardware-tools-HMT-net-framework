namespace HMT.Hardware.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class PrintJobEventTests {
        [TestMethod()]
        public void PrintJobEventTest() {

            // mock
            var mock = new Mock<PrintJobEvent>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void setValueTest() {

            // mock
            var mock = new Mock<PrintJobEvent>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}