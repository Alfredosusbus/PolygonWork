using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonWork
{
  public class Program
    {
        static void Main()
        {
            // Приклад використання класу Polygon
            Polygon polygon = new Polygon(4);
            polygon.SetVertex(0, 0, 0);
            polygon.SetVertex(1, 0, 1);
            polygon.SetVertex(2, 1, 1);
            polygon.SetVertex(3, 1, 0);

            bool isRectangle = polygon.IsRectangle();
            bool isTriangle = polygon.IsTriangle();
            double area = polygon.CalculateArea();

            //Console.WriteLine($"Is Rectangle: {isRectangle}");
            //Console.WriteLine($"Is Triangle: {isTriangle}");
            //Console.WriteLine($"Area: {area}");
        }
    }
}
