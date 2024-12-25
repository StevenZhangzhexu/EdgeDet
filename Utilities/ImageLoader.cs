using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace EdgeDet.Utilities
{
    public static class ImageLoader
    {
        public static int[,] LoadImage(string path)
        {
            using var image = Image.Load<L8>(path); // Load as grayscale image
            int width = image.Width;
            int height = image.Height;
            var grayscaleData = new int[width, height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grayscaleData[x, y] = image[x, y].PackedValue;
                }
            }

            return grayscaleData;
        }
    }
}
