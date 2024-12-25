namespace EdgeDet.Utilities
{
    /// <summary>
    /// Utility class for array conversions.
    /// </summary>
    public static class ArrayConverter
    {
        /// <summary>
        /// Converts a byte[,] array to an int[,] array.
        /// </summary>
        /// <param name="source">The source byte[,] array.</param>
        /// <returns>A new int[,] array with the same dimensions as the source.</returns>
        public static int[,] ConvertToIntArray(byte[,] source)
        {
            int width = source.GetLength(0);
            int height = source.GetLength(1);
            var result = new int[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    result[x, y] = source[x, y];
                }
            }

            return result;
        }
    }
}
