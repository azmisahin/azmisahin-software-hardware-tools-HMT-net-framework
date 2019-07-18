namespace HMT.Hardware {
    /// <summary>
    /// Printer Hardware Components
    /// </summary>
    public class Printer : HardwareComponent {

        /// <summary>
        /// Hardware Finder
        /// </summary>
        public HardwareFinder Finder { get; set; }

        /// <summary>
        /// Protected
        /// </summary>
        public Printer() : base("Win32_Printer") {

            // Set Finder
            Finder = new HardwareFinder("Win32_Printer");
        }
    }
}