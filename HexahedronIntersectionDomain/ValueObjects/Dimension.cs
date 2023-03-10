using System;
using System.Collections.Generic;
using System.Text;

namespace HexahedronIntersectionDomain.ValueObjects
{
    public class Dimension
    {
        /// <summary>
        /// Value of dimension
        /// </summary>
        public decimal value { get; set; }

        internal Dimension(decimal value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates a dimension
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Created dimension</returns>
        public static Dimension Create(decimal value)
        {
            Validate(value);
            return new Dimension(value);
        }

        /// <summary>
        /// Validates a dimension
        /// </summary>
        /// <param name="value"></param>
        private static void Validate(decimal value)
        {
            if (value<=0)
            {
                throw new HexahedronDefinitionNotValidException("All dimensions must be greater than 0");
            }
        }
    }

    public class HexahedronDefinitionNotValidException : Exception
    {
        public HexahedronDefinitionNotValidException(string message) : base(message)
        {

        }
    }
}
