namespace HMT.Hardware {
    /// <summary>
    /// Printer Hardware Components
    /// </summary>
    public class Printer : HardwareComponent {

        /// <summary>
        /// Protected
        /// </summary>
        public Printer() : base("Win32_Printer") { }
    }
}