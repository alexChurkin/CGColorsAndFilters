using System.Drawing;
using System;

namespace CGFilters
{
    public class SobelGxFilter : MatrixFilter
    {
        public SobelGxFilter()
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

    public class SobelGyFilter : MatrixFilter
    {
        public SobelGyFilter()
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

    public class SobelFilter
    {
        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Bitmap Execute(Bitmap source)
        {
            SobelGxFilter gxFilter = new SobelGxFilter();
            SobelGyFilter gyFilter = new SobelGyFilter();

            Bitmap result = new Bitmap(source.Width, source.Height);

            Bitmap sobelGx = gxFilter.ProcessImage(source);
            Bitmap sobelGy = gyFilter.ProcessImage(source);

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color gxColor = sobelGx.GetPixel(i, j);
                    Color gyColor = sobelGy.GetPixel(i, j);

                    int newR = Clamp((int)Math.Sqrt(Math.Pow(gxColor.R, 2) + Math.Pow(gyColor.R, 2)), 0, 255);
                    int newG = Clamp((int)Math.Sqrt(Math.Pow(gxColor.G, 2) + Math.Pow(gyColor.G, 2)), 0, 255);
                    int newB = Clamp((int)Math.Sqrt(Math.Pow(gxColor.B, 2) + Math.Pow(gyColor.B, 2)), 0, 255);
                    result.SetPixel(i, j, Color.FromArgb(newR, newG, newB));
                }

            return result;
        }
    }
}