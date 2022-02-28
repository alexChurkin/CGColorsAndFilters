using System.Drawing;

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

    public class MatrixFilter1 : FilterParent
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

    //1
    public class EmbossingFilter1 : MatrixFilter1
    {
        public EmbossingFilter1()
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

    //2
    public class IncreaseBrightnessFilter1 : FilterParent
    {
        private int value;
        public IncreaseBrightnessFilter1(int value = 20)
        {
            this.value = value;
        }
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);

            int R = Clamp(sourceColor.R + value, 0, 255);
            int G = Clamp(sourceColor.G + value, 0, 255);
            int B = Clamp(sourceColor.B + value, 0, 255);

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

    //3
    public class ShadesOfGrayFilter1 : FilterParent
    {
        protected override Color CalculateNewPixelColor(Bitmap source, int x, int y)
        {
            Color sourceColor = source.GetPixel(x, y);

            int intensity = (int)(0.299 * sourceColor.R
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

    public class Filter
    {
        public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap result;

            EmbossingFilter1 f = new EmbossingFilter1();
            result = f.ProcessImage(sourceImage);

            IncreaseBrightnessFilter1 br = new IncreaseBrightnessFilter1(100);
            result = br.ProcessImage(result);

            ShadesOfGrayFilter1 s = new ShadesOfGrayFilter1();
            result = s.ProcessImage(result);

            return result;
        }
    }
}