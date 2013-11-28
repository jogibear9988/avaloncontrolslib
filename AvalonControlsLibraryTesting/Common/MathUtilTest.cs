using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using AC.AvalonControlsLibrary.Core;

namespace AvalonControlsLibraryTesting.Common
{
    [TestFixture]
    public class MathUtilTest
    {
        //test that is testing the boundaries of the numbers to increment and decrement
        [Test]
        public void IncrementDecrementNumberTest()
        {
            int result = MathUtil.IncrementDecrementNumber("x", 0, 10, true);
            Assert.AreEqual(1, result, "Invalid result"); //the item should be incremented
            result = MathUtil.IncrementDecrementNumber("x", 0, 10, false);
            Assert.AreEqual(0, result, "Invalid result"); //validate that the number still stays 0 which is the min

            result = MathUtil.IncrementDecrementNumber("1", 2, 10, true);
            Assert.AreEqual(3, result, "Invalid result"); //the item should be incremented
            result = MathUtil.IncrementDecrementNumber("3", 2, 10, false);
            Assert.AreEqual(2, result, "Invalid result"); //validate that the number still stays 0 which is the min

            result = MathUtil.IncrementDecrementNumber("9", 0, 10, true);
            Assert.AreEqual(10, result, "Invalid result"); //the item should be incremented
            result = MathUtil.IncrementDecrementNumber("10", 0, 10, true);
            Assert.AreEqual(10, result, "Invalid result"); //the item should NOT be incremented since the max is 10
        }

        [Test]
        public void ValidateNumberTest()
        {
            int result = MathUtil.ValidateNumber("5", 0, 10);
            Assert.AreEqual(5, result, "Invalid result");

            result = MathUtil.ValidateNumber("x", 0, 10);
            Assert.AreEqual(0, result, "Invalid result"); 

            result = MathUtil.ValidateNumber("11", 0, 10);
            Assert.AreEqual(10, result, "Invalid result");

            result = MathUtil.ValidateNumber("-1", 0, 10);
            Assert.AreEqual(0, result, "Invalid result");
        }
    }
}
