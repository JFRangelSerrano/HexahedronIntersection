using HexahedronIntersection.GeometricForms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HexahedronIntersection.Managers
{
    /// <summary>
    /// Represents a manager for get segment intersection between two segments
    /// </summary>
    static class SegmentIntersectionManager
    {
        /// <summary>
        /// Returns intersection segment between two segment if exists. Else, returns null.
        /// </summary>
        /// <param name="segment1">First segment</param>
        /// <param name="segment2">Second segment</param>
        /// <returns></returns>
        public static Segment GetIntersection(Segment segment1, Segment segment2)
        {
            if (!ExistsIntersection(segment1,segment2))
            {
                //There is not segment intersection
                return null;
            }
            else
            {
                //Return common segment to both segments
                return new Segment(Math.Max(segment1.start, segment2.start), Math.Min(segment1.end, segment2.end));
            }
        }

        /// <summary>
        /// Determines if exists intersection between two segments
        /// </summary>
        /// <param name="segment1">First segment</param>
        /// <param name="segment2">Second segment</param>
        /// <returns></returns>
        private static bool ExistsIntersection(Segment segment1, Segment segment2)
        {
            if (segment1 == null || segment1 == null)
            {
                //There is not segment intersection
                return false;
            }
            else
            {
                //Order ascending both segments by start value
                List<Segment> OrderedSegments = new List<Segment>();
                OrderedSegments.Add(segment1);
                OrderedSegments.Add(segment2);
                OrderedSegments = OrderedSegments.OrderBy(s => s.start).ToList();

                //If start value of last segment is greather or equal than end value of first segment, there is not intersection
                return !(OrderedSegments.Last().start >= OrderedSegments.First().end);
            }
        }

    }
}
