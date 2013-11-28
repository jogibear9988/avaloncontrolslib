using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Diagnostics;

namespace TestApplication
{
    /// <summary>
    /// Just a normal Hyperlink that can start the url that you navigate to in a browser
    /// </summary>
    public class BrowserLink : Hyperlink
    {
        public BrowserLink()
        {
            this.RequestNavigate += delegate(object sender, RequestNavigateEventArgs e)
            {
                Process.Start(new ProcessStartInfo(e.Uri.ToString()));
            };
        }
    }
}
