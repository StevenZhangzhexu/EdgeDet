using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace EdgeDet.Utilities
{
    public static class ImageSaver
    {
        public static void SaveImage(string path, int[,] grayscaleData)
        {
            int width = grayscaleData.GetLength(0);
            int height = grayscaleData.GetLength(1);

            using var image = new Image<L8>(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Clamp values to byte range (0–255) before assigning
                    byte clampedValue = (byte)Math.Clamp(grayscaleData[x, y], 0, 255);
                    image[x, y] = new L8(clampedValue);
                }
            }

            image.Save(path); // Save as a grayscale image
        }
    }
}
