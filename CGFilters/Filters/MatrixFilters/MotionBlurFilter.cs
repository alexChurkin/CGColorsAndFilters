using System.Drawing;

namespace CGFilters
{
    public class MotionBlurFilter: MatrixFilter
    {
        public MotionBlurFilter()
        {
            int sizeX = 9, sizeY = 9;
            kernel = new float[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
                for (int j = 0; j < sizeY; j++)
                {
                    if(i == j) kernel[i, j] = (1.0f / 9.0f);
                    else kernel[i, j] = 0.0f;
                }
        }

        public static Bitmap Execute(Bitmap sourceImage)
        {
            return new MotionBlurFilter().ProcessImage(sourceImage);
        }
    }
}
