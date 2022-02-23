using System.Drawing;

namespace CGFilters
{
    public class IncreaseBrightnessFilter: Filter
    {
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);

            int R = Clamp(sourceColor.R + 20, 0, 255);
            int G = Clamp(sourceColor.G + 20, 0, 255);
            int B = Clamp(sourceColor.B + 20, 0, 255);

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

                    int R = Clamp(sourceColor.R + 20, 0, 255);
                    int G = Clamp(sourceColor.G + 20, 0, 255);
                    int B = Clamp(sourceColor.B + 20, 0, 255);

                    Color resultColor = Color.FromArgb(R, G, B);
                    result.SetPixel(i, j, resultColor);
                }

            return result;
        }
    }
}
