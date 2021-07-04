using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing;

namespace MyGerberConverter
{
    public class GerberParser: Object
    {
        //private string filePath;
        private List<string> fileLines;                                         // Storing whole file in memory may not make sense later but it'll do for now
        private RegexOptions regexOptions;
        public List<IAperture> objectList;
        private List<LineSegment> flashSegment;
        //State variables
        public Unit unitMessure { set; get; }
        private Dictionary<int, IAperture> apertureDictionary;
        private int currentApertureID;

        //StreamWriter outTextFile;
 
        public void ParseGerberFile(string filePath)
        {
            //this.filePath = filePath;
            //this.outTextFile = new StreamWriter(filePath + "_");

            this.fileLines = File.ReadAllLines(filePath).ToList();
            this.regexOptions = RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
            this.objectList = new List<IAperture>();
            this.flashSegment = new List<LineSegment>();
            this.unitMessure = Unit.Inch;
            this.apertureDictionary = new Dictionary<int, IAperture>();
            this.currentApertureID = 0;


            foreach (string line in fileLines)
            {
                if (line.StartsWith("%FS"))
                {
                    continue;
                }
                else if (line.StartsWith("%MO"))
                {
                    GerUnit(line);
                }
                else if (line.StartsWith("%ADD"))
                {
                    AddApetrureToDictionary(line);
                }
                else if (line.StartsWith("G54"))
                {
                    //CreateFlashSegment();
                    GetApertureID(line);
                }
                else if (line.StartsWith("X"))
                {
                    CreateObjectList(line);
                }
            }
        }

        //private void CreateFlashSegment()
        //{
            //if (flashSegment != null && flashSegment.Count != 0)
            //{
            //    IAperture aperture = apertureDictionary[currentApertureID];
            //    objectList.Add(aperture.CreateInstance(new Point(0, 0)));
            //    objectList.Last().segmentList = flashSegment;
            //    flashSegment = new List<LineSegment>();
            //}
        //}

        private void CreateObjectList(string line)
        {
            //X+1377Y+335D03*
            string expression = @"X (?<xDimension>[-+]?[0-9]*\.?[0-9]+) Y (?<yDimension>[-+]?[0-9]*\.?[0-9]+) D (?<ID_command>\d+)";
            Regex r = new Regex(expression, regexOptions);

            Match match = r.Match(line);
            if (!match.Success)
                throw new NotImplementedException("Could not match" + line); //Console.WriteLine("Could not match {0}", line);
            else
            {
                int ID_command = Int32.Parse(match.Groups["ID_command"].Value);
                float X_position = NormalisationsNuber(float.Parse(match.Groups["xDimension"].Value));
                float Y_position = NormalisationsNuber(float.Parse(match.Groups["yDimension"].Value));
                IAperture aperture = apertureDictionary[currentApertureID];
                //objectList.Add(aperture.CreateInstance(new Point(x, y)));
                switch (ID_command)
                {
                    case 1:
                        // D01Proc();

                        AddSegment(X_position, Y_position);
                        //outTextFile.WriteLine(line);
                        break;
                    case 2:
                        //D02Proc();
                        if (objectList.Count == 0)
                        {
                            objectList.Add(aperture.CreateInstance(new Point(X_position, Y_position)));
                            objectList.Last().type = "Flash";
                            AddSegment(X_position, Y_position);
                        }
                        if (objectList.Last().segmentList.Count < 2)//2 or 4 vertex
                            objectList.RemoveAt(objectList.Count - 1);
                        objectList.Add(aperture.CreateInstance(new Point(X_position, Y_position)));
                        objectList.Last().type = "Flash";
                        //outTextFile.WriteLine(line);
                        break;
                    case 3:
                        objectList.Add(aperture.CreateInstance(new Point(X_position, Y_position)));
                        objectList.Last().Segmentation();
                        break;
                }
            }
        }

        private void AddSegment(float x_position, float y_position)
        {
            if (objectList.Last().segmentList == null)
            {
                objectList.Last().segmentList = new List<LineSegment>();
                objectList.Last().segmentList.Add(new LineSegment(objectList.Last().center, new Point(x_position, y_position)));
            }
            else
            {
                objectList.Last().segmentList.Add(new LineSegment(objectList.Last().segmentList.Last().B, new Point(x_position, y_position)));
            }
            
        }

        public void D01Proc(float X_position, float Y_position)
        {
            //flashSegment.Add(new LineSegment(new Point(X_position, Y_position),null ));
            flashSegment.Last().B = new Point(X_position, Y_position);
            flashSegment.Add(new LineSegment(new Point(X_position, Y_position), flashSegment.First().A));
            //outTextFile.WriteLine(line);
        }

        public void D02Proc(float X_position, float Y_position)
        {
            if (flashSegment.Count == 0)
            {
                flashSegment.Add(new LineSegment(new Point(X_position, Y_position), null));
                // outTextFile.WriteLine(line);
            }
            else
            {
                //flashSegment.RemoveAt(flashSegment.Count - 1);
            }
        }
        private void AddApetrureToDictionary(string line)
        {
            string expression = @"%ADD (?<apertureID>\d+) (?<type>[A-Z]),";
            Regex r = new Regex(expression, regexOptions);
            Match match = r.Match(line);

            switch (match.Groups["type"].Value)
            {
                case "R":
                    AddRectToDictionary(line);
                    break;
                case "C":
                    AddCircleToDictionary(line);
                    break;
            }

        }

        private void GetApertureID(string line)
        {
            //G54D10*
            string expression = @"G54D (?<apertureID>\d+)";
            Regex r = new Regex(expression, regexOptions);
            Match match = r.Match(line);

            if (!match.Success)
                throw new NotImplementedException("Could not match" + line); //Console.WriteLine("Could not match {0}", line);
            else
            {
                int apertureID = Int32.Parse(match.Groups["apertureID"].Value);
                currentApertureID = apertureID;
            }
        }

        private void AddCircleToDictionary(string line)
        {
            //throw new NotImplementedException();
            string expression = @"%ADD (?<apertureID>\d+) (?<type>[A-Z]), (?<xDimension>[-+]?[0-9]*\.?[0-9]+) \*%";
            Regex r = new Regex(expression, regexOptions);
            Match match = r.Match(line);

            if (!match.Success)
            {
                throw new NotImplementedException("Could not match" + line); //Console.WriteLine("Could not match {0}", line);
            }
            else
            {
                int apertureID = Int32.Parse(match.Groups["apertureID"].Value);

                NumberFormatInfo en_US = new CultureInfo("en-US", false).NumberFormat;
                float x = float.Parse(match.Groups["xDimension"].Value, en_US);
                apertureDictionary.Add(apertureID, new CircleApetrure(new Point(), x, "C"));
            }
        }

        private void AddRectToDictionary(string line)
        {
            //throw new NotImplementedException();
            string expression = @"%ADD (?<apertureID>\d+) (?<type>[A-Z]), (?<xDimension>[-+]?[0-9]*\.?[0-9]+) X (?<yDimension>[-+]?[0-9]*\.?[0-9]+) \*%";
            Regex r = new Regex(expression, regexOptions);
            Match match = r.Match(line);

            if (!match.Success)
            {
                throw new NotImplementedException("Could not match" + line); //Console.WriteLine("Could not match {0}", line);
            }
            else
            {
                int apertureID = Int32.Parse(match.Groups["apertureID"].Value);

                NumberFormatInfo en_US = new CultureInfo("en-US", false).NumberFormat;
                float x = float.Parse(match.Groups["xDimension"].Value, en_US);
                float y = float.Parse(match.Groups["yDimension"].Value, en_US);
                apertureDictionary.Add(apertureID, new RectApetrure(new Point(), x, y, "R"));
            }
        }

        private float NormalisationsNuber(float number)
        {
            return (number) / 10000;
        }

        private void GerUnit(string line)
        {
            if (line.Contains("IN"))
            {
                this.unitMessure = Unit.Inch;
            }
            else
            {
                this.unitMessure = Unit.Millimeter;
                //throw new NotImplementedException();
            }
        }

        public static double ToMillimeter(double inch)
        {
            return inch * 25.4; // / 0.0393700787402;
        }
    }

    public enum Unit
    {
        Inch,
        Millimeter
    }
}

