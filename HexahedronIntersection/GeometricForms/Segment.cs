using System;

namespace HexahedronIntersection.GeometricForms
{
    /// <summary>
    /// Represents a segment between two points (values) of an axis
    /// </summary>
    class Segment
    {
        public Segment(decimal start, decimal end)
        {
            if (!(start<end))
            {
                throw new SegmentDefinitionNotValidException("End value must be greater than start value");
            }

            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Represents start point (value) of segment
        /// </summary>
        public decimal start { get; }

        /// <summary>
        /// Represents end point (value) of segment
        /// </summary>
        public decimal end { get; }
    }

    public class SegmentDefinitionNotValidException : Exception
    {
        public SegmentDefinitionNotValidException(string message) : base(message)
        {

        }
    }
}
