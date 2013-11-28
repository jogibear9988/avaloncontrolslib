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
using System.Windows.Shapes;
using AC.AvalonControlsLibrary.Controls;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for RangeSliderTest.xaml
    /// </summary>
    public partial class RangeSliderTest : Window
    {
        public RangeSliderTest()
        {
            InitializeComponent();
            //register to range changes
            rangeSlider.RangeSelectionChanged += RangeSliderRangeSelectionChanged;

            rangeSlider.RangeStart = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)).Ticks; // Yesterday
            rangeSlider.RangeStop = DateTime.Now.Ticks;//Date Now
            rangeSlider.RangeStartSelected = DateTime.Now.Subtract(new TimeSpan(0, 6, 0, 0)).Ticks; //6 hours ago
            rangeSlider.RangeStopSelected = DateTime.Now.Subtract(new TimeSpan(0, 9, 0, 0)).Ticks; //9 hours ago
            rangeSlider.MinRange = new TimeSpan(0, 1, 0).Ticks;//1 minute
        }

        //event handler for the range selection changed
        void RangeSliderRangeSelectionChanged(object sender, RangeSelectionChangedEventArgs e)
        {
            rangeSliderSelectedValue1.Text = new DateTime(e.NewRangeStart).ToString();
            rangeSliderSelectedValue2.Text = new DateTime(e.NewRangeStop).ToString();
        }
    }
}
