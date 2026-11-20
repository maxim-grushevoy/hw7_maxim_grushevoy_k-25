namespace DesignPatternsLab.Task4_Decorator
{
    // Component
    public abstract class Tree
    {
        public abstract string Describe();
        public abstract string Light();
    }

    // ConcreteComponent: "Ялинка"
    public class ChristmasTree : Tree
    {
        public override string Describe()
        {
            return "Ялинка";
        }

        public override string Light()
        {
            return "Ялинка не світиться";
        }
    }

    // Decorator
    public abstract class TreeDecorator : Tree
    {
        protected Tree tree;

        protected TreeDecorator(Tree tree)
        {
            this.tree = tree;
        }

        public override string Describe()
        {
            return tree.Describe();
        }

        public override string Light()
        {
            return tree.Light();
        }
    }

    // ConcreteDecorator 1: ялинкові прикраси (поле)
    public class OrnamentsDecorator : TreeDecorator
    {
        private readonly List<string> _ornaments;

        public OrnamentsDecorator(Tree tree, params string[] ornaments) : base(tree)
        {
            _ornaments = new List<string>(ornaments);
        }

        public override string Describe()
        {
            return base.Describe() + " + прикраси (" + string.Join(", ", _ornaments) + ")";
        }
    }

    // ConcreteDecorator 2: гірлянда (метод, що змушує ялинку світитися)
    public class GarlandDecorator : TreeDecorator
    {
        private readonly string _color;

        public GarlandDecorator(Tree tree, string color) : base(tree)
        {
            _color = color;
        }

        public override string Describe()
        {
            return base.Describe() + " + гірлянда (" + _color + ")";
        }

        public override string Light()
        {
            return "Ялинка світиться " + _color + " вогниками";
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 4: Decorator ---");

            Tree tree = new ChristmasTree();
            Console.WriteLine(tree.Describe());
            Console.WriteLine(tree.Light());
            Console.WriteLine();

            tree = new OrnamentsDecorator(tree, "червоні кулі", "зірка", "сніжинки");
            Console.WriteLine(tree.Describe());
            Console.WriteLine(tree.Light());
            Console.WriteLine();

            tree = new GarlandDecorator(tree, "різнокольоровими");
            Console.WriteLine(tree.Describe());
            Console.WriteLine(tree.Light());
        }
    }
}
