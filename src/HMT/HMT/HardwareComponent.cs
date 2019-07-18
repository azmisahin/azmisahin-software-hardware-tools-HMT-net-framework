namespace HMT {
    /// <summary>
    /// Component
    /// </summary>
    public class HardwareComponent {

        /// <summary>
        /// Hardware Api Class Name
        /// </summary>
        private string className { get; set; }

        /// <summary>
        /// Hardware Finder
        /// </summary>
        public HardwareFinder Finder { get; set; }

        /// <summary>
        /// Hardware Watcher
        /// </summary>
        public HardwareWatcher Watcher { get; set; }

        /// <summary>
        /// Hardware Component
        /// </summary>
        protected HardwareComponent(string className) {

            // Set Class Name
            this.className = className;

            // Set Finder
            Finder = new HardwareFinder(className);

            // Set Watcher
            Watcher = new HardwareWatcher(className);
        }
    }
}