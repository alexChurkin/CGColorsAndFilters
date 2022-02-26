using System;
using System.Drawing;
using System.Windows.Forms;

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

        private void increaseBrightnesstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = IncreaseBrightnessFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }

        private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap result = ShiftFilter.Execute(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }

        private void embossingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmbossingFilter f = new EmbossingFilter();
            Bitmap result = f.ProcessImage(image);
            pictureBox.Image = result;
            pictureBox.Refresh();
        }
    }
}