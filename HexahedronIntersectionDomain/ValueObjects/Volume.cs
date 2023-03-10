using System;
using System.Collections.Generic;
using System.Text;

namespace HexahedronIntersectionDomain.ValueObjects
{
    public class Volume
    {
        /// <summary>
        /// Value of volume
        /// </summary>
        public decimal value { get; set; }

        internal Volume(decimal value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates a volume
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Volume Create(decimal value)
        {
            Validate(value);
            return new Volume(value);
        }

        /// <summary>
        /// Validates a volume
        /// </summary>
        /// <param name="value"></param>
        private static void Validate(decimal value)
        {
            if (value < 0)
            {
                throw new VolumeNotValidException("Volume must be greater or equals than 0");
            }
        }
    }

    public class VolumeNotValidException : Exception
    {
        public VolumeNotValidException(string message) : base(message)
        {

        }
    }
}
