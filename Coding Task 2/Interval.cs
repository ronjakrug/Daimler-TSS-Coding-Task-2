using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krug.DaimlerTSS.CodingTask2
{
    /// <summary>
    /// Class which represents an interval
    /// </summary>
    public class Interval
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public int Length
        {
            get
            {
                return End - Start;
            }
        }

        /// <summary>
        /// Constructor for a new interval
        /// </summary>
        /// <param name="one">Normally start of interval (smaller value)</param>
        /// <param name="two">Normally end of interval (greater value)</param>
        /// <param name="ignoreOrder">Not mandatory, true by default. If set to false, "one" has to be smaller than "two"</param>
        public Interval(int one, int two, bool ignoreOrder = true)
        {
            if (!ignoreOrder && (one > two))
            {
                throw new ArgumentOutOfRangeException(nameof(one), one.ToString(), "Start of interval can't be greater than end of interval.");
            }
            else
            {
                End = Math.Max(one, two);
                Start = Math.Min(one, two);
            }
        }

        /// <summary>
        /// Enum with possible cases for two compared intervals
        /// </summary>
        public enum IntersectionCase
        {
            /// <summary>
            /// New Interval [a.Start, b.End]
            /// </summary>
            AIntersectsB,
            /// <summary>
            /// New Interval [b.Start, a.End]
            /// </summary>
            BIntersectsA,
            /// <summary>
            /// New Interval [b.Start, b.End]
            /// </summary>
            AWithinB,
            /// <summary>
            /// New Interval [a.Start, a.End]
            /// </summary>
            BWithinA,
            /// <summary>
            /// Intervals stay the same
            /// </summary>
            NoIntersection
        }

        /// <summary>
        /// Depending on the enum value the intervals are merged or are staying the same
        /// </summary>
        /// <param name="intervals">The enumerable of intervals coming from the user</param>
        /// <returns>The edited list with merged intervals</returns>
        public static List<Interval> Merge(IEnumerable<Interval> intervals)
        {
            List<Interval> sortedList = new List<Interval>();
            sortedList.AddRange(intervals.OrderBy(e => e.Start));

            for (int i = 0; i < sortedList.Count() - 1; i++)
            {
                IntersectionCase intersectionCase = Compare(sortedList[i], sortedList[i + 1]);
                switch (intersectionCase)
                {
                    case IntersectionCase.AIntersectsB:
                        sortedList[i].End = sortedList[i + 1].End;
                        sortedList.RemoveAt(i + 1);
                        i--;
                        break;
                    //Doesn't happen because the list is sorted
                    case IntersectionCase.BIntersectsA:
                        sortedList[i].Start = sortedList[i + 1].Start;
                        sortedList.RemoveAt(i + 1);
                        i--;
                        break;
                    //Doesn't happen because the list is sorted
                    case IntersectionCase.AWithinB:
                        sortedList.RemoveAt(i);
                        i--;
                        break;
                    case IntersectionCase.BWithinA:
                        sortedList.RemoveAt(i + 1);
                        i--;
                        break;
                    case IntersectionCase.NoIntersection:
                    default:
                        break;
                }
            }
            return sortedList;
        }

        /// <summary>
        /// Compares two intervals and returns the enum value
        /// </summary>
        /// <param name="a">First interval</param>
        /// <param name="b">Second interval</param>
        /// <returns></returns>
        public static IntersectionCase Compare(Interval a, Interval b)
        {
            if (a.Start <= b.Start)
            {
                //Check if interval b is within interval a
                if (a.End <= b.End)
                {
                    //Check if interval a intersects interval b
                    if (a.End > b.Start)
                    {
                        //Interval a intersects interval b
                        return IntersectionCase.AIntersectsB;
                        //Start = a.start, Ende = b.ende
                    }
                    else return IntersectionCase.NoIntersection;
                }
                else
                {
                    //Interval b is within interval a
                    return IntersectionCase.BWithinA;
                    //start = a.start, ende = a.ende
                }
            }
            else //if (a.Start > b.Start)
            {
                //Check if interval a is within interval b 
                if (a.End >= b.End)
                {
                    //Check if interval b intersects interval a
                    if (a.Start <= b.End)
                    {
                        //interval b intersects interval a
                        return IntersectionCase.BIntersectsA;
                        //start = b.start, ende = a.ende
                    }
                    else
                    {
                        return IntersectionCase.NoIntersection;
                    }
                }
                else
                {
                    //Interval a is within interval b
                    return IntersectionCase.AWithinB;
                    //start = b.start, ende = b.ende
                }
            }
        }
    }
}
