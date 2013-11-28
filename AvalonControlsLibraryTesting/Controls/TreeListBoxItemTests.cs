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
    [TestFixture]
    public class TreeListBoxItemTests
    {
        /// <summary>
        /// Test data binding for control
        /// </summary>
        [Test]
        public void RunDataBindingTests()
        {
            AvalonTestRunner.RunInSTA(delegate
              {
                  AvalonTestRunner.RunDataBindingTests(
                      new TreeListBoxItem(new TreeListBox()));
              });
        }

        #region Mock Object
        //mock object for testing
        private class MockHierarchalObject
        {
            private IList<MockHierarchalObject> children = new List<MockHierarchalObject>();
            //children collection

            private readonly string text;
            //sample text
            public string Text
            {
                get { return text; }
            }

            public IList<MockHierarchalObject> Children
            {
                get { return children; }
                set { children = value; }
            }

            public MockHierarchalObject(string text, IList<MockHierarchalObject> children)
            {
                this.text = text;
                Children = children;
            }
            public MockHierarchalObject(string text)
                : this(text, null)
            { }
        }
        #endregion

        [Test]
        public void TestPopulationOfChildrenFromNotifications()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                //children collection
                ObservableCollection<MockHierarchalObject> childNodes =
                    new ObservableCollection<MockHierarchalObject>(
                        new List<MockHierarchalObject>(new MockHierarchalObject[]
                                                         {
                                                             //children
                                                             new MockHierarchalObject(
                                                                 "child1 of A"),
                                                             new MockHierarchalObject(
                                                                 "child2 of A"),
                                                             new MockHierarchalObject(
                                                                 "child3 of A"),
                                                         }));

                //create sample data
                MockHierarchalObject dataSource =
                    new MockHierarchalObject("A", childNodes);

                //prepare the parent collection
                TreeListBox parentControl = new TreeListBox();
                parentControl.ChildItemSourcePath = "Children";
                parentControl.ExposedGenerateItemsSource(new MockHierarchalObject[]
                                                           {
                                                               new MockHierarchalObject(
                                                                   "First, item with no children")
                                                               ,
                                                               //add a simple item that has no children
                                                               dataSource,
                                                               //add the item that has children to test on
                                                               new MockHierarchalObject(
                                                                   "Last, item with no children")
                                                           });

                Assert.AreEqual(3, parentControl.Items.Count, "Invalid number of items");
                //create an item to test
                TreeListBoxItem item = new TreeListBoxItem(parentControl);
                item.ExposePrepareItem(parentControl.Items[1] as TreeListBoxInfo);
                //pass the info that was create for the item that has children

                //expand the item this should result in the items source of the parent include the children
                item.IsExpanded = true;
                //3 root nodes and 3 children are suppose to be in the list
                Assert.AreEqual(3 + 3, parentControl.Items.Count,
                                "Invalid number of items");

                //add a new item to child collection and check if it is added
                childNodes.Add(new MockHierarchalObject("child4 of A"));
                //3 root nodes and 3 + 1(which is the new one) children are suppose to be in the list
                Assert.AreEqual(3 + childNodes.Count, parentControl.Items.Count,
                                "Invalid number of items");
                //check the index of the new item in the flat list
                //1 is the index of the container item, and 4 is the count of the children
                Assert.AreEqual("child4 of A",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[1 + 4]).DataItem).
                                    Text,
                                "Item was not added in the right index");

                //check that the insert in a specific index
                childNodes.Insert(2, new MockHierarchalObject("inserted child of A"));
                Assert.AreEqual(3 + childNodes.Count, parentControl.Items.Count,
                                "Invalid number of items");
                //check that the insert was done in the right index(where 1 is the parent index and 2 is the index in the children collection)
                Assert.AreEqual("inserted child of A",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[1 + 3]).DataItem).
                                    Text,
                                "Item was not added in the right index");

                //check the remove of items
                childNodes.RemoveAt(2);
                //check the Count
                Assert.AreEqual(3 + childNodes.Count, parentControl.Items.Count,
                                "Invalid number of items added");
                //validate that the item was deleted properly
                for (int i = 0; i < parentControl.Items.Count; i++)
                    Assert.AreNotEqual("inserted child of A",
                                       ((MockHierarchalObject)
                                        ((TreeListBoxInfo)parentControl.Items[i]).
                                            DataItem).Text,
                                       "Item was removed from the wrong index");

                //check that if we collapse the items no children are add
                item.IsExpanded = false;
                //check that the items where collapsed
                Assert.AreEqual(3, parentControl.Items.Count,
                                "Invalid number of items after collapse item");

                childNodes.Add(new MockHierarchalObject("Test collapse"));
                //check that the item was not added to the flat list since the item is collapsed
                Assert.AreEqual(3, parentControl.Items.Count,
                                "Invalid number of items after collapse item");

                //check that when you re expand the item all items are generated
                item.IsExpanded = true;
                Assert.AreEqual(3 + childNodes.Count, parentControl.Items.Count,
                                "Invalid number of items after collapse item");
            });
        }

        [Test]
        public void TestPopulationOfChildren()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                //create sample data
                MockHierarchalObject dataSource =
                    new MockHierarchalObject("A",
                                             new List<MockHierarchalObject>(
                                                 new MockHierarchalObject[]
                                                   {
                                                       //children
                                                       new MockHierarchalObject(
                                                           "child1 of A"),
                                                       new MockHierarchalObject(
                                                           "child2 of A"),
                                                       new MockHierarchalObject(
                                                           "child3 of A"),
                                                   }));

                //prepare the parent collection
                TreeListBox parentControl = new TreeListBox();
                parentControl.ChildItemSourcePath = "Children";
                parentControl.ExposedGenerateItemsSource(new MockHierarchalObject[]
                                                           {
                                                               new MockHierarchalObject(
                                                                   "First, item with no children")
                                                               ,
                                                               //add a simple item that has no children
                                                               dataSource,
                                                               //add the item that has children to test on
                                                               new MockHierarchalObject(
                                                                   "Last, item with no children")
                                                           });
                Assert.AreEqual(3, parentControl.Items.Count, "Invalid number of items");
                //create an item to test
                TreeListBoxItem item = new TreeListBoxItem(parentControl);
                item.ExposePrepareItem(parentControl.Items[1] as TreeListBoxInfo);
                //pass the info that was create for the item that has children

                //expand the item this should result in the items source of the parent include the children
                item.IsExpanded = true;
                //3 root nodes and 3 children are suppose to be in the list
                Assert.AreEqual(3 + 3, parentControl.Items.Count,
                                "Invalid number of items");

                //check that the items where create in the right indeces
                Assert.AreEqual("child1 of A",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[2]).DataItem).Text,
                                "Child Item was placed in the wrong index");
                //validate that the last item(which is index to of the root nodes) of the root nodes has been moved to the proper index
                //2 is the index in the root nodes, 3 is the count of the children, so the last item should have moved to index 5
                Assert.AreEqual("Last, item with no children",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[2 + 3]).DataItem).
                                    Text,
                                "Root Item was placed in the wrong index");

                //validate that the level of the items has been incremented
                //start from index 2, since the children are place at index 2
                for (int i = 2; i < 3 + 2; i++)
                    Assert.AreEqual(1, ((TreeListBoxInfo)parentControl.Items[i]).Level,
                                    "Invalid level set for child nodes");

                //Validate the Collapse
                item.IsExpanded = false;

                //all children should be dropped
                Assert.AreEqual(3, parentControl.Items.Count, "Invalid number of items");

                //check that the indeces of the items is back to normal
                Assert.AreEqual("First, item with no children",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[0]).DataItem).Text,
                                "Root Item was placed in the wrong index");
                Assert.AreEqual("A",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[1]).DataItem).Text,
                                "Root Item was placed in the wrong index");
                Assert.AreEqual("Last, item with no children",
                                ((MockHierarchalObject)
                                 ((TreeListBoxInfo)parentControl.Items[2]).DataItem).Text,
                                "Root Item was placed in the wrong index");
            });
        }
    }
}
