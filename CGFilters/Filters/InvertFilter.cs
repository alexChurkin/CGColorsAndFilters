using System.Drawing;

namespace CGFilters
{
    public class InvertFilter : Filter
    {
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                                255 - sourceColor.G,
                                                255 - sourceColor.B);
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
                    Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                                        255 - sourceColor.G,
                                                        255 - sourceColor.B);
                    result.SetPixel(i, j, resultColor);
                }

            return result;
        }
    }
}
