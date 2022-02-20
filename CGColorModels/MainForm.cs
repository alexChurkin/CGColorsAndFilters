using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGColorModels
{
    public partial class MainForm : Form
    {
        ColorConvert cc = new ColorConvert();
        public MainForm()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string imagePath;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения|*.jpg;*.png";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                imagePath = ofd.FileName;
                cc.rgbImage = new Bitmap(imagePath);
                this.pictureBox.Image = cc.rgbImage;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cc.rgbImage == null)
                return;

            this.Cursor = Cursors.WaitCursor;

            cc.ConvertRGBimageToHSV();
            int width = cc.rgbImage.Width;
            int height = cc.rgbImage.Height;

            for(int i = 0; i < width; ++i)
                for(int j = 0; j < height; ++j)
                {
                    int tmpH = cc.hsvImage[i, j].h + trackBar.Value;
                    if (tmpH < 0)
                        cc.hsvImage[i, j].h = (ushort)(tmpH + 360);
                    else if (tmpH >= 360)
                        cc.hsvImage[i, j].h = (ushort)(tmpH - 360);
                    else
                        cc.hsvImage[i, j].h = (ushort)tmpH;
                }
            trackBar.Value = 0;
            cc.ConvertHSVImageToRGB();
            pictureBox.Image = cc.rgbImage;
            this.Cursor = Cursors.Default;
        }
    }
}
