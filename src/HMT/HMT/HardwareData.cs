namespace HMT {
    using System.Collections.Generic;

    /// <summary>
    /// Hardware Information
    /// </summary>
    public class HardwareData {

        /// <summary>
        /// Hardware Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hardware Property List
        /// </summary>
        public List<HardwareDataProperty> Properties { get; set; }

        /// <summary>
        /// Hardware
        /// </summary>
        public HardwareData() {

            // Initalize
            Properties = new List<HardwareDataProperty>();
        }
    }
}