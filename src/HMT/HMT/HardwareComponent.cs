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
        /// Hardware Component
        /// </summary>
        protected HardwareComponent(string className) {

            // Set Class Name
            this.className = className;
        }
    }
}