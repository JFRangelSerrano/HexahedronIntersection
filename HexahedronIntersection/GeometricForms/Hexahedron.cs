using System;
using System.Collections.ObjectModel;

namespace HexahedronIntersection.GeometricForms
{
    /// <summary>
    /// Represents a hexahedron into a 3D space
    /// </summary>
    public class Hexahedron
    {
        public Hexahedron (Point center, decimal width, decimal height, decimal depth)
        {
            if (center==null)
            {
                throw new HexahedronDefinitionNotValidException("The center point of hexahedron is not defined");
            }
            else if (width<=0 || height<=0 || depth<=0)
            {
                throw new HexahedronDefinitionNotValidException("All dimensions must be greater than 0");
            }

            this.center = center;
            this.width = width;
            this.height = height;
            this.depth = depth;
        }

        /// <summary>
        /// Center point of hexahedron
        /// </summary>
        public Point center { get; }

        /// <summary>
        /// Hexahedron size on X axis
        /// </summary>
        public decimal width { get; }

        /// <summary>
        /// Hexahedron size on Y axis
        /// </summary>
        public decimal height { get; }

        /// <summary>
        /// Hexahedron size on Z axis
        /// </summary>
        public decimal depth { get; }

        private Collection<Point> _Vertexs = null;

        /// <summary>
        /// Collection of hexahedron's vertexs
        /// </summary>
        public Collection<Point> Vertexs
        {
            get
            {
                // Using the Singleton pattern to instantiate vertexs only first time they are requested
                if (_Vertexs == null)
                {
                    Segment xSegment = new Segment(center.x - (width / 2), center.x + (width / 2));
                    Segment ySegment = new Segment(center.y - (height / 2), center.y + (height / 2));
                    Segment zSegment = new Segment(center.z - (depth / 2), center.z + (depth / 2));

                    _Vertexs = new Collection<Point>();

                    _Vertexs.Add(new Point(xSegment.start, ySegment.start, zSegment.start));
                    _Vertexs.Add(new Point(xSegment.start, ySegment.end, zSegment.start));
                    _Vertexs.Add(new Point(xSegment.end, ySegment.start, zSegment.start));
                    _Vertexs.Add(new Point(xSegment.end, ySegment.end, zSegment.start));
                    _Vertexs.Add(new Point(xSegment.start, ySegment.start, zSegment.end));
                    _Vertexs.Add(new Point(xSegment.start, ySegment.end, zSegment.end));
                    _Vertexs.Add(new Point(xSegment.end, ySegment.start, zSegment.end));
                    _Vertexs.Add(new Point(xSegment.end, ySegment.end, zSegment.end));
                }

                return _Vertexs;
            }
        }

        /// <summary>
        /// Volume of hexahedron
        /// </summary>
        public decimal volume
        {
            get
            {
                return width * height * depth;
            }
        }

    }

    public class HexahedronDefinitionNotValidException : Exception
    {
        public HexahedronDefinitionNotValidException(string message) : base (message)
        {

        }
    }
}
