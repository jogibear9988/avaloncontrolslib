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
using System.Collections.ObjectModel;

namespace TestApplication
{
    /// <summary>
    /// basic class for testing the hierarchy structure
    /// </summary>
    public class TreeStructure
    {
        internal void AddSampleChildrenUsingDataBinding(int numberOfChildren, int numberofLevel)
        {
            this.children = new ObservableCollection<TreeStructure>();

            AddChildren(children, numberOfChildren, numberofLevel);
        }

        static void AddChildren(IList<TreeStructure> list, int numberOfChildren, int level)
        {
            for (int i = 0; i < numberOfChildren; i++)
            {
                ObservableCollection<TreeStructure> childrenOfChildren = null;
                
                if(level != 1)
                    childrenOfChildren = new ObservableCollection<TreeStructure>();

                list.Add(new TreeStructure("Child " + i, childrenOfChildren));
                
                if (level != 1)
                    AddChildren(childrenOfChildren, numberOfChildren, level - 1);
            }
        }

        string myProperty;
        public string MyProperty
        {
            get { return myProperty; }
            set { myProperty = value; }
        }

        private IList<TreeStructure> children;
        public IList<TreeStructure> Children
        {
            get { return children; }
        }

        public TreeStructure(string text, IList<TreeStructure> children)
        {
            this.children = children;
            this.myProperty = text;
        }

        //overrides the .ToString for Debug purposes
        public override string ToString()
        {
            return myProperty;
        }
    }

    /// <summary>
    /// HierarchalListBoxTest is a sample window to demo the HerarchalListBox control
    /// The hierarchal listbox control is basically a listbox that can show a hierarchy
    /// </summary>
    public partial class HierarchalListBoxTest : Window
    {
        ObservableCollection<TreeStructure> dataSource;

        /// <summary>
        /// Default ctor
        /// </summary>
        public HierarchalListBoxTest()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(HierarchalListBoxTest_Loaded);

            dataSource = new ObservableCollection<TreeStructure>();

            //generate some sample data
            for (int i = 0; i < 500; i++)
            {
                TreeStructure child = new TreeStructure(i.ToString(), new TreeStructure[]
                {
                    new TreeStructure("child1 of "+i, new TreeStructure[0]),
                    new TreeStructure("child2 of "+i, new TreeStructure[]
                        {
                            new TreeStructure("child1 of child2 of "+i, new TreeStructure[0]),
                            new TreeStructure("child2 of child2 of "+i, new TreeStructure[0]),
                            new TreeStructure("child3 of child2 of "+i, new TreeStructure[]
                            {
                                new TreeStructure("child1 of child3 of child2 of "+i, new TreeStructure[0]),
                                new TreeStructure("child2 of child3 of child2 of "+i, new TreeStructure[0]),
                                new TreeStructure("child3 of child3 of child2 of "+i, new TreeStructure[0])
                            }),
                        }),
                    new TreeStructure("child3 of "+i, new TreeStructure[0])
                });
                dataSource.Add(child);
            }

            //This string represents the property that contains the child elemnt of the hierarchy
            testList.ChildItemSourcePath = "Children";

            //Please note when using this control set the HierarchalItemsSource not the ItemsSource as follows...
            testList.HierarchalItemsSource = dataSource;

            testTree.ItemsSource = dataSource;

        }

        void ResetAndAddNew(object sender, RoutedEventArgs e)
        {
            int childCount, levelCount;
            ValidateInput(out childCount, out levelCount);

            dataSource.Clear();
            TreeStructure main = new TreeStructure("Main root", null);
            dataSource.Add(main);
            main.AddSampleChildrenUsingDataBinding(childCount, levelCount);
        }

        private void ValidateInput(out int childCount, out int levels)
        {
            levels = -1;

            if (!int.TryParse(noChildren.Text, out childCount))
            {
                MessageBox.Show("Please insert a valid number");
                return;
            }

            if (!int.TryParse(noLevels.Text, out levels))
            {
                MessageBox.Show("Please insert a valid number");
                return;
            }
        }


        //loaded event handler to count the number of visuals in the TreeListbox
        void HierarchalListBoxTest_Loaded(object sender, RoutedEventArgs e)
        {
            //hook to the scrolling event to re calculate the number of visuals
            testList.AddHandler(ScrollViewer.ScrollChangedEvent, (RoutedEventHandler)delegate
            {
                this.totalVirtualizedItems.Text = GetVisualCount(testList).ToString();
            });

            testTree.AddHandler(ScrollViewer.ScrollChangedEvent, (RoutedEventHandler)delegate
            {
                this.totalVirtualizedItemsForTree.Text = GetVisualCount(testTree).ToString();
            });

            this.totalVirtualizedItemsForTree.Text = GetVisualCount(testTree).ToString();
            this.totalVirtualizedItems.Text = GetVisualCount(testList).ToString();
        }

        //gets the number of visuals loaded for a particular virtualizing stack panel
        private static int GetVisualCount(DependencyObject visual)
        {
            int visualCount = -1;
            int childCount = VisualTreeHelper.GetChildrenCount(visual);

            for (int i = 0; i < childCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(visual, i) as DependencyObject;

                //get the child of the stack panel
                StackPanel panel = child as StackPanel;
                if (panel != null)
                    return panel.Children.Count;
                else
                {
                    //try to parse as a Virtualizing stackPanel
                    VirtualizingStackPanel vpanel = child as VirtualizingStackPanel;
                    if (vpanel != null)
                    {
                        return vpanel.Children.Count;
                    }
                    else
                    {
                        visualCount = GetVisualCount(child);
                        if (visualCount != -1)
                            return visualCount;
                    }
                }
            }
            return visualCount;
        }


        #region OLD test code
        //ObservableCollection<TreeStructure> childElements = new ObservableCollection<TreeStructure>();
        //ObservableCollection<TreeStructure> childOfChildElements = new ObservableCollection<TreeStructure>();

        ////adds a new item
        //void AddNewItemsClick(object sender, RoutedEventArgs e)
        //{
        //    if (childElements == null)
        //        childElements = new ObservableCollection<TreeStructure>();

        //    int index;
        //    if (!int.TryParse(insertIndex.Text, out index))
        //        MessageBox.Show("Please insert a valid number");
        //    else
        //        dataSource.Insert(
        //            Math.Min(index, dataSource.Count),
        //            new TreeStructure("New child created", childElements));

        //}


        ////adds a new child item
        //void AddNewChildItemsClick(object sender, RoutedEventArgs e)
        //{
        //    if (childElements == null)
        //        MessageBox.Show("Please add an extra item first by clicking the 'Add new Items' button");
        //    else
        //    {
        //        int index;
        //        if (!int.TryParse(insertIndex.Text, out index))
        //            MessageBox.Show("Please insert a valid number");
        //        else
        //            childElements.Insert(Math.Min(index, childElements.Count), new TreeStructure("New child created " + index, childOfChildElements));
        //    }
        //}

        //void AddNestedChildItems(object sender, RoutedEventArgs e)
        //{
        //    if (childOfChildElements == null)
        //        childOfChildElements = new ObservableCollection<TreeStructure>();

        //    if (childElements == null)
        //        MessageBox.Show("Please add an extra item first by clicking the 'Add new Items' button");
        //    else
        //    {
        //        int index;
        //        if (!int.TryParse(insertIndex.Text, out index))
        //            MessageBox.Show("Please insert a valid number");
        //        else
        //            childOfChildElements.Insert(Math.Min(index, childOfChildElements.Count),
        //                new TreeStructure("New child of Child created " + index, null));
        //    }
        //}

        ////move an item from one place to the other
        //void RemoveItemClick(object sender, RoutedEventArgs e)
        //{
        //    if (dataSource.Count < 1)
        //        MessageBox.Show("Please add more children in order to do this operation");
        //    else
        //        dataSource.RemoveAt(0);
        //}

        //void RemoveItemChildClick(object sender, RoutedEventArgs e)
        //{
        //    if (childElements.Count < 1)
        //        MessageBox.Show("Please add more children in order to do this operation");
        //    else
        //        childElements.RemoveAt(0);
        //}
        #endregion
    }
}
