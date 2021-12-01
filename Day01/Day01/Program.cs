using System;
using System.Collections.Generic;
using System.IO;

namespace Day01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var depths = GetDepths();
            var depthIncreasedCount = GetDepthIncreasedCount(depths);
            var threeMeasurementDepthsIncreasedCount = GetThreeMeasurementDepthIncreasedCount(depths);

            Console.WriteLine($"Depth increased {depthIncreasedCount} times");
            Console.WriteLine($"Depth (three measurements combined) increased {threeMeasurementDepthsIncreasedCount} times");
            Console.ReadKey();
        }

        private static IList<int> GetDepths()
        {
            var depthsAsStrings = File.ReadAllLines(@"C:\Sandbox\AdventOfCode2021\Day01\Day01\data\day01-input.csv");
            var depths = new List<int>();

            foreach (var depth in depthsAsStrings)
            {
                if (int.TryParse(depth, out int depthAsNumber))
                {
                    depths.Add(depthAsNumber);
                }
            }

            return depths;
        }
        
        private static int GetDepthIncreasedCount(IList<int> depths)
        {
            var depthIncreasedCount = 0;
            for (var i = 1; i < depths.Count; i++)
            {
                if (depths[i] > depths[i - 1])
                {
                    depthIncreasedCount++;
                }
            }

            return depthIncreasedCount;
        }

        private static int GetThreeMeasurementDepthIncreasedCount(IList<int> depths)
        {
            var depthIncreasedCount = 0;
            var previousThreeMeasurementDepth = depths[0] + depths[1] + depths[2];
            for (var i = 3; i < depths.Count; i++)
            {
                var currentThreeMeasurementDepth = depths[i - 2] + depths[i - 1] + depths[i];

                if (currentThreeMeasurementDepth > previousThreeMeasurementDepth)
                {
                    depthIncreasedCount++;
                }

                previousThreeMeasurementDepth = currentThreeMeasurementDepth;
            }

            return depthIncreasedCount;
        }
    }
}
