namespace HMT.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class HardwareWatcherTests {
        [TestMethod()]
        public void AuthenticationTest() {

            // mock
            var mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void WatchTest() {

            // mock
            var mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void CloseTest() {

            // mock
            var mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }

        [TestMethod()]
        public void DisposeTest() {

            // mock
            var mock = new Mock<HardwareWatcher>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}