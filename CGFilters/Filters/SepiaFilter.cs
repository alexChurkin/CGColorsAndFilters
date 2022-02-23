using System.Drawing;

namespace CGFilters
{
    public class SepiaFilter: Filter
    {
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);

            int intensity = (int)(0.299 * sourceColor.R
                + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            int k = 20;
            int R = intensity + 2 * k;
            int G = (int) (intensity + 0.5 * k);
            int B = intensity - 1 * k;

            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }

        //For Softgrader tests
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);

                    int intensity = (int)(0.299 * sourceColor.R
                        + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

                    int k = 20;
                    int R = Clamp(intensity + 2 * k, 0, 255);
                    int G = Clamp((int)(intensity + 0.5 * k), 0, 255);
                    int B = Clamp(intensity - 1 * k, 0, 255);

                    Color resultColor = Color.FromArgb(R, G, B);
                    result.SetPixel(i, j, resultColor);
                }

            return result;
        }
    }
}
