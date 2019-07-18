# Hardware Management Tool

A management tool that provides easy access to hardware interfaces to automate management tasks on local or remote computers.

IT managers and System Specialists; provides fast and practical solutions for monitoring, reporting and auditing critical operations.

Basically, the application interface toolkit that targets windows devices plans to support other operating systems such as linux and macos in the future.

## Usage

> Watch Example

```cs
    using HMT.Hardware;
    public class WatchTests {

        /// <summary>
        /// Printer Job Hardware
        /// </summary>
        private PrinterJob hardware;

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
        private void Hardware_Signal(object sender, PrintJobEvent e) {

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
        }
    }
```

> Authentication Example

```cs
    using System;
    using HMT.Hardware;

    public class AuthenticationTest {

        /// <summary>
        /// Printer Job Hardware
        /// </summary>
        private PrinterJob hardware;

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
        }
    }
```