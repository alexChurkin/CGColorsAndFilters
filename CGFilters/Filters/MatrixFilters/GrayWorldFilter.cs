namespace Filter
{
    using System.Drawing;

    public class Filter
    {
        protected static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static Bitmap Execute(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            int N = source.Width * source.Height;
            double R_ = 0, G_ = 0, B_ = 0;

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    R_ += (1.0 / N) * (source.GetPixel(i, j).R);
                    G_ += (1.0 / N) * (source.GetPixel(i, j).G);
                    B_ += (1.0 / N) * (source.GetPixel(i, j).B);
                }

            double Avg = (R_ + G_ + B_) / 3.0;

            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    result.SetPixel(i, j,
                        Color.FromArgb(
                            Clamp((int)(source.GetPixel(i, j).R * (Avg / R_)), 0, 255),
                            Clamp((int)(source.GetPixel(i, j).G * (Avg / G_)), 0, 255),
                            Clamp((int)(source.GetPixel(i, j).B * (Avg / B_)), 0, 255)
                        )
                    );
                }

            return result;
        }
    }
}