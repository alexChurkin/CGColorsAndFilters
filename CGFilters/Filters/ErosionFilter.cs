using System.Drawing;

namespace CGFilters
{
    public class ErosionFilter
    {
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Bitmap Execute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            float[,] mask = new float[3, 3];

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    mask[x, y] = 0.0f;
            mask[0, 1] = mask[1, 0] = mask[1, 1] = mask[1, 2] = mask[2, 1] = 1.0f;

            //Проход по всем пикселям исходного изображения (кроме крайних)
            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    int min = 255;

                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int x_ = Clamp(x + i, 0, source.Width - 1);
                            int y_ = Clamp(y + j, 0, source.Height - 1);

                            if (mask[i + 1, j + 1] > 0 && source.GetPixel(x_, y_).R < min)
                            {
                                min = source.GetPixel(x_, y_).R;
                            }
                        }
                    result.SetPixel(x, y, Color.FromArgb(min, min, min));
                }
            return result;
        }
    }
}