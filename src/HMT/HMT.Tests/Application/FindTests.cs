namespace HMT.Tests.Application {
    using System;
    using System.Collections.Generic;
    using HMT.Hardware;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class FindTests {

        /// <summary>
        /// Printer Hardware
        /// </summary>
        private Printer hardware;

        [TestMethod]
        public void HardwareFindListTest() {

            // Job Initalize
            hardware = new Printer();

            // Get All Hardware
            List<HardwareData> hardwares = hardware
                .Finder
                .Hardwares;

            // Hardware List 
            foreach (HardwareData item in hardwares) {

                // Print Hardware
                Console.WriteLine($"Name : {item.Name}");
            }
        }

        [TestMethod]
        public void HardwareFindListWithPropertyTest() {

            // Job Initalize
            hardware = new Printer();

            // Get All Hardware
            List<HardwareData> hardwares = hardware
                .Finder
                .Hardwares;

            // Hardware List 
            foreach (HardwareData item in hardwares) {

                // Print Hardware
                Console.WriteLine($"Name : {item.Name}");

                // Print Hardware Property List
                foreach (HardwareDataProperty property in item.Properties) {
                    if (property.Value != null) {
                        Console.WriteLine($"    >   {property.Name}\t|{property.Value}");
                    }
                }
            }
        }
    }
}
