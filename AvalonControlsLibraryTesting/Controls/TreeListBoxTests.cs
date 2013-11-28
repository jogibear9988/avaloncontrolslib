using System.Collections.Generic;
using System.Collections.ObjectModel;
using AC.AvalonControlsLibrary.Controls;
using AvalonUnitTesting;
using NUnit.Framework;

namespace AvalonControlsLibraryTesting.Controls
{
    /// <summary>
    /// This unit test uses the AvalonUnitTesting Library
    /// for more info visit
    /// http://marlongrech.wordpress.com/2007/10/14/wpf-unit-testing/
    /// or also
    /// http://www.codeproject.com/KB/WPF/unittestingwpf.aspx
    /// </summary>
    /// <summary>
    /// Test data binding for control
    /// </summary>
    [TestFixture]
    public class TreeListBoxTests
    {
        
        [Test]
        public void RunDataBindingTests()
        {
            AvalonTestRunner.RunInSTA(delegate
              {
                  AvalonTestRunner.RunDataBindingTests(new TreeListBox());
              });
        }

        /// <summary>
        /// tests the ResetItemsSource method of the TreeListBox
        /// </summary>
        [Test]
        public void TestResetItemsSource()
        {
            AvalonTestRunner.RunInSTA(delegate
              {
                  //populate sample data
                  List<string> businessObjects = new List<string>(4);
                  businessObjects.Add("A");
                  businessObjects.Add("AA");
                  businessObjects.Add("AAA");
                  businessObjects.Add("AAAA");
                  businessObjects.Add("AAAA");

                  TreeListBox treeListBox = new TreeListBox();
                  treeListBox.ExposedGenerateItemsSource(businessObjects);

                  //check that there are 4 items in the items source and that they are of type TreeLiistBoxInfo
                  Assert.AreEqual(5, treeListBox.Items.Count,
                                  "Invalid number of items added");
                  for (int i = 0; i < treeListBox.Items.Count; i++)
                  {
                      Assert.AreEqual(typeof (TreeListBoxInfo),
                                      treeListBox.Items[i].GetType(),
                                      "Invalid type added to tree list box");
                  }
              });
        }

        /// <summary>
        /// test collection notifications for the treelistbox items source
        /// </summary>
        [Test]
        public void TestItemsSourceCollectionNotifications()
        {
            AvalonTestRunner.RunInSTA(delegate
              {
                  //populate sample data
                  ObservableCollection<string> businessObjects =
                      new ObservableCollection<string>();
                  businessObjects.Add("A");
                  businessObjects.Add("AA");
                  businessObjects.Add("AAA");
                  businessObjects.Add("AAAA");

                  TreeListBox treeListBox = new TreeListBox();
                  treeListBox.ExposedGenerateItemsSource(businessObjects);
                  Assert.AreEqual(4, treeListBox.Items.Count,
                                  "Invalid number of items added");

                  //add anew item and verify that this item was added to the items source
                  businessObjects.Add("NewItem1");
                  //check the Count
                  Assert.AreEqual(5, treeListBox.Items.Count,
                                  "Invalid number of items added");
                  //check the position of the item
                  Assert.AreEqual("NewItem1",
                                  ((TreeListBoxInfo) treeListBox.Items[4]).DataItem,
                                  "Item was added at an invalid index");

                  //insert another item in the begining of the list
                  businessObjects.Insert(1, "NewItem2");
                  //check the Count
                  Assert.AreEqual(6, treeListBox.Items.Count,
                                  "Invalid number of items added");
                  //check the position of the item
                  Assert.AreEqual("NewItem2",
                                  ((TreeListBoxInfo) treeListBox.Items[1]).DataItem,
                                  "Item was added at an invalid index");

                  //Check the remove
                  businessObjects.RemoveAt(1);
                  //check the Count
                  Assert.AreEqual(5, treeListBox.Items.Count,
                                  "Invalid number of items added");
                  //validate that the item was deleted properly
                  for (int i = 0; i < treeListBox.Items.Count; i++)
                      Assert.AreNotEqual("NewItem2",
                                         ((TreeListBoxInfo) treeListBox.Items[i]).DataItem,
                                         "Item was removed from the wrong index");
              });
        }
    }
}
