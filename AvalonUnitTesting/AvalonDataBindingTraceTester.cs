using System.Diagnostics;
using System.Windows;

namespace AvalonUnitTesting
{
    /// <summary>
    /// Hooks to the Trace of the WPF databinding to check for dat binding errors
    /// </summary>
    public static class AvalonDataBindingTraceTester
    {
        private static AvalonTraceListener dataBindingListener;

        /// <summary>
        /// Gets a databinding trace listener
        /// </summary>
        internal static AvalonTraceListener DataBindingListener
        {
            get
            {
                if (dataBindingListener == null)
                    dataBindingListener = new AvalonTraceListener();
                return dataBindingListener;
            }
        }

        /// <summary>
        /// hooks the window to the wpf trace
        /// </summary>
        /// <param name="windowToTest">The window to test</param>
        public static void TestDataBindingsForObject(Window windowToTest)
        {
            EnforceDataBindingTraceListener(windowToTest);
            windowToTest.ShowInTaskbar = false;
            windowToTest.Show();
            windowToTest.Hide();
        }

        //check if there is already a databinding trace listener, if not creates it
        private static void EnforceDataBindingTraceListener(Window currentWindow)
        {
            PresentationTraceSources.Refresh();
            PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Warning;

            //add the databinding listener
            if (!PresentationTraceSources.DataBindingSource.Listeners.Contains(DataBindingListener))
                PresentationTraceSources.DataBindingSource.Listeners.Add(DataBindingListener);

            //set the current window being tested
            DataBindingListener.CurrentWindowBeingTested = currentWindow;
        }
    }
}
