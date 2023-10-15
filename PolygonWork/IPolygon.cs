using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonWork
{
  
    public interface IPolygon
    {
        int NumOfVertices { get; }
        Point[] Vertices { get; }

        void SetVertex(int index, double x, double y);
        bool IsRectangle();
        bool IsTriangle();
        double CalculateArea();
        bool IsRightAngle(Point p1, Point p2, Point p3);
        double Distance(Point p1, Point p2);

    }

}
