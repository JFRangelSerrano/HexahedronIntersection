using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexahedronIntersectionAPI.Commands
{
    /// <summary>
    /// Command for create a hexahedron into the repository
    /// </summary>
    public record CreateHexahedronCommand (Guid hexahedronId, decimal centerX, decimal centerY, decimal centerZ, decimal width, decimal height, decimal depth);
}
