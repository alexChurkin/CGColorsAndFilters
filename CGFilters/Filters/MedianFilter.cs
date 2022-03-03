namespace CGFilters
{
    using System.Collections.Generic;
    using System.Drawing;
    public class MedianFilter
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

            //Проход по всем пикселям исходного изображения (кроме крайних)
            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    List<int> Rvalues = new List<int>();
                    List<int> Gvalues = new List<int>();
                    List<int> Bvalues = new List<int>();

                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int x_ = Clamp(x + i, 0, source.Width - 1);
                            int y_ = Clamp(y + j, 0, source.Height - 1);

                            Color px = source.GetPixel(x_, y_);

                            Rvalues.Add(px.R);
                            Gvalues.Add(px.G);
                            Bvalues.Add(px.B);
                        }
                    Rvalues.Sort();
                    Gvalues.Sort();
                    Bvalues.Sort();

                    result.SetPixel(x, y, Color.FromArgb(
                        Rvalues[Rvalues.Count / 2],
                        Gvalues[Gvalues.Count / 2],
                        Bvalues[Bvalues.Count / 2]));
                }
            return result;
        }
    }
}