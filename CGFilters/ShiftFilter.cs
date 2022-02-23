using System.Drawing;

namespace CGFilters
{
    public class ShiftFilter: Filter
    {
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);
            return sourceColor;
        }

        //For Softgrader tests
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int x = 0; x < sourceImage.Width - 50; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color sourceColor = sourceImage.GetPixel(x, y);
                    result.SetPixel(x + 50, y, sourceColor);
                }

            return result;
        }
    }
}
