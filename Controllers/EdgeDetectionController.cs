using EdgeDet.Models;
using EdgeDet.Utilities;
using EdgeDet.Views;

namespace EdgeDet.Controllers
{
    /// <summary>
    /// Controller to manage edge detection logic.
    /// </summary>
    public class EdgeDetectionController
    {
        private readonly ConsoleView _view;

        public EdgeDetectionController(ConsoleView view)
        {
            _view = view;
        }

        public void Run()
        {
            string inputPath = _view.GetImagePath();
            string operatorType = _view.GetOperatorType();
            string outputPath = _view.GetOutputPath();

            try
            {
                int[,] image = ImageLoader.LoadImage(inputPath);
                EdgeDetectionOperator operatorInstance = operatorType.ToLower() switch
                {
                    "sobel" => new SobelOperator(),
                    "prewitt" => new PrewittOperator(),
                    _ => throw new ArgumentException("Invalid operator type.")
                };

                int[,] result = operatorInstance.Apply(image);
                ImageSaver.SaveImage(outputPath, result);
                _view.DisplayMessage($"Edge detection complete. Output saved to {outputPath}");
            }
            catch (Exception ex)
            {
                _view.DisplayMessage($"Error: {ex.Message}");
            }
        }
    }
}
