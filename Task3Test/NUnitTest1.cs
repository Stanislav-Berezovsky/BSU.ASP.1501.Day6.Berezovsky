using NUnit.Framework;
using System;
using System.Collections;
using Task3;

namespace Task3Test
{
    [TestFixture]
    public class JaggedArraySortTest
    {
        [Test]
        public void SortByPositiveSumTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsPositive = { new[] { 3, -1, 5, -21, 31 }, new[] { 5, 5, -10, 20 }, new[] { 0, 24, -4, 10 }, new[] { 7, -4, -3, 25, 15 }, null, null, null, null };
            JaggedArraySort.Sort(array, new CompareByPositiveSum());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsPositive, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortByNegativeSumTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsNegative = { new[] { 7, -4, -3, 25, 15 }, new[] { 0, 24, -4, 10 }, new[] { 5, 5, -10, 20 }, new[] { 3, -1, 5, -21, 31 }, null, null, null, null };
            JaggedArraySort.Sort(array, new CompareByNegativeSum());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsNegative, StructuralComparisons.StructuralEqualityComparer), true);

        }

        [Test]
        public void SortByPositiveMaxElementTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsPositive = { new[] { 5, 5, -10, 20 }, new[] { 0, 24, -4, 10 }, new[] { 7, -4, -3, 25, 15 }, new[] { 3, -1, 5, -21, 31 }, null, null, null, null };
            JaggedArraySort.Sort(array, new CompareByPositiveMaxElement());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsPositive, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortByNegativeMaxElementTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsNegative = { new[] { 3, -1, 5, -21, 31 }, new[] { 7, -4, -3, 25, 15 }, new[] { 0, 24, -4, 10 }, new[] { 5, 5, -10, 20 }, null, null, null, null };
            JaggedArraySort.Sort(array, new CompareByNegativeMaxElement());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsNegative, StructuralComparisons.StructuralEqualityComparer), true);

        }
    }
}