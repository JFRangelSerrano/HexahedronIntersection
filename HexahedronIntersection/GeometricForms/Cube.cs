
namespace HexahedronIntersection.GeometricForms
{
    /// <summary>
    /// Represents a cube into a 3D space
    /// </summary>
    public class Cube : Hexahedron
    {
        public Cube (Point center, decimal dimensions) : base (center, dimensions, dimensions, dimensions)
        {
        }
    }
}
