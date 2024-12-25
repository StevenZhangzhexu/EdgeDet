using EdgeDet.Controllers;
using EdgeDet.Views;

namespace EdgeDet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConsoleView view = new ConsoleView();
            EdgeDetectionController controller = new EdgeDetectionController(view);
            controller.Run();
        }
    }
}
