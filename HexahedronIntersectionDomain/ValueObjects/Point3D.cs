
using System;
using System.Collections.Generic;
using System.Linq;

namespace HexahedronIntersectionDomain.ValueObjects
{
    /// <summary>
    /// Represents a point into a 3D space
    /// </summary>
    public class Point3D
    {
        /// <summary>
        /// Value of point into a 3D space
        /// </summary>
        public Dictionary<Axis,Point1D> value { get; set; }

        internal Point3D(Dictionary<Axis, Point1D> value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates a Point3D
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Point3D Create(Dictionary<Axis, Point1D> value)
        {
            Validate(value);
            return new Point3D(value);
        }

        /// <summary>
        /// Validates a Point3D
        /// </summary>
        /// <param name="value"></param>
        public static void Validate(Dictionary<Axis, Point1D> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value can not be null");
            }
            else if (value.Keys.Distinct().Count() != 3)
            {
                throw new Point3DDefinitionNotValidException("3D Points must has value for 3 axis");
            }
        }
    }

    public class Point3DDefinitionNotValidException : Exception
    {
        public Point3DDefinitionNotValidException(string message) : base(message)
        {

        }
    }
}
