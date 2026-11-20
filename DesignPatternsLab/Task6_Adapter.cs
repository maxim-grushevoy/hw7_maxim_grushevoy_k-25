namespace DesignPatternsLab.Task6_Adapter
{
    // Target: інтерфейс, який очікує клієнт
    public interface IPrinter
    {
        void Print(string text);
    }

    // Adaptee: старий клас з несумісним інтерфейсом
    public class LegacyPrinter
    {
        public void PrintUpperCase(string text, int copies)
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine("[Legacy] " + text.ToUpper());
            }
        }
    }

    // Adapter
    public class PrinterAdapter : IPrinter
    {
        private readonly LegacyPrinter _legacyPrinter;

        public PrinterAdapter(LegacyPrinter legacyPrinter)
        {
            _legacyPrinter = legacyPrinter;
        }

        public void Print(string text)
        {
            _legacyPrinter.PrintUpperCase(text, 1);
        }
    }

    // Звичайна реалізація цільового інтерфейсу
    public class ModernPrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine("[Modern] " + text);
        }
    }

    // Client
    public class Client
    {
        public void Work(IPrinter printer, string text)
        {
            printer.Print(text);
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 6б: Adapter ---");

            Client client = new Client();

            client.Work(new ModernPrinter(), "Hello, world");
            client.Work(new PrinterAdapter(new LegacyPrinter()), "Hello, world");
        }
    }
}
