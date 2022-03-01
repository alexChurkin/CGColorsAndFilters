using System.Drawing;

namespace CGFilters
{
    public class PerfectReflectionFilter
    {
        public static Bitmap Execute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            float Rmax = 0;
            float Gmax = 0;
            float Bmax = 0;

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    int curR = source.GetPixel(i, j).R;
                    int curG = source.GetPixel(i, j).G;
                    int curB = source.GetPixel(i, j).B;

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

                    float newR = R * (255 / Rmax);
                    float newG = G * (255 / Gmax);
                    float newB = B * (255 / Bmax);

                    result.SetPixel(i, j, Color.FromArgb((int)newR, (int)newG, (int)newB));
                }

            return result;
        }
    }
}