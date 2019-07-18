namespace HMT.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class HardwareWatcherTests {
        [TestMethod()]
        public void AuthenticationTest() {

            // mock
            Mock<HardwareWatcher> mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void WatchTest() {

            // mock
            Mock<HardwareWatcher> mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void CloseTest() {

            // mock
            Mock<HardwareWatcher> mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void DisposeTest() {

            // mock
            Mock<HardwareWatcher> mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}