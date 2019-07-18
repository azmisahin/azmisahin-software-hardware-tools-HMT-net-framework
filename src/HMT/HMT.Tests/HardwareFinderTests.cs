namespace HMT.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class HardwareFinderTests {
        [TestMethod()]
        public void GetHardwareTest() {
            // mock
            Mock<HardwareFinder> mock = new Mock<HardwareFinder>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void ExecuteTest() {
            // mock
            Mock<HardwareFinder> mock = new Mock<HardwareFinder>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}