using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing;

namespace MyGerberConverter
{
    public partial class Form1 : Form
    {
        private GerberParser gerber;
        private GeneratorGCode gCode;

        public Form1()
        {
            InitializeComponent();
            gerber = new GerberParser();
            gCode = new GeneratorGCode();
            this.numericCuttingSpeed.Value = GeneratorGCode.cutSpeed;
            this.numericMoveSpeed.Value = GeneratorGCode.MoveSpeed;
            this.numericLaserPWR.Value = GeneratorGCode.LaserPWR;
        }

        private void fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gCode = new GeneratorGCode();
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                gerber.ParseGerberFile(openFileDialog1.FileName);

                Invalidate();
            }
        }

        private void fileSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                gCode.CreateGCodeFile(saveFileDialog1.FileName, gerber);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gerber == null || gerber.objectList == null)
                return;

            Graphics g = e.Graphics;
            g.Transform = new Matrix(1.0f, 0.0f, 0.0f, -1.0f, 3.0f, 2.0f);
            //g.ScaleTransform(2.0f, 2.0f);
            float scale=this.ViewScale.Value/10.0f;
            g.ScaleTransform(scale, scale);

            if (gerber.unitMessure == Unit.Inch)
                g.PageUnit = GraphicsUnit.Inch;
            else 
                g.PageUnit = GraphicsUnit.Millimeter;

            g.DrawLine(new Pen(Color.Red, 0.01F), 0.1f, 0.0f, -0.1f, 0.0f);
            g.DrawLine(new Pen(Color.Red, 0.01F), 0.0f, 0.1f, 0.0f, -0.1f);

            foreach (IAperture obj in gerber.objectList)
            {
                foreach (LineSegment line in obj.segmentList)
                {
                    g.DrawLine(new Pen(Color.Black,0.0012f), line.A.x, line.A.y, line.B.x, line.B.y);
                    //g.DrawLine(new Pen(Color.Black, 0.1f), line.A.x * 25.4f, line.A.y * 25.4f, line.B.x * 25.4f, line.B.y * 25.4f);
                    //g.DrawLine(new Pen(Color.Blue), 0+i, 0+i, 20+i*2, 20 + i * 2);
                    // i++;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //gcode.Close();
        }

        private void MoveSpeed_ValueChanged(object sender, EventArgs e)
        {
            GeneratorGCode.MoveSpeed = (int)numericMoveSpeed.Value;
        }

        private void CuttingSpeed_ValueChanged(object sender, EventArgs e)
        {
            GeneratorGCode.cutSpeed = (int)numericCuttingSpeed.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cutPositions_ValueChanged(object sender, EventArgs e)
        {
            GeneratorGCode.LaserPWR = (int)numericLaserPWR.Value;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Scale(object sender, EventArgs e)
        {
            Form1.ActiveForm.Refresh();
        }

    }
}
