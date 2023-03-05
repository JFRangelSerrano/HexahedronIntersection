using HexahedronIntersection.GeometricForms;
using HexahedronIntersection.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HexahedronIntersectionUnitTest
{
    [TestClass]
    public class HexahedronIntersectionTester
    {

        [TestMethod]
        public void GetVolumeIntersectionBetweenTwoCubesThatIntersect()
        {
            var cube1 = new Cube(new Point(5, 7, 8), 6);
            var cube2 = new Cube(new Point(8, 3, 10), 6);

            var hexahedronIntersection = HexahedronIntersectionManager.GetIntersection(cube1, cube2);

            Assert.AreEqual(hexahedronIntersection.volume, 24);
        }

        [TestMethod]
        public void GetHexahedronIntersectionBetweenTwoCubesThatIntersect()
        {
            var cube1 = new Cube(new Point(5, 7, 8), 6);
            var cube2 = new Cube(new Point(8, 3, 10), 6);

            var hexahedronIntersection = HexahedronIntersectionManager.GetIntersection(cube1, cube2);

            Assert.AreEqual(hexahedronIntersection.center.x, (decimal)6.5);
            Assert.AreEqual(hexahedronIntersection.center.y, 5);
            Assert.AreEqual(hexahedronIntersection.center.z, 9);
            Assert.AreEqual(hexahedronIntersection.width, 3);
            Assert.AreEqual(hexahedronIntersection.height, 2);
            Assert.AreEqual(hexahedronIntersection.depth, 4);
        }

        [TestMethod]
        public void GetHexahedronIntersectionBetweenTwoHexahedronsThatIntersect()
        {
            var hexahedron1 = new Hexahedron(new Point(5, 7, 8), 6, 8, 6);
            var hexahedron2 = new Hexahedron(new Point(8, 3, 10), 8, 6, 6);

            var hexahedronIntersection = HexahedronIntersectionManager.GetIntersection(hexahedron1, hexahedron2);

            Assert.AreEqual(hexahedronIntersection.center.x, 6);
            Assert.AreEqual(hexahedronIntersection.center.y, (decimal)4.5);
            Assert.AreEqual(hexahedronIntersection.center.z, 9);
            Assert.AreEqual(hexahedronIntersection.width, 4);
            Assert.AreEqual(hexahedronIntersection.height, 3);
            Assert.AreEqual(hexahedronIntersection.depth, 4);
        }

        [TestMethod]
        public void GetNullAsIntersectionBetweenTwoHexahedronsThatNotIntersect()
        {
            var hexahedron1 = new Hexahedron(new Point(-25, -27, -28), 7, 8, 9);
            var hexahedron2 = new Hexahedron(new Point(28, 23, 30), 9, 8, 7);

            var hexahedronIntersection = HexahedronIntersectionManager.GetIntersection(hexahedron1, hexahedron2);

            Assert.IsNull(hexahedronIntersection);
        }

        [TestMethod]
        public void GetNullAsIntersectionIfAtLeastOneHexahedronIsNotDefined()
        {
            var hexahedron1 = new Hexahedron(new Point(-25, -27, -28), 7, 8, 9);

            var hexahedronIntersection = HexahedronIntersectionManager.GetIntersection(hexahedron1, null);

            Assert.IsNull(hexahedronIntersection);
        }

        [TestMethod]
        [ExpectedException(typeof(HexahedronDefinitionNotValidException), "Hexahedron center point must be defined.")]
        public void HexahedronCenterPointMustBeDefined()
        {
            var hexahedron = new Hexahedron(null, 8, 8, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(HexahedronDefinitionNotValidException), "Width must be greater than 0.")]
        public void HexahedronWidthMustBeGreaterThan0()
        {
            var hexahedron = new Hexahedron(new Point(-5, 10, 8), 0, 8, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(HexahedronDefinitionNotValidException), "Height must be greater than 0.")]
        public void HexahedronHeightMustBeGreaterThan0()
        {
            var hexahedron = new Hexahedron(new Point(-5, 10, 8), 5, -8, 9);
        }

        [TestMethod]
        [ExpectedException(typeof(HexahedronDefinitionNotValidException), "Depth must be greater than 0.")]
        public void HexahedronDepthMustBeGreaterThan0()
        {
            var hexahedron = new Hexahedron(new Point(-5, 10, 8), 5, 8, -9);
        }

    }
}
