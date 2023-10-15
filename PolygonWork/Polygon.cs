using System;

namespace PolygonWork
{
    public class Polygon
    {
        public int numOfVertices;
        public Point[] vertices;

        public Polygon(int numOfVertices)
        {
            this.numOfVertices = numOfVertices;
            this.vertices = new Point[numOfVertices];
        }

        public void SetVertex(int index, double x, double y)
        {
            if (index < 0 || index >= numOfVertices)
            {
                throw new ArgumentException("Invalid index");
            }

            vertices[index] = new Point(x, y);
            //throw new NotImplementedException();
        }

        public bool IsRectangle()
        {

            if (numOfVertices != 4)
            {
                return false;
            }


            for (int i = 0; i < numOfVertices; i++)
            {
                int nextIndex = (i + 1) % numOfVertices;
                int prevIndex = (i - 1 + numOfVertices) % numOfVertices;


                if (!IsRightAngle(vertices[prevIndex], vertices[i], vertices[nextIndex]))
                {
                    return false;
                }
            }

            return true;
            //throw new NotImplementedException();
        }

        public bool IsRightAngle(Point p1, Point p2, Point p3)
        {
            double[] sides = { Distance(p1, p2), Distance(p2, p3), Distance(p1, p3) };

            // Сортуємо сторони в порядку зростання
            Array.Sort(sides);

            // Використовуємо допуск для порівнянь з плаваючою комою
            double epsilon = 0.0001;

            // Перевіряємо за теоремою Піфагора
            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < epsilon
                && sides[0] > 0 && sides[1] > 0 && sides[2] > 0;
            //throw new NotImplementedException();
        }

        public bool IsTriangle()
        {

            if (numOfVertices != 3)
            {
                return false;
            }

            double side1 = Distance(vertices[0], vertices[1]);
            double side2 = Distance(vertices[1], vertices[2]);
            double side3 = Distance(vertices[0], vertices[2]);

            return (side1 + side2 > side3) && (side1 + side3 > side2) && (side2 + side3 > side1);
            //throw new NotImplementedException();
        }

        public double CalculateArea()
        {

            double area = 0.0;

            for (int i = 0; i < numOfVertices; i++)
            {
                int nextIndex = (i + 1) % numOfVertices;
                area += vertices[i].X * vertices[nextIndex].Y - vertices[nextIndex].X * vertices[i].Y;
            }

            return Math.Abs(area) / 2.0;
            //throw new NotImplementedException();
        }

        public double Distance(Point p1, Point p2)
        {
            double xDiff = p2.X - p1.X;
            double yDiff = p2.Y - p1.Y;

            double distance = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);

            return distance;

            // throw new NotImplementedException();
        }

    }

    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
