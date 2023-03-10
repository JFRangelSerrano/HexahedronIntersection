using HexahedronIntersectionDomain.Entities;
using HexahedronIntersectionDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HexahedronIntersectionDomain.Repositories
{
    public interface IHexahedronRepository
    {
        /// <summary>
        /// Get an hexahedron by Id
        /// </summary>
        /// <param name="Id">Hexahedron Id</param>
        /// <returns>Hexahedron searched</returns>
        Task<Hexahedron> GetHexahedronById(HexahedronId Id);

        /// <summary>
        /// Add an hexahedron
        /// </summary>
        /// <param name="hexahedron">Hexahedron to add</param>
        /// <returns></returns>
        Task<bool> AddHexahedron(Hexahedron hexahedron);

        /// <summary>
        /// Remove an hexahedron
        /// </summary>
        /// <param name="hexahedron">Hexahedron to remove</param>
        void RemoveHexahedron(Hexahedron hexahedron);
    }




}
