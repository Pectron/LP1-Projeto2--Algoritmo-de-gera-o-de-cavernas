using System;

namespace MyCaves
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller(args);
            View view = new View();

            controller.Run(view);
        }
    }
}
