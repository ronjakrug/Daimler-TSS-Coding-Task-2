using System;
using System.Collections.Generic;
using System.Linq;

namespace Krug.DaimlerTSS.CodingTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

            return Interval.Merge(intervals);
        }
    }
}
