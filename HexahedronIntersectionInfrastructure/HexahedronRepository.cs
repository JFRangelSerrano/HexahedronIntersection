using HexahedronIntersectionDomain.Entities;
using HexahedronIntersectionDomain.Repositories;
using HexahedronIntersectionDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexahedronIntersectionInfrastructure
{
    public class HexahedronRepository : IHexahedronRepository
    {
        HexahedronDbContext db;

        public HexahedronRepository(HexahedronDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Add an hexahedron
        /// </summary>
        /// <param name="hexahedron">Hexahedron to add</param>
        /// <returns></returns>
        public async Task<bool> AddHexahedron(Hexahedron hexahedron)
        {
            try
            {
                await db.AddAsync(hexahedron);
                await db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Get an hexahedron by Id
        /// </summary>
        /// <param name="Id">Hexahedron Id</param>
        /// <returns>Hexahedron searched</returns>
        public async Task<Hexahedron> GetHexahedronById(HexahedronId Id)
        {
            return await db.Hexahedrons.FindAsync((Guid)Id);
        }

        /// <summary>
        /// Remove an hexahedron
        /// </summary>
        /// <param name="hexahedron">Hexahedron to remove</param>
        public void RemoveHexahedron(Hexahedron hexahedron)
        {
            if (db.Hexahedrons.Contains(hexahedron))
            {
                db.Hexahedrons.Remove(hexahedron);
                db.SaveChanges();
            }
        }
    }
}
