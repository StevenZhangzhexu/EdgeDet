namespace EdgeDet.Models
{
    /// <summary>
    /// Abstract base class for edge detection operators.
    /// </summary>
    public abstract class EdgeDetectionOperator
    {
        public abstract int[,] Apply(int[,] image);
    }
}
