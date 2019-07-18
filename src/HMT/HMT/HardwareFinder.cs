namespace HMT {
    using System.Collections.Generic;
    using System.Management;
    using System.Linq;

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
        /// Get Hardware List
        /// </summary>
        /// <param name="hardwareName"></param>
        /// <returns>List<HardwareData></returns>
        public List<HardwareData> GetHardwares() {
            // Hardware Data List Define
            List<HardwareData> hardwareDataList = new List<HardwareData>();

            // Hardware Collection List
            IEnumerable<ManagementObject> hardwareCollection = GetHardwareCollection();

            // Hardware Collection Scan
            foreach (ManagementObject hardwareObject in hardwareCollection) {
                // Haedware Data Define
                HardwareData hardwareData = new HardwareData();

                // Hardware Object Properties Scan
                foreach (PropertyData propertyData in hardwareObject.Properties) {
                    // Hardware Data Property Define
                    HardwareDataProperty property = new HardwareDataProperty();

                    // Set Property Name
                    property.Name = propertyData.Name;

                    // Set Property Value
                    property.Value = propertyData.Value;

                    // Add Hardware Data Add
                    hardwareData.Properties.Add(property);
                }

                // Set Adapter
                hardwareData.Name = (from HardwareDataProperty item in hardwareData.Properties
                                     where item.Name == "Name"
                                     select item.Value).FirstOrDefault().ToString();

                // Hardware Data List Add
                hardwareDataList.Add(hardwareData);
            }

            // Return All Hardware Data List
            return hardwareDataList;
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
            result = (from HardwareData item in GetHardwares()
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
            IEnumerable<ManagementObject> hardwareCollection = GetHardwareCollection();

            // Hardware Collection Scan
            foreach (ManagementObject hardwareObject in hardwareCollection) {

                // Hardware Object Properties Scan
                foreach (PropertyData propertyData in hardwareObject.Properties) {
                    // Set Property Name
                    var Name = propertyData.Name;

                    // Set Property Value
                    var Value = propertyData.Value;
                }

                // Execute Method
                result = hardwareObject.InvokeMethod(methodName, args);
            }

            // Return
            return result;
        }
    }
}