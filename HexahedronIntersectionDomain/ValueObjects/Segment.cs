using System;
using System.Collections.Generic;
using System.Linq;

namespace HexahedronIntersectionDomain.ValueObjects
{
    /// <summary>
    /// Represents a segment between two points (values) of an axis
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// Value of segment represented by start and end points into an 1D space
        /// </summary>
        public Dictionary<SegmentSide, Point1D> value { get; set; }

        internal Segment(Dictionary<SegmentSide, Point1D> value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates a segment
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Segment Create(Dictionary<SegmentSide, Point1D> value)
        {
            Validate(value);
            return new Segment(value);
        }

        /// <summary>
        /// Validates a segment
        /// </summary>
        /// <param name="value"></param>
        private static void Validate(Dictionary<SegmentSide, Point1D> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value can not be null");
            }
            else if (value.Keys.Distinct().Count()!=2)
            {
                throw new SegmentDefinitionNotValidException("Segments must has start and end sides");
            }
        }
    }

    public class SegmentDefinitionNotValidException : Exception
    {
        public SegmentDefinitionNotValidException(string message) : base(message)
        {

        }
    }
}
