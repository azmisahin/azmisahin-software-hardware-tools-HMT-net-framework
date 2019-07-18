namespace HMT.Hardware {
    using System;

    /// <summary>
    /// PrinterJob Hardware Components
    /// </summary>
    public class PrinterJob : HardwareComponent {

        /// <summary>
        /// Protected
        /// </summary>
        public PrinterJob() : base("Win32_PrintJob") {

            // Base Watcher
            this
                .Watcher
                .Signal += Watcher_Signal;
        }

        /// <summary>
        /// Watcher Signal Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Watcher_Signal(object sender, HardwareEvent e) {

            // Print Job Event
            PrintJobEvent printJobEvent = new PrintJobEvent();

            // Set Data
            printJobEvent.Base = e.Base;

            // Signal Start
            OnSignal(printJobEvent);
        }

        /// <summary>
        /// Print Job Event
        /// </summary>
        public event EventHandler<PrintJobEvent> Signal;

        /// <summary>
        /// Print Job Event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSignal(PrintJobEvent e) {

            // Signal Handler
            Signal?.Invoke(this, e);
        }
    }
}