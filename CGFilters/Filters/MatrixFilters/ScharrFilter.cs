using System;
using System.Drawing;

namespace CGFilters
{
    public class ScharrKernel
    {
        protected float[,] kernel = null;

        public ScharrKernel(int sizeX, int sizeY)
        {
            kernel = new float[sizeX, sizeY];
        }

        public float this[int index1, int index2]
        {
            get => kernel[index1, index2];
            set => kernel[index1, index2] = value;
        }
    }

    public class ScharrGxKernel : ScharrKernel
    {
        public ScharrGxKernel() : base(3, 3)
        {
            kernel[0, 1] = kernel[1, 1] = kernel[2, 1] = 0.0f;
            kernel[0, 0] = kernel[2, 0] = -3.0f;
            kernel[0, 2] = kernel[2, 2] = 3.0f;
            kernel[1, 0] = -10.0f;
            kernel[1, 2] = 10.0f;
        }
    }
    public class ScharrGyKernel : ScharrKernel
    {
        public ScharrGyKernel() : base(3, 3)
        {
            kernel[0, 0] = kernel[0, 2] = -3.0f;
            kernel[2, 0] = kernel[2, 2] = 3.0f;
            kernel[0, 1] = -10.0f;
            kernel[2, 1] = 10.0f;
            kernel[1, 0] = kernel[1, 1] = kernel[1, 2] = 0.0f;
        }
    }

    public class ScharrFilter
    {
        public static Bitmap Execute(Bitmap source)
        {
            ScharrGxKernel gxKernel = new ScharrGxKernel();
            ScharrGyKernel gyKernel = new ScharrGyKernel();

            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
                for (int x = 0; x < source.Width; x++)
                {
                    //1. Вычисление значений R_x, G_x, B_x
                    float R_x = 0.0f, G_x = 0.0f, B_x = 0.0f;

                    for (int l = -1; l <= 1; l++)
                        for (int k = -1; k <= 1; k++)
                        {
                            int idX = Clamp(x + k, 0, source.Width - 1);
                            int idY = Clamp(y + l, 0, source.Height - 1);
                            Color neighborColor = source.GetPixel(idX, idY);
                            R_x += neighborColor.R * gxKernel[k + 1, l + 1];
                            G_x += neighborColor.G * gxKernel[k + 1, l + 1];
                            B_x += neighborColor.B * gxKernel[k + 1, l + 1];
                        }
                    //2. Вычисление значений R_y, G_y, B_y
                    float R_y = 0.0f, G_y = 0.0f, B_y = 0.0f;

                    for (int l = -1; l <= 1; l++)
                        for (int k = -1; k <= 1; k++)
                        {
                            int idX = Clamp(x + k, 0, source.Width - 1);
                            int idY = Clamp(y + l, 0, source.Height - 1);
                            Color neighborColor = source.GetPixel(idX, idY);
                            R_y += neighborColor.R * gyKernel[k + 1, l + 1];
                            G_y += neighborColor.G * gyKernel[k + 1, l + 1];
                            B_y += neighborColor.B * gyKernel[k + 1, l + 1];
                        }

                    //3. Вычисление результирующих значений
                    int newR = Clamp((int)Math.Sqrt(Math.Pow(R_x, 2) + Math.Pow(R_y, 2)), 0, 255);
                    int newG = Clamp((int)Math.Sqrt(Math.Pow(G_x, 2) + Math.Pow(G_y, 2)), 0, 255);
                    int newB = Clamp((int)Math.Sqrt(Math.Pow(B_x, 2) + Math.Pow(B_y, 2)), 0, 255);
                    result.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }

            return result;
        }

        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}