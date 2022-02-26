namespace Filter
{
    public abstract class FilterParent
    {
        protected abstract Color CalculateNewPixelColor(Bitmap source, int x, int y);

        public Bitmap ProcessImage(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                    result.SetPixel(i, j, CalculateNewPixelColor(source, i, j));

            return result;
        }

        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

    public class MatrixFilter : FilterParent
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            float resultR = 0, resultG = 0, resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, source.Width - 1);
                    int idY = Clamp(y + l, 0, source.Height - 1);
                    Color neighborColor = source.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }

    public class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            int sizeX = 3, sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kernel[i, j] = 0.0f;
            kernel[1, 0] = kernel[2, 1] = 1.0f;
            kernel[0, 1] = kernel[1, 2] = -1.0f;
        }
    }

    public class Filter
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            EmbossingFilter f = new EmbossingFilter();
            Bitmap result = f.ProcessImage(sourceImage);

            return result;
        }
    }
}