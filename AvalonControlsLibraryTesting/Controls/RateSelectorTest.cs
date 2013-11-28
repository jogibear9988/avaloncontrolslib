using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AvalonUnitTesting;
using AC.AvalonControlsLibrary.Controls;

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
    public class RateSelectorTest
    {
        /// <summary>
        /// Test data binding for control
        /// </summary>
        [Test]
        public void RunDataBindingTests()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                AvalonTestRunner.RunDataBindingTests(new RatingSelector());
            });
        }
    }
}
