﻿namespace HMT.Tests {
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass()]
    public class HardwareDataTests {
        [TestMethod()]
        public void HardwareDataTest() {

            // mock
            var mock = new Mock<HardwareData>();

            // Test
            Assert.IsNotNull(mock);
        }
    }
}