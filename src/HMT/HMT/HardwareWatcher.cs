namespace HMT {
    using System;
    using System.Management;

    /// <summary>
    /// Hardware Watcher Authentication
    /// </summary>
    public class HardwareWatcher : IDisposable {

        /// <summary>
        /// User Name
        /// </summary>
        private string userName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        private string password { get; set; }

        /// <summary>
        /// Authority
        /// </summary>
        private string authority { get; set; }

        /// <summary>
        /// Computer Name
        /// </summary>
        private string computerName { get; set; } = ".";

        /// <summary>
        /// Domain Name Or Workgroup Name
        /// </summary>
        private string domainName { get; set; }

        /// <summary>
        /// Class Query
        /// </summary>
        private string query { get; set; }

        /// <summary>
        /// Path
        /// </summary>
        private string path { get; set; }

        /// <summary>
        /// Management Event Watcher
        /// </summary>
        private ManagementEventWatcher managementEventWatcher { get; set; }

        /// <summary>
        /// Management Scope
        /// </summary>
        private ManagementScope managementScope { get; set; }

        /// <summary>
        /// Connection Options
        /// </summary>
        private ConnectionOptions connectionOptions { get; set; }

        /// <summary>
        /// Management Path
        /// </summary>
        private ManagementPath managementPath { get; set; }

        /// <summary>
        /// Event Query
        /// </summary>
        private EventQuery eventQuery { get; set; }

        /// <summary>
        /// Hardware Api Class Name
        /// </summary>
        private string className { get; set; }

        /// <summary>
        ///  Hardware Watcher
        /// </summary>
        /// <param name="className"></param>
        /// <see cref="https://www.microsoft.com/en-us/download/details.aspx?id=8572"/>
        internal HardwareWatcher(string className) {

            // Set Class Name
            this.className = className;

            // Connection Options
            connectionOptions = null;
        }

        /// <summary>
        /// Is Authentication
        /// </summary>
        public bool isAuthentication => (
                    string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(computerName) ||
                    string.IsNullOrEmpty(computerName)
                    ) && true ? false : true;

        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="computerName"></param>
        /// <param name="domain"></param>
        public bool Authentication(string userName, string password, string computerName, string domain) {

            this.userName = userName;
            this.password = password;
            this.computerName = computerName;
            domainName = domain;
            authority = $"ntlmdomain:{domainName}";

            // Connection Options
            connectionOptions = new ConnectionOptions {
                Username = this.userName,
                Password = this.password,
                Authority = authority
            };

            return isAuthentication;
        }

        /// <summary>
        /// Initalize
        /// </summary>
        private void initalizeWatcher() {

            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/connecting-to-wmi-on-a-remote-computer"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/connecting-to-wmi-remotely-with-c-"
            path = $"\\\\{computerName}\\root\\CIMV2";

            // Management Path Define
            managementPath = new ManagementPath {
                Path = path
            };

            // Management Scope Define
            managementScope = new ManagementScope {
                Path = managementPath
            };

            // Local Connection
            if (connectionOptions != null) {
                managementScope.Options = connectionOptions;
            }

            // Query Define
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/--instancecreationevent"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/select-statement-for-event-queries"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/receiving-a-wmi-event"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/within-clause"
            query = $"Select * From __InstanceOperationEvent Within 0.001 Where TargetInstance ISA \"{className}\" ";
            // query = $"Select * From __InstanceOperationEvent Within 1 Where TargetInstance ISA \"{className}\" ";

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.wqleventquery"
            // see cref="https://docs.microsoft.com/en-us/dotnet/api/system.management.wqleventquery.withininterval"
            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.wqleventquery.eventclassname"
            //WqlEventQuery wqlEventQuery = new WqlEventQuery(query);

            eventQuery = new EventQuery {
                QueryString = query
            };

            // Managament Scope Connect
            connectScope();
        }

        /// <summary>
        /// Managament Scope Connect
        /// </summary>
        private void connectScope() {

            // Connect
            managementScope.Connect();
        }

        /// <summary>
        /// Watcher
        /// </summary>
        /// <param name="interval"></param>
        public void Watch(long interval = 1) {

            // Initalize Watcher
            initalizeWatcher();

            // Watcher Define and Set
            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementeventwatcher"
            managementEventWatcher = new ManagementEventWatcher {

                // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementeventwatcher.scope"
                Scope = managementScope,

                // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementeventwatcher.query
                //managementEventWatcher.Query = wqlEventQuery;
                Query = eventQuery
            };

            // times out watcher.WaitForNextEvent in { interval } seconds
            managementEventWatcher.Options.Timeout = new TimeSpan(interval);

            // Watcher Event
            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.eventarrivedeventargs"
            managementEventWatcher.EventArrived += ManagementEventWatcher_EventArrived;

            // Starting hardware monitor.
            managementEventWatcher.Start();
        }

        /// <summary>
        /// Watcher Close
        /// </summary>
        public void Close() {

            // Close Dispose
            if (managementEventWatcher != null) {

                // Unregister Event
                // see cref="https://docs.microsoft.com/tr-tr/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events"
                managementEventWatcher.EventArrived -= ManagementEventWatcher_EventArrived;
                managementEventWatcher.Stop();
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.idisposable.dispose"/>
        public void Dispose() {

            // Dispose
            Dispose(true);

            // Garbage Clean
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposed
        /// </summary>
        private bool disposed;

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) {

            // Disposed Control
            if (disposed) {
                return;
            }

            if (disposing) {

                // Close App
                Close();
            }

            disposed = true;
        }

        /// <summary>
        /// Signal Event Hander
        /// </summary>
        /// <see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.eventhandler"/>
        public event EventHandler<HardwareEvent> Signal;

        /// <summary>
        /// Signal On
        /// </summary>
        /// <param name="e">Hardware Event</param>
        protected virtual void OnSignal(object sender, HardwareEvent hardwareEvent) {

            // Signal Handler
            Signal?.Invoke(this, hardwareEvent);
        }

        /// <summary>
        /// Watcher Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagementEventWatcher_EventArrived(object sender, EventArrivedEventArgs eventArrivedEventArgs) {

            // Hardware Event Define
            HardwareEvent hardwareEvent = new HardwareEvent {

                // Hardware Event Set
                Base = eventArrivedEventArgs
            };

            // Signal Start
            OnSignal(sender, hardwareEvent);
        }
    }
}