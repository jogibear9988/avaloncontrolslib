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
using System.Windows.Threading;
using System.Collections.ObjectModel;

namespace TestApplication
{
    /// <summary>
    /// Interaction logic for VirtualizationTreeViewTest.xaml
    /// </summary>
    public partial class VirtualizationTreeViewTest : Window
    {
        ObservableCollection<TreeStructure> children = new ObservableCollection<TreeStructure>();
        public VirtualizationTreeViewTest()
        {
            InitializeComponent();

            treeListBox.ChildItemSourcePath = "Children";
            treeListBox.HierarchalItemsSource = new List<TreeStructure>(
                new TreeStructure[]
                {
                    new TreeStructure("Parent 1", children)
                });

        }

        private void BulkInsertClick(object sender, RoutedEventArgs e)
        {
            bool x = true;
            for (int i = 0; i < 50; i++)
            {
                children.Add(new TreeStructure(x.ToString(), null));
                x = !x;
            }
        }
    }
}
