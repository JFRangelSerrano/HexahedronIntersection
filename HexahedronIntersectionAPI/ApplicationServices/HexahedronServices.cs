using HexahedronIntersectionAPI.Commands;
using HexahedronIntersectionAPI.Queries;
using HexahedronIntersectionDomain;
using HexahedronIntersectionDomain.Entities;
using HexahedronIntersectionDomain.Repositories;
using HexahedronIntersectionDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexahedronIntersectionAPI.ApplicationServices
{
    public class HexahedronServices
    {
        private readonly IHexahedronRepository repository;
        private readonly HexahedronQueries queries;

        public HexahedronServices(IHexahedronRepository repository, HexahedronQueries queries)
        {
            this.repository = repository;
            this.queries = queries;
        }



        #region Public Services

        /// <summary>
        /// Executes a command to create an hexahedron
        /// </summary>
        /// <param name="createHexahedronCommand">Create command</param>
        /// <returns></returns>
        public async Task<bool> HandlerCommand(CreateHexahedronCommand createHexahedronCommand)
        {
            // Hexahedron Id is created
            var hexahedronId = HexahedronId.Create(createHexahedronCommand.hexahedronId);

            // Hexahedron is created (using Guid operator that allows cast HexahedronId as Guid)
            var hexahedron = new Hexahedron(hexahedronId);

            // Hexahedron center is created and assigned
            var centerX = Point1D.Create(createHexahedronCommand.centerX);
            var centerY = Point1D.Create(createHexahedronCommand.centerY);
            var centerZ = Point1D.Create(createHexahedronCommand.centerZ);
            var center = new Dictionary<Axis, Point1D>();
            center.Add(Axis.x, centerX);
            center.Add(Axis.y, centerY);
            center.Add(Axis.z, centerZ);
            var hexahedronCenter = Point3D.Create(center);
            hexahedron.SetCenter(hexahedronCenter);

            // Hexahedron width is created and assigned
            var widthDimension = Dimension.Create(createHexahedronCommand.width);
            hexahedron.SetWidth(widthDimension);

            // Hexahedron height is created and assigned
            var heightDimension = Dimension.Create(createHexahedronCommand.height);
            hexahedron.SetHeight(heightDimension);

            // Hexahedron depth is created and assigned
            var depthDimension = Dimension.Create(createHexahedronCommand.depth);
            hexahedron.SetDepth(depthDimension);

            // Add hexahedron to repository
            return await repository.AddHexahedron(hexahedron);
        }

        /// <summary>
        /// Executes a command to remove an hexahedron
        /// </summary>
        /// <param name="removeHexahedronCommand">Remove command</param>
        /// <returns></returns>
        public async Task HandlerCommand(RemoveHexahedronCommand removeHexahedronCommand)
        {

            var hexahedron = await queries.GetHexahedronByIdAsync(removeHexahedronCommand.hexahedronId);
            repository.RemoveHexahedron(hexahedron);
        }

        /// <summary>
        /// Gets an hexahedron by Id
        /// </summary>
        /// <param name="id">Hexahedron Id</param>
        /// <returns></returns>
        public async Task<Hexahedron> GetHexahedron(Guid id)
        {
            return await queries.GetHexahedronByIdAsync(id);
        }

        /// <summary>
        /// Returns intersection hexahedron between two hexahedrons if exists. Else, returns null.
        /// </summary>
        /// <param name="hexahedronOneId">First hexahedron Id</param>
        /// <param name="hexahedronTwoId">Second hexahedron Id</param>
        /// <param name="hexahedronIntersectionId">Intersection hexahedron Id</param>
        public async Task<Hexahedron> GetIntersection(Guid hexahedronOneId, Guid hexahedronTwoId, Guid hexahedronIntersectionId)
        {
            var hexahedron1 = await queries.GetHexahedronByIdAsync(hexahedronOneId);
            var hexahedron2 = await queries.GetHexahedronByIdAsync(hexahedronTwoId);

            if (hexahedron1 == null || hexahedron2 == null)
            {
                //There is not intersection
                return null;
            }
            else
            {
                //Get intersecion segment on each axis
                Segment xSegmentIntersection = GetSegmentIntersectionOnAxis(hexahedron1, hexahedron2, Axis.x);
                Segment ySegmentIntersection = GetSegmentIntersectionOnAxis(hexahedron1, hexahedron2, Axis.y);
                Segment zSegmentIntersection = GetSegmentIntersectionOnAxis(hexahedron1, hexahedron2, Axis.z);

                if (xSegmentIntersection == null || ySegmentIntersection == null || zSegmentIntersection == null)
                {
                    //There is not hexahedron intersection
                    return null;
                }
                else
                {
                    // Creates hexahedron intersection center point
                    Dictionary<Axis, Point1D> centerCoordenates = new Dictionary<Axis, Point1D>();
                    centerCoordenates.Add(Axis.x, Point1D.Create((xSegmentIntersection.value[SegmentSide.Start].value + xSegmentIntersection.value[SegmentSide.End].value) / 2));
                    centerCoordenates.Add(Axis.y, Point1D.Create((ySegmentIntersection.value[SegmentSide.Start].value + ySegmentIntersection.value[SegmentSide.End].value) / 2));
                    centerCoordenates.Add(Axis.z, Point1D.Create((zSegmentIntersection.value[SegmentSide.Start].value + zSegmentIntersection.value[SegmentSide.End].value) / 2));
                    Point3D center = Point3D.Create(centerCoordenates);
                        
                    // Creates hexahedron intersection dimensions
                    Dimension width = Dimension.Create(xSegmentIntersection.value[SegmentSide.End].value - xSegmentIntersection.value[SegmentSide.Start].value);
                    Dimension height = Dimension.Create(ySegmentIntersection.value[SegmentSide.End].value - ySegmentIntersection.value[SegmentSide.Start].value);
                    Dimension depth = Dimension.Create(zSegmentIntersection.value[SegmentSide.End].value - zSegmentIntersection.value[SegmentSide.Start].value);

                    // Creates hexahedron intersection
                    Hexahedron intersection = new Hexahedron(hexahedronIntersectionId);
                    intersection.SetCenter(center);
                    intersection.SetWidth(width);
                    intersection.SetHeight(height);

                    //Returns hexahedron intersection
                    return intersection;
                }
            }
        }

        #endregion





        #region Private static functions

        /// <summary>
        /// Returns common segment on a axis between two hexahedrons if exists. Else, returns null.
        /// </summary>
        /// <param name="hexahedron1">First hexahedron</param>
        /// <param name="hexahedron2">Second hexahedron</param>
        /// <param name="axis">Axis</param>
        /// <returns></returns>
        private static Segment GetSegmentIntersectionOnAxis(Hexahedron hexahedron1, Hexahedron hexahedron2, Axis axis)
        {
            if (hexahedron1 == null || hexahedron2 == null)
            {
                //There is not segment intersection
                return null;
            }
            else
            {
                // Study the cross of both hexahedron on selected axis and return common segment
                IEnumerable<decimal> hexahedron1SegmentValues = hexahedron1.Vertexs.Select(v => v.value[axis].value).Distinct();
                IEnumerable<decimal> hexahedron2SegmentValues = hexahedron2.Vertexs.Select(v => v.value[axis].value).Distinct();

                Dictionary<SegmentSide, Point1D> SegmentLimits;

                SegmentLimits = new Dictionary<SegmentSide, Point1D>();
                SegmentLimits.Add(SegmentSide.Start, Point1D.Create(hexahedron1SegmentValues.Min()));
                SegmentLimits.Add(SegmentSide.End, Point1D.Create(hexahedron1SegmentValues.Max()));
                Segment hexahedron1Segment = Segment.Create(SegmentLimits);

                SegmentLimits = new Dictionary<SegmentSide, Point1D>();
                SegmentLimits.Add(SegmentSide.Start, Point1D.Create(hexahedron2SegmentValues.Min()));
                SegmentLimits.Add(SegmentSide.End, Point1D.Create(hexahedron2SegmentValues.Max()));
                Segment hexahedron2Segment = Segment.Create(SegmentLimits);

                return GetSegmentIntersection(hexahedron1Segment, hexahedron2Segment);
            }
        }

        /// <summary>
        /// Returns intersection segment between two segment if exists. Else, returns null.
        /// </summary>
        /// <param name="segment1">First segment</param>
        /// <param name="segment2">Second segment</param>
        /// <returns></returns>
        private static Segment GetSegmentIntersection(Segment segment1, Segment segment2)
        {
            if (!ExistsIntersection(segment1, segment2))
            {
                //There is not segment intersection
                return null;
            }
            else
            {
                //Return common segment to both segments
                Dictionary<SegmentSide, Point1D> SegmentLimits;
                SegmentLimits = new Dictionary<SegmentSide, Point1D>();
                SegmentLimits.Add(SegmentSide.Start, Point1D.Create(Math.Max(segment1.value[SegmentSide.Start].value, segment2.value[SegmentSide.Start].value)));
                SegmentLimits.Add(SegmentSide.End, Point1D.Create(Math.Min(segment1.value[SegmentSide.End].value, segment2.value[SegmentSide.End].value)));
                return Segment.Create(SegmentLimits);
            }
        }

        /// <summary>
        /// Determines if exists intersection between two segments
        /// </summary>
        /// <param name="segment1">First segment</param>
        /// <param name="segment2">Second segment</param>
        /// <returns></returns>
        private static bool ExistsIntersection(Segment segment1, Segment segment2)
        {
            if (segment1 == null || segment1 == null)
            {
                //There is not segment intersection
                return false;
            }
            else
            {
                //Order ascending both segments by start value
                List<Segment> OrderedSegments = new List<Segment>();
                OrderedSegments.Add(segment1);
                OrderedSegments.Add(segment2);
                OrderedSegments = OrderedSegments.OrderBy(s => s.value[SegmentSide.Start].value).ToList();

                //If start value of last segment is greather or equal than end value of first segment, there is not intersection
                return !(OrderedSegments.Last().value[SegmentSide.Start].value >= OrderedSegments.First().value[SegmentSide.End].value);
            }
        }

        #endregion

    }
}
