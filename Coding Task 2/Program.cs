using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Krug.DaimlerTSS.CodingTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach(Interval i in Test())
                {
                    Console.WriteLine("[" + i.Start + "]" + "[" + i.End + "]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Test function with interval list
        /// </summary>
        /// <returns></returns>
        public static List<Interval> Test()
        {
            List<Interval> intervals = new List<Interval>();
            intervals.Add(new Interval(3, 6));
            intervals.Add(new Interval(4, 7));
            intervals.Add(new Interval(8, 9));
            intervals.Add(new Interval(12, 18));
            intervals.Add(new Interval(2, 6));
            intervals.Add(new Interval(13, 17));
            for(int i = 0; i < 10000; i++)
            {
                Random a = new Random();
                int one = a.Next();
                int two = a.Next();
                intervals.Add(new Interval(one, two, true));
            }
            //Stopwatch to get the code execution time
            #if DEBUG
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            return Interval.Merge(intervals);

            stopwatch.Stop();

            Console.WriteLine("Execution Time is {0} ms", stopwatch.ElapsedMilliseconds);
            #endif

        }
    }
}
