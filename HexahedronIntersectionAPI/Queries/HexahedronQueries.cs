using HexahedronIntersectionDomain.Entities;
using HexahedronIntersectionDomain.Repositories;
using HexahedronIntersectionDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexahedronIntersectionAPI.Queries
{
    /// <summary>
    /// Represents queries to do on the repository
    /// </summary>
    public class HexahedronQueries
    {
        private readonly IHexahedronRepository repository;

        public HexahedronQueries(IHexahedronRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Query to get an hexahedron by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Hexahedron> GetHexahedronByIdAsync(Guid id)
        {
            var response = await repository.GetHexahedronById(HexahedronId.Create(id));

            return response;
        }
    }
}
