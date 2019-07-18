namespace HMT {
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;

    /// <summary>
    /// Hardware Adapter
    /// </summary>
    public class HardwareAdapter {

        /// <summary>
        /// Hardware Api Class Name
        /// </summary>
        private string className { get; set; }

        /// <summary>
        /// Hardware Finder
        /// </summary>
        /// <see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobjectsearcher"
        /// <param name="className"></param>
        /// <see cref="https://www.microsoft.com/en-us/download/details.aspx?id=8572"/>
        protected HardwareAdapter(string className) {

            // Set Class Name
            this.className = className;
        }

        /// <summary>
        /// Get Hardware Collection
        /// </summary>
        /// <see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobjectcollection"/>
        /// <see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobject"/>
        /// <param name="hardwareName">Hardware Name</param>
        /// <returns>IEnumerable<ManagementObject></returns>
        protected IEnumerable<ManagementObject> HardwareCollection {

            // Get Collection
            get {

                // see cref="https://docs.microsoft.com/tr-tr/windows/win32/cimwin32prov/computer-system-hardware-classes"
                string query = $"SELECT * FROM {className}";

                // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobjectsearcher"
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);

                // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobjectsearcher.get"
                ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

                // see cref="https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/concepts/linq/"
                IEnumerable<ManagementObject> result = from ManagementObject item in managementObjectCollection
                                                       select item;

                // IEnumerable<ManagementObject>
                return result;
            }
        }

        /// <summary>
        /// Get Hardware List
        /// </summary>
        /// <param name="hardwareName"></param>
        /// <returns>List<HardwareData></returns>
        public List<HardwareData> Hardwares {

            // Get Hardwares
            get {
                // Hardware Data List Define
                List<HardwareData> hardwareDataList = new List<HardwareData>();

                // Hardware Collection List
                IEnumerable<ManagementObject> hardwareCollection = HardwareCollection;

                // Hardware Collection Scan
                foreach (ManagementObject hardwareObject in hardwareCollection) {
                    // Haedware Data Define
                    HardwareData hardwareData = new HardwareData();

                    // Hardware Object Properties Scan
                    foreach (PropertyData propertyData in hardwareObject.Properties) {
                        // Hardware Data Property Define
                        HardwareDataProperty property = new HardwareDataProperty {

                            // Set Property Name
                            Name = propertyData.Name,

                            // Set Property Value
                            Value = propertyData.Value
                        };

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
        }
    }
}