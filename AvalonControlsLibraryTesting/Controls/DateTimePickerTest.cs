using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AvalonUnitTesting;
using AC.AvalonControlsLibrary.Controls;

namespace AvalonControlsLibraryTesting.Controls
{
    [TestFixture]
    public class DateTimePickerTest
    {
        /// <summary>
        /// Test data binding for control
        /// </summary>
        [Test]
        public void RunDataBindingTests()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                AvalonTestRunner.RunDataBindingTests(new DateTimePicker());
            });
        }

        [Test]
        public void TestChangeDateSelected()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                DateTimePicker picker = new DateTimePicker();
                picker.OnApplyTemplate();
                bool hasEventFired = false;
                picker.SelectedDateTimeChanged += delegate { hasEventFired = true; };
                picker.DateTimeSelected = new DateTime(10);
                Assert.IsTrue(hasEventFired, "Event not fired");

                DateTime s = new DateTime(1, 1, 1, 2, 2, 2);

                picker.DateTimeSelected = new DateTime(1, 1, 1, 2, 2, 2);
                Assert.AreEqual(new DateTime(1, 1, 1, 2, 2, 2), picker.DateTimeSelected, "Invalid date set");
            });
        }

        [Test]
        public void TestSyncronizationOFPickers()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                DateTimePicker picker = new DateTimePicker();
                DatePicker datePicker = null;
                TimePicker timePicker = null;
                picker.OnApplyTemplate();//force the apply template
                picker.ExposedDatePicker(ref datePicker, ref timePicker);
                picker.DateTimeSelected = new DateTime(1, 1, 1, 2, 2, 2);
                Assert.AreEqual(picker.DateTimeSelected.Date, datePicker.CurrentlySelectedDate.Date, "Invalid date set");
                Assert.AreEqual(picker.DateTimeSelected.TimeOfDay, timePicker.SelectedTime, "Invalid time set");

                //now check that if the date is changed from the picker the date for DateTimePicker is updated as well
                DateTime testDate = new DateTime(1, 2, 1);
                datePicker.CurrentlySelectedDate = testDate;
                Assert.AreEqual(testDate, picker.DateTimeSelected.Date, "Invalid date set from date picker");

                TimeSpan testTime = new TimeSpan(1, 2, 1);
                timePicker.SelectedTime = testTime;
                Assert.AreEqual(testTime, picker.DateTimeSelected.TimeOfDay, "Invalid time set from time picker");
            });
        }
    }
}
