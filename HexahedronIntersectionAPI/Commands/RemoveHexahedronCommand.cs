using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexahedronIntersectionAPI.Commands
{
    /// <summary>
    /// Command for delete a hexahedron from the repository
    /// </summary>
    public record RemoveHexahedronCommand(Guid hexahedronId);
}
