
namespace HexahedronIntersection.GeometricForms
{
    /// <summary>
    /// Represents a point into a 3D space
    /// </summary>
    public class Point
    {
        public Point(decimal x, decimal y, decimal z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// X coordenate
        /// </summary>
        public decimal x { get; }

        /// <summary>
        /// Y coordenate
        /// </summary>
        public decimal y { get; }

        /// <summary>
        /// Z coordenate
        /// </summary>
        public decimal z { get; }

    }
}
