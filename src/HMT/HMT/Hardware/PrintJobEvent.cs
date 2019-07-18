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
        public string Caption { get { return getStringValue("Caption"); } }

        /// <summary>
        /// Color
        /// </summary>
        /// <return>string</return>
        public string Color { get { return getStringValue("Color"); } }

        /// <summary>
        /// DataType
        /// </summary>
        /// <return>string</return>
        public string DataType { get { return getStringValue("DataType"); } }

        /// <summary>
        /// Description
        /// </summary>
        /// <return>string</return>
        public string Description { get { return getStringValue("Description"); } }

        /// <summary>
        /// Document
        /// </summary>
        /// <return>string</return>
        public string Document { get { return getStringValue("Document"); } }

        /// <summary>
        /// DriverName
        /// </summary>
        /// <return>string</return>
        public string DriverName { get { return getStringValue("DriverName"); } }

        /// <summary>
        /// ElapsedTime
        /// </summary>
        /// <return>DateTime</return>
        public object ElapsedTime { get { return getValue("ElapsedTime"); } }

        /// <summary>
        /// HostPrintQueue
        /// </summary>
        /// <return>string</return>
        public string HostPrintQueue { get { return getStringValue("HostPrintQueue"); } }

        /// <summary>
        /// InstallDate
        /// </summary>
        /// <return>DateTime</return>
        public object InstallDate { get { return getValue("InstallDate"); } }

        /// <summary>
        /// Job ID
        /// </summary>
        /// <return>uint</return>
        public UInt32 JobId { get { return getUint32Value("JobId"); } }

        /// <summary>
        /// string
        /// </summary>
        /// <return>JobStatus</return>
        public string JobStatus { get { return getStringValue("JobStatus"); } }

        /// <summary>
        /// Name
        /// </summary>
        /// <return>string</return>
        public string Name { get { return getStringValue("Name"); } }

        /// <summary>
        /// Notify
        /// </summary>
        /// <return>string</return>
        public string Notify { get { return getStringValue("Notify"); } }

        /// <summary>
        /// Owner
        /// </summary>
        /// <return>string</return>
        public string Owner { get { return getStringValue("Owner"); } }

        /// <summary>
        /// PagesPrinted
        /// </summary>
        /// <return>uint</return>
        public UInt32 PagesPrinted { get { return getUint32Value("PagesPrinted"); } }

        /// <summary>
        /// PaperLength
        /// </summary>
        /// <return>uint</return>
        public UInt32 PaperLength { get { return getUint32Value("PaperLength"); } }

        /// <summary>
        /// PaperSize
        /// </summary>
        /// <return>string</return>
        public string PaperSize { get { return getStringValue("PaperSize"); } }

        /// <summary>
        /// PaperWidth
        /// </summary>
        /// <return>uint</return>
        public UInt32 PaperWidth { get { return getUint32Value("PaperWidth"); } }

        /// <summary>
        /// Parameters
        /// </summary>
        /// <return>string</return>
        public string Parameters { get { return getStringValue("Parameters"); } }

        /// <summary>
        /// PrintProcessor
        /// </summary>
        /// <return>string</return>
        public string PrintProcessor { get { return getStringValue("PrintProcessor"); } }

        /// <summary>
        /// Priority
        /// </summary>
        /// <return>uint</return>
        public UInt32 Priority { get { return getUint32Value("Priority"); } }

        /// <summary>
        /// Size
        /// </summary>
        /// <return>uint</return>
        public UInt32 Size { get { return getUint32Value("Size"); } }

        /// <summary>
        /// SizeHigh
        /// </summary>
        /// <return>uint</return>
        public UInt32 SizeHigh { get { return getUint32Value("SizeHigh"); } }

        /// <summary>
        /// StartTime
        /// </summary>
        /// <return>DateTime</return>
        public object StartTime { get { return getValue("StartTime"); } }

        /// <summary>
        /// Status
        /// </summary>
        /// <return>string</return>
        public string Status { get { return getStringValue("Status"); } set { setValue("StatusMask", value); } }

        /// <summary>
        /// StatusMask
        /// </summary>
        /// <return>uint</return>
        public UInt32 StatusMask { get { return getUint32Value("StatusMask"); } set { setValue("StatusMask", value); } }

        /// <summary>
        /// TimeSubmitted
        /// </summary>
        /// <return>DateTime</return>
        public object TimeSubmitted { get { return getValue("TimeSubmitted"); } }

        /// <summary>
        /// TotalPages
        /// </summary>
        /// <return>uint</return>
        public UInt32 TotalPages { get { return getUint32Value("TotalPages"); } }

        /// <summary>
        /// UntilTime
        /// </summary>
        /// <return>DateTime</return>
        public object UntilTime { get { return getValue("UntilTime"); } }

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
                var field = getValue(propertyName);
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
        private UInt32 getUint32Value(string propertyName) {

            // Return
            UInt32 result;

            try {
                result = (UInt32)getValue(propertyName);

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

            get {
                return (StatusFlag)StatusMask;
            }

            set {
                StatusMask = (uint)value;
            }
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