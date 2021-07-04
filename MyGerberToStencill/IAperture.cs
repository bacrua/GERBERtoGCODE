using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGerberConverter
{
    public interface IAperture
    {
        string type { set; get; }
        Point center { get; set; }
        List<LineSegment> segmentList { get; set; }
        IAperture CreateInstance(Point centerLocations);
        void Segmentation();
 
    }

    public class Point
    {
        public float x;
        public float y;
        public Point(float x =0, float y =0)
        {
            this.x = x;
            this.y = y;
        }
    }
}
