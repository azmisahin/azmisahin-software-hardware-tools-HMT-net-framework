namespace HMT.Tests {
    using System.Threading;
    using System.Threading.Tasks;
    using HMT.Hardware;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WatchTests {

        /// <summary>
        /// Printer Job Hardware
        /// </summary>
        private PrinterJob hardware;

        [TestMethod]
        public void HardwareWatchTest() {

            // Job Initalize
            hardware = new PrinterJob();

            // Signal Setup
            hardware
                .Signal += Hardware_Signal;

            // Signal Start
            hardware
                .Watcher
                .Watch();
        }

        /// <summary>
        /// Hardware Signal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Hardware_Signal(object sender, PrintJobEvent e) {

            #region Define Event Data

            // Job Status       [ For example: Spooling ] 
            string stringJobStatus = $"{e.JobStatus}";

            // Priority         [ For example: 1 ] 
            string stringPriority = $"{e.Priority}";

            // Document         [ For example: test.pdf ]
            string stringDocument = $"{e.Document}";

            // User             [ For example: Jack     ]
            string stringUser = $"{e.Owner}";

            // Host             [ For example: desktop-computer-100 ]
            string stringHost = $"{e.HostPrintQueue}";

            // JobId            [ For example: 50 ] This day print count
            string stringJobId = $"{e.JobId}";

            // Total Pages      [ For example: 5 ] Print document pages count
            string stringTotalPages = $"{e.TotalPages}";

            // TimeSubmitted    [ For example: 201907181459 ] Print send datetime
            string stringTimeSubmitted = $"{e.TimeSubmitted}";

            #endregion

            #region Write Message
            System.Console.WriteLine
                       ($"" +
                       $"Flag           :   {e.Flag} \n" +
                       $"Job Status     :   {stringJobStatus} \n" +
                       $"Priorty        :   {stringPriority} \n" +
                       $"Document       :   {stringDocument} \n" +
                       $"User           :   {stringUser} \n" +
                       $"Host           :   {stringHost} \n" +
                       $"JobId          :   {stringJobId} \n" +
                       $"Total Pages    :   {stringTotalPages} \n" +
                       $"Time Submitted :   {stringTimeSubmitted} \n");
            #endregion

            #region Check Signal Flag
            switch (e.Flag) {
                case PrintJobEvent.StatusFlag.Paused:
                    break;
                case PrintJobEvent.StatusFlag.Error:
                    break;
                case PrintJobEvent.StatusFlag.Deleting:
                    break;
                case PrintJobEvent.StatusFlag.Spooling:
                    break;
                case PrintJobEvent.StatusFlag.Printing:
                    break;
                case PrintJobEvent.StatusFlag.Offline:
                    break;
                case PrintJobEvent.StatusFlag.Paperout:
                    break;
                case PrintJobEvent.StatusFlag.Printed:
                    break;
                case PrintJobEvent.StatusFlag.Deleted:
                    break;
                case PrintJobEvent.StatusFlag.Blocked_DevQ:
                    break;
                case PrintJobEvent.StatusFlag.User_Intervention_Req:
                    break;
                case PrintJobEvent.StatusFlag.Restart:
                    break;
                case PrintJobEvent.StatusFlag.Continue: // Signal CONTINUE
                    break;
                case PrintJobEvent.StatusFlag.Finalize: // Signal END
                    break;
                default:                                // Signal START
                    if (e.StatusMask == 0 && e.TotalPages == 0) {
                        // First data
                    }
                    break;
            }
            #endregion

            #region Run Other Task Trigger
            await SendAsync(e.Flag);
            #endregion
        }

        /// <summary>
        /// Any Task
        /// </summary>
        private async Task SendAsync(object arg) {

            // Run
            await Task.Run(() => {
                System.Console.WriteLine($"Run {Thread.CurrentThread.ManagedThreadId} Thread With {arg} argument");
            });
        }
    }
}
