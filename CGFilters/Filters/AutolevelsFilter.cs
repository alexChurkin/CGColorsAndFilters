using System.Drawing;

namespace CGFilters
{
    public class AutolevelsFilter
    {
        public static Bitmap Execute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            float Rmin = 255, Rmax = 0;
            float Gmin = 255, Gmax = 0;
            float Bmin = 255, Bmax = 0;

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    int curR = source.GetPixel(i, j).R;
                    int curG = source.GetPixel(i, j).G;
                    int curB = source.GetPixel(i, j).B;

                    if (curR < Rmin) Rmin = curR;
                    if (curG < Gmin) Gmin = curG;
                    if (curB < Bmin) Bmin = curB;

                    if (curR > Rmax) Rmax = curR;
                    if (curG > Gmax) Gmax = curG;
                    if (curB > Bmax) Bmax = curB;
                }

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color oldClr = source.GetPixel(i, j);
                    int R = oldClr.R;
                    int G = oldClr.G;
                    int B = oldClr.B;

                    float newR = (R - Rmin) * (255 / (Rmax - Rmin));
                    float newG = (G - Gmin) * (255 / (Gmax - Gmin));
                    float newB = (B - Bmin) * (255 / (Bmax - Bmin));

                    result.SetPixel(i, j, Color.FromArgb((int)newR, (int)newG, (int)newB));
                }

            return result;
        }
    }
}