using System;
using System.IO;

namespace EdgeDet.Views
{
    /// <summary>
    /// Console-based view for user interaction with default options.
    /// </summary>
    public class ConsoleView
    {
        private static readonly string DefaultInputPath = Path.Combine("image","sample.jpg");
        private static readonly string DefaultOutputPath = Path.Combine("image","output.jpg");

        public string GetImagePath()
        {
            Console.WriteLine($"Enter the image file path (Optional. default: {DefaultInputPath}):");
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? DefaultInputPath : input;
        }

        public string GetOperatorType()
        {
            Console.WriteLine("Enter the edge detection operator (sobel/prewitt, default: sobel):");
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? "sobel" : input;
        }

        public string GetOutputPath()
        {
            Console.WriteLine($"Enter the output file path (default: {DefaultOutputPath}):");
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? DefaultOutputPath : input;
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
