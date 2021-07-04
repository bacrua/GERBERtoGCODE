using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace MyGerberConverter
{
    class GeneratorGCode
    {
        GerberParser gerber;
        StreamWriter gcode;
        public static int MoveSpeed = 500;
        public static int cutSpeed = 60;
        public static int UpDownSpeed = 1500;
        public static int LaserPWR = 100;

        private List<LineSegment> allHorizontal;
        private List<LineSegment> allVertical;
        private List<IAperture> circle;
        private List<IAperture> flash;
        private List<IAperture> rect;

        public void CreateGCodeFile(string filename, GerberParser gerber)
        {
            circle = new List<IAperture>();
            flash = new List<IAperture>();
            rect = new List<IAperture>();

            gcode = new StreamWriter(filename);
            this.gerber = gerber;
            gcode.WriteLine("G21");
            //gcode.WriteLine("G91");
            LaserOFF();
            SortObject();
            //TranslateLineToCode(allVertical);
            //TranslateLineToCode(allHorizontal);
            //TranslateCircleToCode(allCircle);
            //TranslateFlashToCode(allFlash);
            gcode.Close();
        }

        private void TranslateLineToCode(List<LineSegment> lines)
        {
                if (lines == null || lines.Count == 0)
                    return;

               MoveTo(lines.First().A.x, lines.First().A.y);
            LaserON(LaserPWR);
            lines.Remove(lines.Last());
                foreach (LineSegment seg in lines)
                {
                     gcode.WriteLine("G1 X" + GCodeDouble(seg.B.x) + " Y" + GCodeDouble(seg.B.y) + " F" + GCodeInt(cutSpeed) + "; STOP cut position");
                }
                gcode.WriteLine("G1 X" + GCodeDouble(lines.First().A.x) + " Y" + GCodeDouble(lines.First().A.y) + " F" + GCodeInt(cutSpeed) + "; START cut position");
            LaserOFF();
        }

        private void TranslateCircleToCode(List<LineSegment> lines)
        {
            if (lines == null || lines.Count == 0)
                return;
            LaserOFF();
            MoveTo(lines.First().A.x, lines.First().A.y);
            LaserON(LaserPWR);
            foreach (LineSegment seg in lines)
            {
                gcode.WriteLine("G1 X" + GCodeDouble(seg.B.x) + " Y" + GCodeDouble(seg.B.y) + " F" + GCodeInt(cutSpeed) + "; STOP cut position");
            }
            LaserOFF();
        }

        private void TranslateFlashToCode(List<LineSegment> lines)
        {
            TranslateLineToCode(lines);
        }

        private void SortObject()
        {

            foreach (IAperture translateObj in gerber.objectList)
            {
                switch (translateObj.type)
                {
                    case "Flash":
                        flash.Add(translateObj);
                        break;
                    case "C":
                        circle.Add(translateObj);
                        break;
                    case "R":
                        rect.Add(translateObj);
                        break;
                }
            }

            RectToGcode();
            CircleToGcode();
            FlashToGcode();
        }

        private void FlashToGcode()
        {
            foreach (IAperture obj in flash)
                TranslateFlashToCode(obj.segmentList);
        }

        private void CircleToGcode()
        {
            foreach (IAperture obj in circle)
                TranslateCircleToCode(obj.segmentList);
        }

        private void RectToGcode()
        {
            ////foreach (IAperture obj in rect)
            ////    SeparationsRect(obj.segmentList);
            ////TranslateLineToCode(allHorizontal);
            ////TranslateLineToCode(allVertical);
            foreach (IAperture obj in rect)
             TranslateLineToCode(obj.segmentList);
        }

        private void SeparationsRect(List<LineSegment> segmentList)
        {
            if (allHorizontal == null && allVertical == null)
            {
                allHorizontal = new List<LineSegment>();
                allVertical = new List<LineSegment>();
            }
            foreach (LineSegment seg in segmentList)
            {
                LineSegment.IsHorizontal(allHorizontal,seg);
                LineSegment.IsVertical(allVertical, seg);
            }
        }

        private void LaserON(int val)
        {
            gcode.WriteLine("M3 S" + val);
        }

        private void LaserOFF(){
            gcode.WriteLine("M5"); 
        }
        private void MoveTo(float x, float y)
        {
            gcode.WriteLine("G0 X" + GCodeDouble(x) + " Y" + GCodeDouble(y) +
                " F" + GCodeInt(MoveSpeed) + "; Move to segnent start");
        }

        private string GCodeInt(float value)
        {
            return value.ToString();
        }

        private string GCodeDouble(float value)
        {
            if (this.gerber.unitMessure == Unit.Inch)
                value *= 25.4F;
            return string.Format(new CultureInfo("en-US"), "{0:F3}", value);
        }

    }
}
