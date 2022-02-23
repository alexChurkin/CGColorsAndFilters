namespace Filter 
{
    public class Filter
    {
		public static Bitmap Execute(Bitmap sourceImage)
        {
            Bitmap result = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int x = 0; x < sourceImage.Width - 50; x++)
                for (int y = 0; y < sourceImage.Height; y++)
                {
                    Color sourceColor = sourceImage.GetPixel(x, y);
                    result.SetPixel(x + 50, y, sourceColor);
                }

            return result;
        }
    }
}