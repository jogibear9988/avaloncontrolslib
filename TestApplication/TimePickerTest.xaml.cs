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
    /// Interaction logic for TimePickerTest.xaml
    /// </summary>
    public partial class TimePickerTest : Window
    {
        public TimePickerTest()
        {
            InitializeComponent();
            timePicker.MinTime = DateTime.Now.TimeOfDay.Subtract(new TimeSpan(1, 0, 0));
            timePicker.SelectedTimeChanged += delegate(object sender, TimeSelectedChangedRoutedEventArgs e)
            {
                MessageBox.Show(String.Format("New Time: {0}\nOld Time: {1}", 
                    e.NewTime.ToString(), e.OldTime.ToString()));
            };
        }
    }
}
