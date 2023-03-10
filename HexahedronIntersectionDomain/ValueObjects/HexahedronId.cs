using System;
using System.Collections.Generic;
using System.Text;

namespace HexahedronIntersectionDomain.ValueObjects
{

    /// <summary>
    /// Represents an hexahedron's identificator
    /// </summary>
    public class HexahedronId
    {
        /// <summary>
        /// Value of hexahedron's identificator
        /// </summary>
        public Guid value { get; set; }

        internal HexahedronId(Guid value)
        {
            this.value = value;
        }

        /// <summary>
        /// Creates an HexahedronId
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HexahedronId Create(Guid value)
        {
            return new HexahedronId(value);
        }

        /// <summary>
        /// Operator for allows cast an hexahedronId as Guid
        /// </summary>
        /// <param name="hexahedronId"></param>
        public static implicit operator Guid(HexahedronId hexahedronId)
        {
            return hexahedronId.value;
        }

    }
}
