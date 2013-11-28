using System.Diagnostics;
using System.Windows;
using NUnit.Framework;

namespace AvalonUnitTesting
{
    /// <summary>
    /// Trace listener that asserts when a data binding error is encontered in a specific page
    /// </summary>
    public class AvalonTraceListener : TraceListener
    {
        private Window currentWindowBeingTested;

        /// <summary>
        /// The current window that is being tests
        /// </summary>
        internal Window CurrentWindowBeingTested
        {
            get { return currentWindowBeingTested; }
            set { currentWindowBeingTested = value; }
        }
        /// <summary>
        /// Fails the unit test if this method is called
        /// </summary>
        /// <param name="message">The message to push in the fail</param>
        public override void Write(string message)
        { }

        /// <summary>
        /// Fails the unit test if this method is called
        /// </summary>
        /// <param name="message">The message to push in the fail</param>
        public override void WriteLine(string message)
        {
            //close the window before failing the tests
            if (currentWindowBeingTested != null)
                currentWindowBeingTested.Close();

            Assert.Fail(message);
        }
    }
}
