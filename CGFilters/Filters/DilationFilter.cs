using System.Drawing;

namespace CGFilters
{
    public class DilationFilter
    {
        public static Bitmap Execute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            float[,] mask = new float[3, 3];

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    mask[x, y] = 0.0f;
            mask[0, 1] = mask[1, 0] = mask[1, 1] = mask[1, 2] = mask[2, 1] = 1.0f;

            // Width, Height – размеры исходного и результирующего изображений
            // MW, MH – размеры структурного множества
            for (int y = 3 / 2; y < source.Height – (3 / 2); y++)
                for (int x = 3 / 2; x < source.Width – 3 / 2; x++)
                {
                BIT max = 0;
                for (j = -MH / 2; j <= MH / 2; j++)
                    for (i = -MW / 2; i <= MW / 2; i++)
                        if ((mask[i][j]) && (source[x + i][y + j] > max))
                        {
                            max = source[x + i][y + j];
                        }
                result[x][y] = max;
            }
            return result;
        }
    }
}
