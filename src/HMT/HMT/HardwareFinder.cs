namespace HMT {
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;

    /// <summary>
    /// Hardware Finder
    /// </summary>
    public class HardwareFinder : HardwareAdapter {

        /// <summary>
        /// Hardware Api Class Name
        /// </summary>
        private string className { get; set; }

        /// <summary>
        /// Hardware Adapter
        /// </summary>
        internal HardwareFinder(string className) : base(className) {
            // Set Class Name
            this.className = className;
        }

        /// <summary>
        /// Get Hardware
        /// </summary>
        /// <param name="hardwareName"></param>
        /// <returns></returns>
        public HardwareData GetHardware(string hardwareName) {

            // Define Hardware Data
            HardwareData result;

            // Select Hardware
            result = (from HardwareData item in Hardwares
                      where item.Name == hardwareName
                      select item).FirstOrDefault();

            // return Hardware Data
            return result;
        }

        /// <summary>
        /// Execute Hardware Method
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Execute(string methodName, object[] args = null) {

            // Result
            object result = null;

            // Hardware Collection List
            IEnumerable<ManagementObject> hardwareCollection = HardwareCollection;

            // Hardware Collection Scan
            foreach (ManagementObject hardwareObject in hardwareCollection) {

                // Hardware Object Properties Scan
                foreach (PropertyData propertyData in hardwareObject.Properties) {

                    // Set Property Name
                    string Name = propertyData.Name;

                    // Set Property Value
                    object Value = propertyData.Value;
                }

                // Execute Method
                result = hardwareObject.InvokeMethod(methodName, args);
            }

            // Return
            return result;
        }
    }
}