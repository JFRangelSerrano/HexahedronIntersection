using HexahedronIntersectionDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static HexahedronIntersectionDomain.ValueObjects.Segment;

namespace HexahedronIntersectionDomain.Entities
{
    /// <summary>
    /// Represents a hexahedron into a 3D space
    /// </summary>
    public class Hexahedron
    {
        public Hexahedron(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Set center point of hexahedron
        /// </summary>
        /// <param name="center"></param>
        public void SetCenter(Point3D center)
        {
            this.center = center;
        }

        /// <summary>
        /// Set width of hexahedron
        /// </summary>
        /// <param name="width"></param>
        public void SetWidth(Dimension width)
        {
            this.width = width;
        }

        /// <summary>
        /// Set height of hexahedron
        /// </summary>
        /// <param name="height"></param>
        public void SetHeight(Dimension height)
        {
            this.height = height;
        }

        /// <summary>
        /// Set depth of hexahedron
        /// </summary>
        /// <param name="depth"></param>
        public void SetDepth(Dimension depth)
        {
            this.depth = depth;
        }

        /// <summary>
        ///  Hexahedron Id
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Center point of hexahedron
        /// </summary>
        public Point3D center { get; private set; }

        /// <summary>
        /// Hexahedron size on X axis
        /// </summary>
        public Dimension width { get; protected set; }

        /// <summary>
        /// Hexahedron size on Y axis
        /// </summary>
        public Dimension height { get; protected set; }

        /// <summary>
        /// Hexahedron size on Z axis
        /// </summary>
        public Dimension depth { get; protected set; }

        private Collection<Point3D> _Vertexs = null;

        /// <summary>
        /// Collection of hexahedron's vertexs
        /// </summary>
        public Collection<Point3D> Vertexs
        {
            get
            {
                // Using the Singleton pattern to instantiate vertexs only first time they are requested
                if (_Vertexs == null)
                {
                    Dictionary<SegmentSide, Point1D> SegmentConfiguration;

                    SegmentConfiguration = new Dictionary<SegmentSide, Point1D>();
                    SegmentConfiguration.Add(SegmentSide.Start, Point1D.Create(center.value[Axis.x].value - (width.value / 2)));
                    SegmentConfiguration.Add(SegmentSide.End, Point1D.Create(center.value[Axis.x].value + (width.value / 2)));
                    Segment xSegment = Segment.Create(SegmentConfiguration);

                    SegmentConfiguration = new Dictionary<SegmentSide, Point1D>();
                    SegmentConfiguration.Add(SegmentSide.Start, Point1D.Create(center.value[Axis.y].value - (height.value / 2)));
                    SegmentConfiguration.Add(SegmentSide.End, Point1D.Create(center.value[Axis.y].value + (height.value / 2)));
                    Segment ySegment = Segment.Create(SegmentConfiguration);

                    SegmentConfiguration = new Dictionary<SegmentSide, Point1D>();
                    SegmentConfiguration.Add(SegmentSide.Start, Point1D.Create(center.value[Axis.z].value - (depth.value / 2)));
                    SegmentConfiguration.Add(SegmentSide.End, Point1D.Create(center.value[Axis.z].value + (depth.value / 2)));
                    Segment zSegment = Segment.Create(SegmentConfiguration);

                    _Vertexs = new Collection<Point3D>();

                    Dictionary<Axis, Point1D> coordenates;
                    
                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.Start].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.Start].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.Start].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.Start].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.End].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.End].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.Start].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.End].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                    coordenates = new Dictionary<Axis, Point1D>();
                    coordenates.Add(Axis.x, Point1D.Create(xSegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.y, Point1D.Create(ySegment.value[SegmentSide.End].value));
                    coordenates.Add(Axis.z, Point1D.Create(zSegment.value[SegmentSide.End].value));
                    _Vertexs.Add(Point3D.Create(coordenates));

                }

                return _Vertexs;
            }
        }

        /// <summary>
        /// Volume of hexahedron
        /// </summary>
        public Volume volume
        {
            get
            {
                return Volume.Create(width.value * height.value * depth.value);
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
