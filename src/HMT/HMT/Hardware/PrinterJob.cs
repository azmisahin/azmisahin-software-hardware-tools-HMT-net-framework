namespace HMT.Hardware {
    using System;

    /// <summary>
    /// PrinterJob Hardware Components
    /// </summary>
    public class PrinterJob : HardwareComponent {

        /// <summary>
        /// Hardware Watcher
        /// </summary>
        public HardwareWatcher Watcher { get; set; }

        /// <summary>
        /// Protected
        /// </summary>
        public PrinterJob() : base("Win32_PrintJob") {

            // Set Watcher
            Watcher = new HardwareWatcher("Win32_PrintJob");

            // Base Watcher
            Watcher
                .Signal += Watcher_Signal;
        }

        /// <summary>
        /// Watcher Signal Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_Signal(object sender, HardwareEvent hardwareEvent) {

            // Print Job Event
            PrintJobEvent printJobEvent = new PrintJobEvent {

                // Set Data
                Base = hardwareEvent.Base
            };

            // Signal Start
            OnSignal(sender, printJobEvent);
        }

        /// <summary>
        /// Print Job Event
        /// </summary>
        public event EventHandler<PrintJobEvent> Signal;

        /// <summary>
        /// Print Job Event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSignal(object sender, PrintJobEvent printJobEvent) {

            // Signal Handler
            Signal?.Invoke(this, printJobEvent);
        }
    }
}