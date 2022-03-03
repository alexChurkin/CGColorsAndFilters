
namespace Filter
{
    using System;
    using System.Drawing;

    public abstract class Filter1
    {
        protected abstract Color CalculateNewPixelColor(Bitmap source, int x, int y);

        public Bitmap ProcessImage(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                    result.SetPixel(x, y, CalculateNewPixelColor(source, x, y));

            return result;
        }

        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }

    public class MatrixFilter1 : Filter1
    {
        protected float[,] kernel = null;
        protected MatrixFilter1() { }
        public MatrixFilter1(float[,] kernel)
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

    public class SobelGxFilter1 : MatrixFilter1
    {
        public SobelGxFilter1()
        {
            int sizeX = 3, sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = -1.0f;
            kernel[0, 1] = 0.0f;
            kernel[0, 2] = 1.0f;
            kernel[1, 0] = -2.0f;
            kernel[1, 1] = 0.0f;
            kernel[1, 2] = 2.0f;
            kernel[2, 0] = -1.0f;
            kernel[2, 1] = 0.0f;
            kernel[2, 2] = 1.0f;
        }
    }

    public class SobelGyFilter1 : MatrixFilter1
    {
        public SobelGyFilter1()
        {
            int sizeX = 3, sizeY = 3;
            kernel = new float[sizeX, sizeY];

            kernel[0, 0] = -1.0f;
            kernel[0, 1] = -2.0f;
            kernel[0, 2] = -1.0f;
            kernel[1, 0] = kernel[1, 1] = kernel[1, 2] = 0.0f;
            kernel[2, 0] = 1.0f;
            kernel[2, 1] = 2.0f;
            kernel[2, 2] = 1.0f;
        }
    }

    public class TestFilter
    {
        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Bitmap Execute(Bitmap source)
        {
            SobelGxFilter1 gxFilter = new SobelGxFilter1();
            SobelGyFilter1 gyFilter = new SobelGyFilter1();

            Bitmap result = new Bitmap(source.Width, source.Height);

            Bitmap sobelGx = gxFilter.ProcessImage(source);
            Bitmap sobelGy = gyFilter.ProcessImage(source);

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                {
                    Color gxColor = sobelGx.GetPixel(x, y);
                    Color gyColor = sobelGy.GetPixel(x, y);

                    int newR = Clamp((int)Math.Sqrt(Math.Pow(gxColor.R, 2) + Math.Pow(gyColor.R, 2)), 0, 255);
                    int newG = Clamp((int)Math.Sqrt(Math.Pow(gxColor.G, 2) + Math.Pow(gyColor.G, 2)), 0, 255);
                    int newB = Clamp((int)Math.Sqrt(Math.Pow(gxColor.B, 2) + Math.Pow(gyColor.B, 2)), 0, 255);
                    result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }

            return result;
        }
    }
}