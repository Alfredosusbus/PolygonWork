using PolygonWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace PolygonWorkTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PolygonTests
    {
        [TestMethod]
        public void TestSetVertex_ValidIndex_SetsVertex()
        {
            // Arrange
            Polygon polygon = new Polygon(3);

            // Act
            polygon.SetVertex(0, 1.0, 2.0);

            // Assert
            Assert.AreEqual(1.0, polygon.vertices[0].X);
            Assert.AreEqual(2.0, polygon.vertices[0].Y);
        }

        [TestMethod]
        public void SetVertex_ZeroIndex_SetsVertex()
        {
            // Arrange
            int numOfVertices = 3;
            PolygonWork.Polygon polygon = new PolygonWork.Polygon(numOfVertices);
            double x = 1.0;
            double y = 2.0;
            int zeroIndex = 0;

            // Act
            polygon.SetVertex(zeroIndex, x, y);

            // Assert
            Assert.AreEqual(x, polygon.vertices[zeroIndex].X);
            Assert.AreEqual(y, polygon.vertices[zeroIndex].Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetVertex_InvalidIndex_ThrowsException()
        {
            // Arrange
            int numOfVertices = 3;
            PolygonWork.Polygon polygon = new PolygonWork.Polygon(numOfVertices);
            double x = 2.5;
            double y = 3.0;
            int invalidIndex = 5;

            // Act
            polygon.SetVertex(invalidIndex, x, y);

            // Assert is handled by ExpectedException attribute
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetVertex_InvalidIndex_ThrowsArgumentException()
        {
            // Arrange
            Polygon polygon = new Polygon(3);

            // Act
            polygon.SetVertex(3, 1.0, 2.0);
        }

        [TestMethod]
        public void TestIsRectangle_ValidRectangle_ReturnsTrue()
        {
            // Arrange
            Polygon rectangle = new Polygon(4);
            rectangle.SetVertex(0, 0, 0);
            rectangle.SetVertex(1, 0, 1);
            rectangle.SetVertex(2, 1, 1);
            rectangle.SetVertex(3, 1, 0);

            // Act
            bool result = rectangle.IsRectangle();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsRectangle_NotEnoughVertices_ReturnsFalse()
        {
            // Arrange
            Polygon triangle = new Polygon(3);
            triangle.SetVertex(0, 0, 0);
            triangle.SetVertex(1, 0, 1);
            triangle.SetVertex(2, 1, 0);

            // Act
            bool result = triangle.IsRectangle();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestIsRightAngle_RightAnglePoints_ReturnsTrue()
        {
            // Arrange
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);
            Point p3 = new Point(1, 0);

            // Act
            bool result = new Polygon(3).IsRightAngle(p1, p2, p3);

            // Assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestIsTriangle_ValidTriangle_ReturnsTrue()
        {
            // Arrange
            Polygon triangle = new Polygon(3);
            triangle.SetVertex(0, 0, 0);
            triangle.SetVertex(1, 0, 1);
            triangle.SetVertex(2, 1, 0);

            // Act
            bool result = triangle.IsTriangle();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsTriangle_NotEnoughVertices_ReturnsFalse()
        {
            // Arrange
            Polygon line = new Polygon(2);
            line.SetVertex(0, 0, 0);
            line.SetVertex(1, 1, 1);

            // Act
            bool result = line.IsTriangle();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCalculateArea_Square_ReturnsCorrectArea()
        {
            // Arrange
            Polygon square = new Polygon(4);
            square.SetVertex(0, 0, 0);
            square.SetVertex(1, 0, 1);
            square.SetVertex(2, 1, 1);
            square.SetVertex(3, 1, 0);

            // Act
            double result = square.CalculateArea();

            // Assert
            Assert.AreEqual(1.0, result);
        }

  
            [TestMethod]
            public void CalculateArea_Triangle_ReturnsCorrectArea()
            {
                // Arrange
                Polygon polygon = new Polygon(3);
                polygon.vertices[0] = new PolygonWork.Point(0, 0);
                polygon.vertices[1] = new PolygonWork.Point(4, 0);
                polygon.vertices[2] = new PolygonWork.Point(0, 3);

                // Act
                double area = polygon.CalculateArea();

                // Assert
                Assert.AreEqual(6.0, area, 0.001); // Using delta for double comparison
            }

            [TestMethod]
            public void CalculateArea_Square_ReturnsCorrectArea()
            {
                // Arrange
                Polygon polygon = new Polygon(4);
                polygon.vertices[0] = new PolygonWork.Point(0, 0);
                polygon.vertices[1] = new PolygonWork.Point(4, 0);
                polygon.vertices[2] = new PolygonWork.Point(4, 4);
                polygon.vertices[3] = new PolygonWork.Point(0, 4);

                // Act
                double area = polygon.CalculateArea();

                // Assert
                Assert.AreEqual(16.0, area, 0.001);
            }

       
    [TestMethod]
        public void TestDistance_DistanceBetweenPoints_ReturnsCorrectDistance()
        {
            // Arrange
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);

            // Act
            double result = new Polygon(3).Distance(p1, p2);

            // Assert
            Assert.AreEqual(5.0, result);
        }

      
        [TestMethod]
        public void Distance_ShouldReturnZero_WhenPointsAreEqual()
        {
            // Arrange
            Point p1 = new Point(1, 2);
            Point p2 = new Point(1, 2);
            Polygon polygon = new Polygon(3);

            // Act
            double result = polygon.Distance(p1, p2);

            // Assert
            Assert.AreEqual(0, result, 0.0001); // 0.0001 is the tolerance for double comparison
        }

        [TestMethod]
        public void Distance_ShouldCalculateDistance_WhenPointsAreDifferent()
        {
            // Arrange
            Point p1 = new Point(1, 2);
            Point p2 = new Point(4, 6);
            Polygon polygon = new Polygon(3);

            // Act
            double result = polygon.Distance(p1, p2);

            // Assert
            Assert.AreEqual(5, result, 0.0001);
        }

    


    }

}





