using System.Collections.Generic;
using System.Linq;
using HexahedronIntersection.GeometricForms;

namespace HexahedronIntersection.Managers
{
    /// <summary>
    /// Represents a manager for get hexahedron intersection between two hexahedrons
    /// </summary>
    public static class HexahedronIntersectionManager
    {
        private enum Axis
        {
            x,
            y,
            z
        }

        /// <summary>
        /// Returns intersection hexahedron between two hexahedrons if exists. Else, returns null.
        /// </summary>
        /// <param name="hexahedron1">First hexahedron</param>
        /// <param name="hexahedron2">Second hexahedron</param>
        /// <returns></returns>
        public static Hexahedron GetIntersection(Hexahedron hexahedron1, Hexahedron hexahedron2)
        {
            if (hexahedron1==null || hexahedron2==null)
            {
                //There is not intersection
                return null;
            }
            else
            {
                //Get intersecion segment on each axis
                Segment xSegmentIntersection = GetSegmentIntersectionOnAxis(hexahedron1, hexahedron2, Axis.x);
                Segment ySegmentIntersection = GetSegmentIntersectionOnAxis(hexahedron1, hexahedron2, Axis.y);
                Segment zSegmentIntersection = GetSegmentIntersectionOnAxis(hexahedron1, hexahedron2, Axis.z);

                if (xSegmentIntersection == null || ySegmentIntersection == null || zSegmentIntersection == null)
                {
                    //There is not hexahedron intersection
                    return null;
                }
                else
                {
                    //Return hexahedron intersection
                    Point center = new Point((xSegmentIntersection.start + xSegmentIntersection.end) / 2, (ySegmentIntersection.start + ySegmentIntersection.end) / 2, (zSegmentIntersection.start + zSegmentIntersection.end) / 2);
                    decimal width = xSegmentIntersection.end - xSegmentIntersection.start;
                    decimal height = ySegmentIntersection.end - ySegmentIntersection.start;
                    decimal depth = zSegmentIntersection.end - zSegmentIntersection.start;

                    return new Hexahedron(center, width, height, depth);
                }
            }
        }

        /// <summary>
        /// Returns common segment on a axis between two hexahedrons if exists. Else, returns null.
        /// </summary>
        /// <param name="hexahedron1">First hexahedron</param>
        /// <param name="hexahedron2">Second hexahedron</param>
        /// <param name="axis">Axis</param>
        /// <returns></returns>
        private static Segment GetSegmentIntersectionOnAxis(Hexahedron hexahedron1, Hexahedron hexahedron2, Axis axis)
        {
            if (hexahedron1 == null || hexahedron2 == null)
            {
                //There is not segment intersection
                return null;
            }
            else
            {
                IEnumerable<decimal> hexahedron1SegmentValues;
                IEnumerable<decimal> hexahedron2SegmentValues;
                Segment hexahedron1Segment;
                Segment hexahedron2Segment;

                // Study the cross of both hexahedron on selected axis and return common segment
                hexahedron1SegmentValues = hexahedron1.Vertexs.Select(v => (axis == Axis.x ? v.x : (axis == Axis.y ? v.y : v.z))).Distinct();
                hexahedron2SegmentValues = hexahedron2.Vertexs.Select(v => (axis == Axis.x ? v.x : (axis == Axis.y ? v.y : v.z))).Distinct();
                hexahedron1Segment = new Segment(hexahedron1SegmentValues.Min(), hexahedron1SegmentValues.Max());
                hexahedron2Segment = new Segment(hexahedron2SegmentValues.Min(), hexahedron2SegmentValues.Max());
                return SegmentIntersectionManager.GetIntersection(hexahedron1Segment, hexahedron2Segment);
            }
        }

    }
}
