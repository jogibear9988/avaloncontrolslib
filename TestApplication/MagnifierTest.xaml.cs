using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for Magnifier.xaml
    /// </summary>
    public partial class MagnifierTest : Window
    {
        public MagnifierTest()
        {
            InitializeComponent();
            magnifier.Magnify += new EventHandler<AC.AvalonControlsLibrary.Controls.MagnifyEventArgs>(magnifier_Magnify);
        }

        void magnifier_Magnify(object sender, AC.AvalonControlsLibrary.Controls.MagnifyEventArgs e)
        {
            displayValue.Text = e.MagnifiedBy.ToString();
            //as you can not depending on how much you try to magnify the speed of the magnification changes
            //P.S the * 20 is there since we have a very small value for minimum and maximum
            displayRect.Width = Math.Max(displayRect.Width - (e.MagnifiedBy * 20), 0);
        }
    }
}
