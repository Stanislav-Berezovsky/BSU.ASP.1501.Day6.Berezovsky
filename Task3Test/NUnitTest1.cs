﻿using NUnit.Framework;
using System;
using System.Collections;
using Task3;
using System.Collections.Generic;
using System.Linq;
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
            JaggedArraySort.InterfaceToDelegate(array, new CompareByPositiveSum());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsPositive, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortByPositiveSumTest1()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsPositive = { new[] { 3, -1, 5, -21, 31 }, new[] { 5, 5, -10, 20 }, new[] { 0, 24, -4, 10 }, new[] { 7, -4, -3, 25, 15 }, null, null, null, null };
            JaggedArraySort.DelegateToInterface(array, (a, b) =>
            {
                if (a == null && b == null)
                    return 0;
                if (a == null)
                    return 1;
                if (b == null)
                    return -1;
                int aSum = a.Sum();
                int bSum = b.Sum();
                if (aSum > bSum)
                    return 1;
                if (aSum == bSum)
                    return 0;
                return -1;
            }
                );
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsPositive, StructuralComparisons.StructuralEqualityComparer), true);
        }
        [Test]
        public void SortByNegativeSumTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsNegative = { new[] { 7, -4, -3, 25, 15 }, new[] { 0, 24, -4, 10 }, new[] { 5, 5, -10, 20 }, new[] { 3, -1, 5, -21, 31 }, null, null, null, null };
            JaggedArraySort.InterfaceToDelegate(array, new CompareByNegativeSum());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsNegative, StructuralComparisons.StructuralEqualityComparer), true);

        }

        [Test]
        public void SortByPositiveMaxElementTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsPositive = { new[] { 5, 5, -10, 20 }, new[] { 0, 24, -4, 10 }, new[] { 7, -4, -3, 25, 15 }, new[] { 3, -1, 5, -21, 31 }, null, null, null, null };
            JaggedArraySort.InterfaceToDelegate(array, new CompareByPositiveMaxElement());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsPositive, StructuralComparisons.StructuralEqualityComparer), true);
        }

        [Test]
        public void SortByNegativeMaxElementTest()
        {
            int[][] array = { null, new[] { 3, -1, 5, -21, 31 }, new[] { 0, 24, -4, 10 }, null, null, new[] { 5, 5, -10, 20 }, null, new[] { 7, -4, -3, 25, 15 } };
            int[][] arrayCompareIsNegative = { new[] { 3, -1, 5, -21, 31 }, new[] { 7, -4, -3, 25, 15 }, new[] { 0, 24, -4, 10 }, new[] { 5, 5, -10, 20 }, null, null, null, null };
            JaggedArraySort.InterfaceToDelegate(array, new CompareByNegativeMaxElement());
            IStructuralEquatable arraySort = array;
            Assert.AreEqual(arraySort.Equals(arrayCompareIsNegative, StructuralComparisons.StructuralEqualityComparer), true);

        }
    }
}