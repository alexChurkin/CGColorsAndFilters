using System;
using System.Drawing;
using System.Windows.Forms;
using Filter;

namespace CGFilters
{
    public partial class MainForm : Form
    {
        Bitmap image;
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                image = new Bitmap(imagePath);
                this.pictureBox.Image = image;
            }
        }
        
        //1
        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = InvertFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //2
        private void grayShadesStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = ShadesOfGrayFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //3
        private void sepiatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = SepiaFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //4
        private void increaseBrightnesstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = IncreaseBrightnessFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //5
        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = ShiftFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //6
        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = EmbossingFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //7
        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = MotionBlurFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //8
        private void grayWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = GrayWorldFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //9
        private void autolevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = AutolevelsFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //10
        private void perfectReflectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = PerfectReflectionFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //11
        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = DilationFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //12
        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = ErosionFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //13
        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = MedianFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
        //14
        private void sobelFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //15
        private void scharrFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}