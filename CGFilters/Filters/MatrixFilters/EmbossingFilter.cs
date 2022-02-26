namespace CGFilters
{
    public class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
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
}
