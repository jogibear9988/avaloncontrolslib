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
using AC.AvalonControlsLibrary.Controls;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for DateTimePickerTest.xaml
    /// </summary>
    public partial class DatePickerTest : Window
    {
        public DatePickerTest()
        {
            InitializeComponent();
            restyledDatePicker.MinDate = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0));
            datePicker.MinDate = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0));
            datePicker.MaxDate = DateTime.Now.AddDays(5);

            datePicker.SelectedDateChanged += delegate(object sender, DateSelectedChangedRoutedEventArgs e)
            {
                MessageBox.Show(String.Format("New Date: {0}\nOld Date: {1}",
                        e.NewDate.ToShortDateString(), e.OldDate.ToShortDateString()));
            };
        }
    }
}
