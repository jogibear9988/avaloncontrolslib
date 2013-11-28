using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AC.AvalonControlsLibrary.Core;
using System.Reflection;

namespace AvalonControlsLibraryTesting.Common
{
    /// <summary>
    /// Test for the PropertyInfoHelper
    /// </summary>
    [TestFixture]
    public class PropertyInfoHelperTest
    {
        /// <summary>
        /// Mock object to test with
        /// </summary>
        class MockObject
        {
            public int Test { get { return 1; } }

            public int Test2 { set { ; } }
        }

        /// <summary>
        /// Test the GetProperties method
        /// </summary>
        [Test]
        public void GetPropertiesTest()
        {
            IList<PropertyInfo> list = PropertyInfoEngine.GetProperties(typeof(MockObject));

            //this should be 1 since only one property is CanRead
            Assert.AreEqual(1, list.Count, "number of properties is incorrect");
            Assert.AreEqual("Test", list[0].Name, "invalid property created");

            IList<string> list2 = PropertyInfoEngine.GetProperties(typeof(MockObject), delegate(PropertyInfo prop)
            {
                return prop.Name;
            });
            Assert.AreEqual(1, list.Count, "invalid number of properties");
            Assert.AreEqual("Test", list2[0], "invalid data loaded");
        }
    }
}
