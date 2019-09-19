namespace HMT.Hardware {
    using System;
    using System.Management;

    /// <summary>
    /// Print Job Event
    /// </summary>
    public class PrintJobEvent : HardwareEvent {

        /// <summary>
        /// Caption
        /// </summary>
        /// <return>string</return>
        public string Caption => getStringValue("Caption");

        /// <summary>
        /// Color
        /// </summary>
        /// <return>string</return>
        public string Color => getStringValue("Color");

        /// <summary>
        /// DataType
        /// </summary>
        /// <return>string</return>
        public string DataType => getStringValue("DataType");

        /// <summary>
        /// Description
        /// </summary>
        /// <return>string</return>
        public string Description => getStringValue("Description");

        /// <summary>
        /// Document
        /// </summary>
        /// <return>string</return>
        public string Document => getStringValue("Document");

        /// <summary>
        /// DriverName
        /// </summary>
        /// <return>string</return>
        public string DriverName => getStringValue("DriverName");

        /// <summary>
        /// ElapsedTime
        /// </summary>
        /// <return>DateTime</return>
        public object ElapsedTime => getValue("ElapsedTime");

        /// <summary>
        /// HostPrintQueue
        /// </summary>
        /// <return>string</return>
        public string HostPrintQueue => getStringValue("HostPrintQueue");

        /// <summary>
        /// InstallDate
        /// </summary>
        /// <return>DateTime</return>
        public object InstallDate => getValue("InstallDate");

        /// <summary>
        /// Job ID
        /// </summary>
        /// <return>uint</return>
        public uint JobId => getUint32Value("JobId");

        /// <summary>
        /// string
        /// </summary>
        /// <return>JobStatus</return>
        public string JobStatus => getStringValue("JobStatus");

        /// <summary>
        /// Name
        /// </summary>
        /// <return>string</return>
        public string Name => getStringValue("Name");

        /// <summary>
        /// Notify
        /// </summary>
        /// <return>string</return>
        public string Notify => getStringValue("Notify");

        /// <summary>
        /// Owner
        /// </summary>
        /// <return>string</return>
        public string Owner => getStringValue("Owner");

        /// <summary>
        /// PagesPrinted
        /// </summary>
        /// <return>uint</return>
        public uint PagesPrinted => getUint32Value("PagesPrinted");

        /// <summary>
        /// PaperLength
        /// </summary>
        /// <return>uint</return>
        public uint PaperLength => getUint32Value("PaperLength");

        /// <summary>
        /// PaperSize
        /// </summary>
        /// <return>string</return>
        public string PaperSize => getStringValue("PaperSize");

        /// <summary>
        /// PaperWidth
        /// </summary>
        /// <return>uint</return>
        public uint PaperWidth => getUint32Value("PaperWidth");

        /// <summary>
        /// Parameters
        /// </summary>
        /// <return>string</return>
        public string Parameters => getStringValue("Parameters");

        /// <summary>
        /// PrintProcessor
        /// </summary>
        /// <return>string</return>
        public string PrintProcessor => getStringValue("PrintProcessor");

        /// <summary>
        /// Priority
        /// </summary>
        /// <return>uint</return>
        public uint Priority => getUint32Value("Priority");

        /// <summary>
        /// Size
        /// </summary>
        /// <return>uint</return>
        public uint Size => getUint32Value("Size");

        /// <summary>
        /// SizeHigh
        /// </summary>
        /// <return>uint</return>
        public uint SizeHigh => getUint32Value("SizeHigh");

        /// <summary>
        /// StartTime
        /// </summary>
        /// <return>DateTime</return>
        public object StartTime => getValue("StartTime");

        /// <summary>
        /// Status
        /// </summary>
        /// <return>string</return>
        public string Status { get => getStringValue("Status"); set => setValue("StatusMask", value); }

        /// <summary>
        /// StatusMask
        /// </summary>
        /// <return>uint</return>
        public uint StatusMask { get => getUint32Value("StatusMask"); set => setValue("StatusMask", value); }

        /// <summary>
        /// TimeSubmitted
        /// </summary>
        /// <return>DateTime</return>
        public object TimeSubmitted => getValue("TimeSubmitted");

        /// <summary>
        /// TotalPages
        /// </summary>
        /// <return>uint</return>
        public uint TotalPages => getUint32Value("TotalPages");

        /// <summary>
        /// UntilTime
        /// </summary>
        /// <return>DateTime</return>
        public object UntilTime => getValue("UntilTime");

        /// <summary>
        /// Get Event Value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object getValue(string propertyName) {

            // Return
            object result;

            // Properties
            ManagementBaseObject properties = (ManagementBaseObject)Base.NewEvent.Properties["TargetInstance"].Value;

            // Try Set Return
            try {
                result = properties[propertyName];
            }
            catch (Exception) {
                result = null;
            }
            // Return result
            return result;
        }

        /// <summary>
        /// Get String Value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private string getStringValue(string propertyName) {

            // Return
            string result;
            try {
                // Get Value
                object field = getValue(propertyName);

                // Result
                result = (string)field;
            }
            catch (Exception) {
                result = "";
            }
            return result;
        }

        /// <summary>
        /// Get Uint Value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private uint getUint32Value(string propertyName) {

            // Return
            uint result;

            try {
                result = (uint)getValue(propertyName);

            }
            catch (Exception) {
                result = 0;
            }

            return result;
        }

        /// <summary>
        /// Status Flags
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-printjob"/>
        public enum StatusFlag {

            /// <summary>
            /// Paused
            /// </summary>
            Paused = 0x1,

            /// <summary>
            /// Error
            /// </summary>
            Error = 0x2,

            /// <summary>
            /// Deleting
            /// </summary>
            Deleting = 0x4,

            /// <summary>
            /// Spooling
            /// </summary>
            Spooling = 0x8,

            /// <summary>
            /// Printing
            /// </summary>
            Printing = 0x10,

            /// <summary>
            /// Offline
            /// </summary>
            Offline = 0x20,

            /// <summary>
            /// Paperout
            /// </summary>
            Paperout = 0x40,

            /// <summary>
            /// Printed
            /// </summary>
            Printed = 0x80,

            /// <summary>
            /// Deleted
            /// </summary>
            Deleted = 0x100,

            /// <summary>
            /// Blocked
            /// </summary>
            Blocked_DevQ = 0x200,

            /// <summary>
            /// User Intervention
            /// </summary>
            User_Intervention_Req = 0x400,

            /// <summary>
            /// Restart
            /// </summary>
            Restart = 0x800,

            /// <summary>
            ///  Idled
            /// </summary>
            Idled = 8192,

            /// <summary>
            /// Continue ?
            /// </summary>
            Continue = 8216,

            /// <summary>
            /// Finalize ?
            /// </summary>
            Finalize = 8208
        }

        /// <summary>
        /// Status Flag
        /// </summary>
        public StatusFlag Flag {

            get => (StatusFlag)StatusMask;

            set => StatusMask = (uint)value;
        }

        /// <summary>
        /// Set a Value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void setValue(string propertyName, object value) {

            // Properties
            ManagementBaseObject properties = (ManagementBaseObject)Base.NewEvent.Properties["TargetInstance"].Value;

            // Try Set Return
            try {
                properties[propertyName] = value;
            }
            catch (Exception) {

            }
        }
    }
}