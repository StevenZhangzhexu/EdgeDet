using System;

namespace EdgeDet.Models
{
    /// <summary>
    /// Sobel edge detection implementation.
    /// </summary>
    public class SobelOperator : EdgeDetectionOperator
    {
        private readonly int[,] Gx = {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };
        private readonly int[,] Gy = {
            { 1, 2, 1 },
            { 0, 0, 0 },
            { -1, -2, -1 }
        };

        public override int[,] Apply(int[,] image)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            int[,] result = new int[width, height];

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int gx = 0, gy = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            gx += image[x + i, y + j] * Gx[i + 1, j + 1];
                            gy += image[x + i, y + j] * Gy[i + 1, j + 1];
                        }
                    }
                    result[x, y] = (int)Math.Sqrt(gx * gx + gy * gy);
                }
            }

            return result;
        }
    }
}
