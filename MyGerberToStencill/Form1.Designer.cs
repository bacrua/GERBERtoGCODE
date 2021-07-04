namespace MyGerberConverter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.numericMoveSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericCuttingSpeed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericLaserPWR = new System.Windows.Forms.NumericUpDown();
            this.ViewScale = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoveSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCuttingSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLaserPWR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewScale)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenToolStripMenuItem,
            this.fileSaveToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(188, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileOpenToolStripMenuItem
            // 
            this.fileOpenToolStripMenuItem.Name = "fileOpenToolStripMenuItem";
            this.fileOpenToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.fileOpenToolStripMenuItem.Text = " GERBER Open";
            this.fileOpenToolStripMenuItem.Click += new System.EventHandler(this.fileOpenToolStripMenuItem_Click);
            // 
            // fileSaveToolStripMenuItem
            // 
            this.fileSaveToolStripMenuItem.Name = "fileSaveToolStripMenuItem";
            this.fileSaveToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.fileSaveToolStripMenuItem.Text = "GCODE Save";
            this.fileSaveToolStripMenuItem.Click += new System.EventHandler(this.fileSaveToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // numericMoveSpeed
            // 
            this.numericMoveSpeed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericMoveSpeed.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMoveSpeed.Location = new System.Drawing.Point(705, 148);
            this.numericMoveSpeed.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericMoveSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMoveSpeed.Name = "numericMoveSpeed";
            this.numericMoveSpeed.Size = new System.Drawing.Size(95, 20);
            this.numericMoveSpeed.TabIndex = 1;
            this.numericMoveSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericMoveSpeed.ValueChanged += new System.EventHandler(this.MoveSpeed_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(702, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Move Speed";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(702, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cuttig Speed";
            // 
            // numericCuttingSpeed
            // 
            this.numericCuttingSpeed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericCuttingSpeed.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericCuttingSpeed.Location = new System.Drawing.Point(705, 201);
            this.numericCuttingSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericCuttingSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericCuttingSpeed.Name = "numericCuttingSpeed";
            this.numericCuttingSpeed.Size = new System.Drawing.Size(95, 20);
            this.numericCuttingSpeed.TabIndex = 4;
            this.numericCuttingSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericCuttingSpeed.ValueChanged += new System.EventHandler(this.CuttingSpeed_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(702, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Laser PWR";
            // 
            // numericLaserPWR
            // 
            this.numericLaserPWR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericLaserPWR.Location = new System.Drawing.Point(705, 93);
            this.numericLaserPWR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericLaserPWR.Name = "numericLaserPWR";
            this.numericLaserPWR.Size = new System.Drawing.Size(95, 20);
            this.numericLaserPWR.TabIndex = 12;
            this.numericLaserPWR.ThousandsSeparator = true;
            this.numericLaserPWR.ValueChanged += new System.EventHandler(this.cutPositions_ValueChanged);
            // 
            // ViewScale
            // 
            this.ViewScale.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ViewScale.Location = new System.Drawing.Point(696, 247);
            this.ViewScale.Maximum = 20;
            this.ViewScale.Minimum = 1;
            this.ViewScale.Name = "ViewScale";
            this.ViewScale.Size = new System.Drawing.Size(104, 45);
            this.ViewScale.TabIndex = 13;
            this.ViewScale.Value = 10;
            this.ViewScale.Scroll += new System.EventHandler(this.Scale);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.ViewScale);
            this.Controls.Add(this.numericLaserPWR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericCuttingSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericMoveSpeed);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GERBER to Stencill G-CODE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMoveSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCuttingSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLaserPWR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSaveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NumericUpDown numericMoveSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericCuttingSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericLaserPWR;
        private System.Windows.Forms.TrackBar ViewScale;
    }
}

