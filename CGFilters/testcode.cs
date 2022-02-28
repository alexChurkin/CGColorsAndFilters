namespace Filter
{
    using System.Drawing;

    public class Filterr
    {
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            int sizeX = 3, sizeY = 3;
            float[,] kernel = new float[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                    kernel[i, j] = 0.0f;
            kernel[1, 0] = kernel[2, 1] = -1.0f;
            kernel[0, 1] = kernel[1, 2] = 1.0f;

            for (int i = 0; i < sourceImage.Width; i++)
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    //1 - Embossing
                    int radiusX = kernel.GetLength(0) / 2;
                    int radiusY = kernel.GetLength(1) / 2;

                    float resultR = 0, resultG = 0, resultB = 0;

                    for (int l = -radiusY; l <= radiusY; l++)
                        for (int k = -radiusX; k <= radiusX; k++)
                        {
                            int x = i, y = j;

                            int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                            int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                            Color neighborColor = sourceImage.GetPixel(idX, idY);
                            resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                            resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                            resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                        }
                    Color newcolor = Color.FromArgb(
                        Clamp((int)resultR, 0, 255),
                        Clamp((int)resultG, 0, 255),
                        Clamp((int)resultB, 0, 255));

                    //2 - GrayFilter
                    int intensity = (int)(0.299 * newcolor.R
                        + 0.587 * newcolor.G + 0.114 * newcolor.B);
                    newcolor = Color.FromArgb(intensity, intensity, intensity);

                    //3 - Brigntness (+ 100)
                    newcolor = Color.FromArgb(
                        Clamp(newcolor.R + 100, 0, 255),
                        Clamp(newcolor.G + 100, 0, 255),
                        Clamp(newcolor.B + 100, 0, 255));

                    result.SetPixel(i, j, newcolor);
                }
            return result;
        }
    }
}