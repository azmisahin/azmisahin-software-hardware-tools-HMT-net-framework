# ![Logo](media/favicon.png)

# Hardware Management Tool

A management tool that provides easy access to hardware interfaces to automate management tasks on local or remote computers.

IT managers and System Specialists; provides fast and practical solutions for monitoring, reporting and auditing critical operations.

Basically, the application interface toolkit that targets windows devices plans to support other operating systems such as linux and macos in the future.

## Usage

> Watch Example

```cs
    using System.Threading;
    using System.Threading.Tasks;
    using HMT.Hardware;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                Console
                .WriteLine(
                    $"Run {Thread.CurrentThread.ManagedThreadId} Thread" +
                    $"With {arg} argument");
            });
        }
    }
```
> Authentication Example

```cs
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using HMT.Hardware;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthenticationTest {

        /// <summary>
        /// Printer Job Hardware
        /// </summary>
        private PrinterJob hardware;

        [TestMethod]
        public void HardwareWatchAuthenticationTest() {

            // Job Initalize
            hardware = new PrinterJob();

            // Hardware Watch Authentication
            hardwareWatchAuthentication();

            // Signal Setup
            hardware
                .Signal += Hardware_Signal;

            // Check Authentication
            if (hardware.Watcher.isAuthentication) {
                // Signal Start
                hardware
                    .Watcher
                    .Watch();
            }
            else {
                Console.WriteLine("The authentication information is invalid.");
            }
        }

        /// <summary>
        /// Hardware Authentication
        /// </summary>
        private void hardwareWatchAuthentication() {

            #region Define Authentication Parameters

            // Computer User Name
            string user = "";

            // Computer Password
            string password = "";

            // Computer Name or Ip Address Or Local Connetection "."
            string computer = ".";

            // Active Directory Domain Name or Workgorup Name
            string domain = "";
            #endregion

            // Hardwate Watch Authentication Set
            hardware
                .Watcher
                .Authentication(user, password, computer, domain);
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
                Console
                .WriteLine(
                    $"Run {Thread.CurrentThread.ManagedThreadId} Thread" +
                    $"With {arg} argument");
            });
        }
    }
```

> Find Example

```cs
namespace HMT.Tests.Application {
    using System;
    using System.Collections.Generic;
    using HMT.Hardware;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class FindTests {

        /// <summary>
        /// Printer Hardware
        /// </summary>
        private Printer hardware;

        [TestMethod]
        public void HardwareFindListTest() {

            // Job Initalize
            hardware = new Printer();

            // Get All Hardware
            List<HardwareData> hardwares = hardware
                .Finder
                .Hardwares;

            // Hardware List 
            foreach (HardwareData item in hardwares) {

                // Print Hardware
                Console.WriteLine($"Name : {item.Name}");
            }
        }

        [TestMethod]
        public void HardwareFindListWithPropertyTest() {

            // Job Initalize
            hardware = new Printer();

            // Get All Hardware
            List<HardwareData> hardwares = hardware
                .Finder
                .Hardwares;

            // Hardware List 
            foreach (HardwareData item in hardwares) {

                // Print Hardware
                Console.WriteLine($"Name : {item.Name}");

                // Print Hardware Property List
                foreach (HardwareDataProperty property in item.Properties) {
                    if (property.Value != null) {
                        Console.WriteLine($"    >   {property.Name}\t|{property.Value}");
                    }
                }
            }
        }
    }
}
```