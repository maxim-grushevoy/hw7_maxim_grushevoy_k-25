namespace DesignPatternsLab.Task6_FactoryMethod
{
    // Product
    public interface IDocument
    {
        void Open();
        void Save();
    }

    // ConcreteProduct 1
    public class PdfDocument : IDocument
    {
        public void Open() { Console.WriteLine("Відкрито PDF-документ"); }
        public void Save() { Console.WriteLine("PDF-документ збережено"); }
    }

    // ConcreteProduct 2
    public class WordDocument : IDocument
    {
        public void Open() { Console.WriteLine("Відкрито Word-документ"); }
        public void Save() { Console.WriteLine("Word-документ збережено"); }
    }

    // Creator
    public abstract class DocumentCreator
    {
        // Фабричний метод
        public abstract IDocument CreateDocument();

        // Загальна логіка, яка використовує фабричний метод
        public void Work()
        {
            IDocument doc = CreateDocument();
            doc.Open();
            doc.Save();
        }
    }

    // ConcreteCreator 1
    public class PdfCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    // ConcreteCreator 2
    public class WordCreator : DocumentCreator
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 6а: Factory Method ---");

            DocumentCreator[] creators =
            {
                new PdfCreator(),
                new WordCreator()
            };

            foreach (DocumentCreator creator in creators)
            {
                creator.Work();
            }
        }
    }
}
