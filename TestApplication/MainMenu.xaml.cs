using System.Windows;
using System.Diagnostics;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void InputPromptClick(object sender, RoutedEventArgs e)
        {
            new InputPromptTest().Show();
        }

        private void DockyControlClick(object sender, RoutedEventArgs e)
        {
            new DockableContainerTest().Show();
        }
        private void RatingControlClick(object sender, RoutedEventArgs e)
        {
            new RatingSelectorTest().Show();
        }
        private void MaskTextBoxClick(object sender, RoutedEventArgs e)
        {
            new MaskedTextBoxTest().Show();
        }

        private void HListBoxClick(object sender, RoutedEventArgs e)
        {
            new HierarchalListBoxTest().Show();
        }

        private void ListViewClick(object sender, RoutedEventArgs e)
        {
            new ListViewSorting().Show();
        }
        

        private void DatePickerClick(object sender, RoutedEventArgs e)
        {
            new DatePickerTest().Show();
        }

        private void TimePickerClick(object sender, RoutedEventArgs e)
        {
            new TimePickerTest().Show();
        }

        private void DateTimePickerClick(object sender, RoutedEventArgs e)
        {
            new DateTimePickerTest().Show();
        }
        
        private void DataGridViewClick(object sender, RoutedEventArgs e)
        {
            new DataGridViewTest().Show();
        }

        private void RangeSliderClick(object sender, RoutedEventArgs e)
        {
            new RangeSliderTest().Show();
        }

        private void MagnifierClick(object sender, RoutedEventArgs e)
        {
            new MagnifierTest().Show();
        }
    }
}
