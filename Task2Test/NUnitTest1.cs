using NUnit.Framework;
using System;
using Task2;
using System.Diagnostics;
using NUnit.Framework;

namespace Task2Test
{
    [TestFixture]
    public class NODTest
    {
        [Test]
        public void EuclideanMethodTest()
        {
            long ticks = 0;
            Assert.AreEqual(NOD.Euclidean(out ticks, 1000, -750), 250);
            Debug.WriteLine("EuclideanMethodTime  :{0}", ticks);
            ticks = 0;
            Assert.AreEqual(NOD.Euclidean(out ticks, 1000, -750, 800, 550), 50);
            Debug.WriteLine("EuclideanMethodArrayTime  :{0}", ticks);
            Assert.AreEqual(NOD.Euclidean(1000, -750), 250);
            Assert.AreEqual(NOD.Euclidean(1000, -750, 800, 550), 50);
        }



        [Test]
        public void SteinMethodTest()
        {
            long ticks = 0;
            Assert.AreEqual(NOD.Stein(1000, -750), 250);
            Assert.AreEqual(NOD.Stein(out ticks, 1000, -750), 250);
            Debug.WriteLine("EuclideanMethodTime  :{0}", ticks);
            Assert.AreEqual(NOD.Stein(1000, -750, 800, 550), 50);
            ticks = 0;
            Assert.AreEqual(NOD.Stein(out ticks, 1000, -750, 800, 550), 50);
            Debug.WriteLine("EuclideanMethodArrayTime  :{0}", ticks);
        }
    }
}