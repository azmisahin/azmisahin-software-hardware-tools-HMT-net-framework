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
        protected IEnumerable<ManagementObject> GetHardwareCollection() {

            // see cref="https://docs.microsoft.com/tr-tr/windows/win32/cimwin32prov/computer-system-hardware-classes"
            string query = $"SELECT * FROM {this.className}";

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobjectsearcher"
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementobjectsearcher.get"
            ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/concepts/linq/"
            var result = from ManagementObject item in managementObjectCollection
                         select item;

            // IEnumerable<ManagementObject>
            return result;
        }
    }
}