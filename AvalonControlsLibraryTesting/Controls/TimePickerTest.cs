using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AvalonUnitTesting;
using AC.AvalonControlsLibrary.Controls;
using System.Windows.Controls;
using System.Windows.Input;

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
    public class TimePickerTest
    {
        [Test]
        public void RunDataBindingTests()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                AvalonTestRunner.RunDataBindingTests(new TimePicker());
            });
        }

        [Test]
        public void TrimSelectedTextTest()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                TextBox textBox = new TextBox();
                //try to trim when there are no text
                TimePicker.ExposeTrimSelectedText(textBox);
                Assert.AreEqual("", textBox.Text, "Trim failed");

                textBox = new TextBox();
                textBox.Text = "10";
                textBox.SelectAll();
                TimePicker.ExposeTrimSelectedText(textBox);
                Assert.AreEqual("", textBox.Text, "Trim failed when selection was All");

                textBox = new TextBox();
                textBox.Text = "10";
                textBox.SelectionStart = 0;
                textBox.SelectionLength = 1;
                TimePicker.ExposeTrimSelectedText(textBox);
                Assert.AreEqual("0", textBox.Text, "Trim failed when selection was at the first char");

                textBox = new TextBox();
                textBox.Text = "10";
                textBox.SelectionStart = 1;
                textBox.SelectionLength = 1;
                TimePicker.ExposeTrimSelectedText(textBox);
                Assert.AreEqual("1", textBox.Text, "Trim failed when selection was at the second char");
            });
        }

        [Test]
        public void SetNewTimeTest()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                TimePicker picker = new TimePicker();
                picker.SelectedHour = 1;
                picker.SelectedMinute = 2;
                picker.SelectedSecond = 3;
                
                Assert.AreEqual(1, picker.SelectedTime.Hours, "Invalid hour set");
                Assert.AreEqual(2, picker.SelectedTime.Minutes, "Invalid minute set");
                Assert.AreEqual(3, picker.SelectedTime.Seconds, "Invalid second set");

                //try to set some invalid values
                picker = new TimePicker();
                bool hasEventFired = false;
                picker.SelectedTimeChanged += delegate { hasEventFired = true; };
                picker.SelectedHour = 44;
                //check if the event has been fired
                Assert.IsTrue(hasEventFired, "Event not fired");
                hasEventFired = false;
                picker.SelectedMinute = 2;
                Assert.IsTrue(hasEventFired, "Event not fired");
                hasEventFired = false;
                picker.SelectedSecond = 99;
                Assert.IsTrue(hasEventFired, "Event not fired");
                
                Assert.AreEqual(23, picker.SelectedTime.Hours, "Invalid hour set");
                Assert.AreEqual(2, picker.SelectedTime.Minutes, "Invalid minute set");
                Assert.AreEqual(59, picker.SelectedTime.Seconds, "Invalid second set");
            });
        }

        [Test]
        public void AdjustCarretIndexOrMoveToNeighbourTest()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                TextBox textBox = new TextBox();
                TextBox neighbour = new TextBox();
                textBox.Text = "10";
                TimePicker.ExposeAdjustCarretIndexOrMoveToNeighbour(textBox, neighbour);
                Assert.AreEqual(1, textBox.CaretIndex, "Invalid caret index");
                Assert.IsFalse(neighbour.IsFocused, "Neighbour is focused");

                //the carrot is now moved...try to call the method again to focus the neighbour
                TimePicker.ExposeAdjustCarretIndexOrMoveToNeighbour(textBox, neighbour);
                Assert.IsTrue(neighbour.IsFocused, "Neighbour is not focused");


            });
        }

        [Test]
        public void TryFocusNeighbourControlTest()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                TextBox current = new TextBox();
                TextBox left = new TextBox();
                TextBox right = new TextBox();

                current.Text = "10";
                current.CaretIndex = 2;

                //test going focus left with null
                TimePicker.ExposeTryFocusNeighbourControl(current, null, null, Key.Left);
                //now test with left textbox but with the invalid caret index
                TimePicker.ExposeTryFocusNeighbourControl(current, left, right, Key.Left);
                Assert.IsFalse(left.IsFocused, "left was focused");

                current.CaretIndex = 0;
                TimePicker.ExposeTryFocusNeighbourControl(current, left, right, Key.Left);
                Assert.IsTrue(left.IsFocused, "left was NOT focused");

                current = new TextBox();
                left = new TextBox();
                right = new TextBox();

                current.Text = "10";
                current.CaretIndex = 0;
                //test going focus right with null
                TimePicker.ExposeTryFocusNeighbourControl(current, null, null, Key.Right);
                //now test with right textbox but with the invalid caret index
                TimePicker.ExposeTryFocusNeighbourControl(current, left, right, Key.Right);
                Assert.IsFalse(right.IsFocused, "right was focused");

                current.CaretIndex = 2;
                TimePicker.ExposeTryFocusNeighbourControl(current, left, right, Key.Right);
                Assert.IsTrue(right.IsFocused, "right was NOT focused");


            });
        }
    }
}
