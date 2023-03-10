using System;
using System.Collections.Generic;
using System.Text;

namespace HexahedronIntersectionDomain.ValueObjects
{
    public class Point1D
    {
        /// <summary>
        /// Value of point into a 1D space
        /// </summary>
        public decimal value { get; }

        internal Point1D(decimal value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates a Point1D
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Point1D Create(decimal value)
        {
            return new Point1D(value);
        }

    }
}
