using System.Drawing;

namespace CGFilters
{
    public class ShadesOfGrayFilter: Filter
    {
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);

            int intensity = (int) (0.299 * sourceColor.R
                + 0.587 * sourceColor.G + 0.114 * sourceColor.B);

            Color resultColor = Color.FromArgb(intensity, intensity, intensity);
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

                    Color resultColor = Color.FromArgb(intensity, intensity, intensity);
                    result.SetPixel(i, j, resultColor);
                }

            return result;
        }
    }
}
