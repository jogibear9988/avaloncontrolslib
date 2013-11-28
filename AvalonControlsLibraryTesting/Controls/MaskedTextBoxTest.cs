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
    public class MaskedTextBoxTest
    {
        /// <summary>
        /// Test data binding for control
        /// </summary>
        [Test]
        public void RunDataBindingTests()
        {
            AvalonTestRunner.RunInSTA(delegate
            {
                AvalonTestRunner.RunDataBindingTests(new MaskedTextBoxTest());
            });
        }

        [Test]
        public void MaskTest()
        {
            AvalonTestRunner.RunInSTA(delegate
              {
                  MaskedTextBox textBox = new MaskedTextBox();
                  //set mask and test output
                  textBox.Mask = "00-00";
                  textBox.Text = "1111";
                  Assert.AreEqual("11-11", textBox.Text, "Invalid text set");

                  //make same test but this time first set the text
                  textBox = new MaskedTextBox();
                  textBox.Text = "1111";
                  textBox.Mask = "00-00";
                  Assert.AreEqual("11-11", textBox.Text, "Invalid text set");

              }
           );
        }
    }
}
