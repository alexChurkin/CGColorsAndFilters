using System.Drawing;

namespace CGFilters
{
    public abstract class Filter
    {
        protected abstract Color CalculateNewPixelColor(Bitmap source, int x, int y);

        public Bitmap ProcessImage(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for(int i = 0; i < source.Width; i++)
                for(int j = 0; j < source.Height; j++)
                    result.SetPixel(i, j, CalculateNewPixelColor(source, i, j));

            return result;
        }

        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if(value > max) return max;
            return value;
        }
    }
}