using System.Text;

namespace DesignPatternsLab
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Task1_AbstractFactory.Demo.Run();
            Console.WriteLine();

            Task2_Builder.Demo.Run();
            Console.WriteLine();

            Task3_Mediator.Demo.Run();
            Console.WriteLine();

            Task4_Decorator.Demo.Run();
            Console.WriteLine();

            Task5_Prototype.Demo.Run();
            Console.WriteLine();

            Task6_FactoryMethod.Demo.Run();
            Console.WriteLine();

            Task6_Adapter.Demo.Run();
            Console.WriteLine();

            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
