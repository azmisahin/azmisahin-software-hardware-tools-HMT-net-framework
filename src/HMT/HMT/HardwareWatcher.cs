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
        /// Authentication
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="computerName"></param>
        /// <param name="domain"></param>
        public void Authentication(string userName, string password, string computerName, string domain) {

            this.userName = userName;
            this.password = password;
            this.computerName = computerName;
            this.authority = $"ntlmdomain:{domain}";

            // Connection Options
            connectionOptions = new ConnectionOptions();

            connectionOptions.Username = this.userName;
            connectionOptions.Password = this.password;
            connectionOptions.Authority = this.authority;
        }

        /// <summary>
        /// Initalize
        /// </summary>
        private void initalizeWatcher() {

            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/connecting-to-wmi-on-a-remote-computer"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/connecting-to-wmi-remotely-with-c-"
            this.path = $"\\\\{this.computerName}\\root\\CIMV2";

            // Management Path Define
            managementPath = new ManagementPath();
            managementPath.Path = this.path;

            // Management Scope Define
            managementScope = new ManagementScope();
            managementScope.Path = managementPath;

            // Local Connection
            if (connectionOptions != null)
                managementScope.Options = connectionOptions;

            // Query Define
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/--instancecreationevent"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/select-statement-for-event-queries"
            // see cref="https://docs.microsoft.com/en-us/windows/win32/wmisdk/receiving-a-wmi-event"
            //query = $"Select * From__InstanceCreationEvent WITHIN 0.001 WHERE TargetInstance ISA \"{this.className}\" ";
            query = $"Select * From __InstanceOperationEvent Within 1 Where TargetInstance ISA \"{this.className}\" ";

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.wqleventquery"
            // see cref="https://docs.microsoft.com/en-us/dotnet/api/system.management.wqleventquery.withininterval"
            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.wqleventquery.eventclassname"
            //WqlEventQuery wqlEventQuery = new WqlEventQuery(query);

            eventQuery = new EventQuery();
            eventQuery.QueryString = query;

            // Managament Scope Connect
            connectScope();
        }

        /// <summary>
        /// Managament Scope Connect
        /// </summary>
        private void connectScope() {
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
            managementEventWatcher = new ManagementEventWatcher();

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementeventwatcher.scope"
            managementEventWatcher.Scope = managementScope;

            // see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.management.managementeventwatcher.query
            //managementEventWatcher.Query = wqlEventQuery;
            managementEventWatcher.Query = eventQuery;

            // times out watcher.WaitForNextEvent in { interval } seconds
            //managementEventWatcher.Options.Timeout = new TimeSpan(interval);

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
        /// <see cref="https://docs.microsoft.com/tr-tr/dotnet/api/system.idisposable.dispose?view=netframework-4.7.1"/>
        public void Dispose() {

            // Close App
            Close();

            // Garbage Clean
            GC.SuppressFinalize(this);
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
        protected virtual void OnSignal(HardwareEvent e) {

            // Signal Hander
            Signal?.Invoke(this, e);
        }

        /// <summary>
        /// Watcher Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManagementEventWatcher_EventArrived(object sender, EventArrivedEventArgs e) {

            // Hardware Event Define
            HardwareEvent hardwareEvent = new HardwareEvent();

            // Hardware Event Set
            hardwareEvent.Base = e;

            // Signal Start
            OnSignal(hardwareEvent);
        }
    }
}