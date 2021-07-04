using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGerberConverter
{
    public class LineSegment
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public LineSegment(Point pointA, Point pointB)
        {
            this.A = pointA;
            this.B = pointB;
        }

        public static void IsHorizontal(List<LineSegment> destinations, LineSegment obj)
        {
            if (destinations == null)
                destinations = new List<LineSegment>();
            if (obj.B.y == obj.A.y)
            {
                destinations.Add(obj);
            }
        }

        public static void IsVertical(List<LineSegment> destinations, LineSegment obj)
        {
            if (destinations == null)
                destinations = new List<LineSegment>();
            if (obj.B.x==obj.A.x)
            {
                destinations.Add(obj);
            }
        }
    }
}
