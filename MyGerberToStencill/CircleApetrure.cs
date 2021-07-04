using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyGerberConverter
{
    public class CircleApetrure : IAperture
    {
        public string type { get; set; }
        public Point center { get; set; }
        public float radius { get; set; }
        public List<LineSegment> segmentList { get; set; }
        public CircleApetrure(Point centerLocations, float radius, string typeAperture)
        {
            center = centerLocations;
            this.radius = radius;
            this.type = typeAperture;
        }

        public IAperture CreateInstance(Point centerLocations)
        {
            return new CircleApetrure(centerLocations, this.radius, this.type);
        }

        public void Segmentation()
        {
            //MetodRectangle();
            MetodCircle();

        }

        private void MetodRectangle()
        {
            if (segmentList == null)
                segmentList = new List<LineSegment>();
            else
            {
                segmentList.Clear();
            }
            //       2
            //   x-------x
            //   |       |
            // 3 |   o   | 4
            //   |       |
            //   x-------x
            //       1
            float delta = (radius / 2);
            segmentList.Add(new LineSegment(
                new Point(center.x - delta, center.y - delta),
                new Point(center.x + delta, center.y - delta)));
            segmentList.Add(new LineSegment(
                new Point(center.x - delta, center.y + delta),
                new Point(center.x + delta, center.y + delta)));
            segmentList.Add(new LineSegment(
                new Point(center.x - delta, center.y - delta),
                new Point(center.x - delta, center.y + delta)));
            segmentList.Add(new LineSegment(
                new Point(center.x + delta, center.y - delta),
                new Point(center.x + delta, center.y + delta)));
        }

        private void MetodCircle()
        {
            if (segmentList == null)
                segmentList = new List<LineSegment>();
            else
            {
                segmentList.Clear();
            }
            double r = this.radius / 2;
            double twoRad = 0.0175;// (2 deg * 180 / 3.1416F);
            Point pointA = new Point(center.x, (center.y + (float)r));
 
            for (int i = 0; i < 360; i +=2)
            {
                double x = Math.Sin(twoRad*i) * r + center.x;
                double y = Math.Cos(twoRad *i)*r + center.y;
                segmentList.Add(new LineSegment(pointA, null));
                segmentList.Last().B = new Point((float)x, (float)y);
                pointA = new Point((float)x, (float)y);
                //segmentList.Add(new LineSegment(segmentList.Last().B, null));
            }
            //segmentList.Last().B = new Point();
            segmentList.First().A = segmentList.Last().B;
        } 
    }
}
