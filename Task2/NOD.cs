using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task2
{
    public static class NOD
    {
        private delegate int NODAlgorithm(int a, int b);


        public static int Euclidean(int a, int b)
        {
            return Calculate(EuclideanMethod, a, b);
        }

        public static int Euclidean(params int[] array)
        {
            return Calculate(EuclideanMethod, array);
        }
        public static int Euclidean(int a, int b, out long ticks)
        {
            return Calculate(EuclideanMethod, out ticks, a, b);
        }
        public static long Euclidean(out long ticks, params int[] array)
        {
            return Calculate(EuclideanMethod, out ticks, array);
        }

        public static int Stein(int a, int b)
        {
            return Calculate(SteinMethod, a, b);
        }
        public static int Stein(int a, int b, out long ticks)
        {
            return Calculate(SteinMethod, out ticks, a, b);
        }
        public static int Stein(params int[] array)
        {
            return Calculate(SteinMethod, array);
        }
        public static long Stein(out long ticks, params int[] array)
        {
            return Calculate(SteinMethod, out ticks, array);
        }


        private static int EuclideanMethod(int a, int b)
        {
            int variable = 0;
            while (b > 0)
            {
                variable = b;
                b = a % b;
                a = variable;
            }
            return a;
        }


        private static int SteinMethod(int a, int b)
        {
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == b)
                return a;
            if (a == 1 && b == 1)
                return 1;
            if (a % 2 == 0)
            {
                if (b % 2 == 0)
                    return 2 * SteinMethod(a / 2, b / 2);
                return SteinMethod(a / 2, b);
            }
            if (b % 2 == 0)
                return SteinMethod(a, b / 2);

            if (a > b)
                return SteinMethod((a - b) / 2, b);
            return SteinMethod((b - a) / 2, a);
        }



        private static int Calculate(NODAlgorithm algorithm, int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            return algorithm(a, b);
        }
        private static int Calculate(NODAlgorithm algorithm, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();
            if (array.Length == 1)
                return array[0];
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result = Calculate(algorithm, result, array[i]);
            }
            return result;
        }

        private static int Calculate(NODAlgorithm algorithm, out long ticks, int a, int b)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = Calculate(algorithm, a, b);
            stopwatch.Stop();
            ticks = stopwatch.ElapsedTicks;
            return result;
        }
        private static int Calculate(NODAlgorithm algorithm, out long ticks, params int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int result = Calculate(algorithm, array);
            stopwatch.Stop();
            ticks = stopwatch.ElapsedTicks;
            return result;
        }
    }
}

