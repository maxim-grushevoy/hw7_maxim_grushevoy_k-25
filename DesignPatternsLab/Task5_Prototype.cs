namespace DesignPatternsLab.Task5_Prototype
{
    public interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    public class Rectangle : IFigure
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle(int w, int h)
        {
            _width = w;
            _height = h;
        }

        public IFigure Clone()
        {
            return new Rectangle(_width, _height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямокутник довжиною {0} и шириною {1}", _height, _width);
        }
    }

    public class Circle : IFigure
    {
        private readonly int _radius;

        public Circle(int r)
        {
            _radius = r;
        }

        public IFigure Clone()
        {
            return new Circle(_radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радіусом {0}", _radius);
        }
    }

    // Нове: Трикутник
    public class Triangle : IFigure
    {
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;

        public Triangle(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public IFigure Clone()
        {
            return new Triangle(_a, _b, _c);
        }

        public void GetInfo()
        {
            Console.WriteLine("Трикутник зі сторонами {0}, {1} і {2}", _a, _b, _c);
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 5: Prototype ---");

            IFigure[] figures =
            {
                new Rectangle(10, 20),
                new Circle(15),
                new Triangle(3, 4, 5)
            };

            foreach (IFigure figure in figures)
            {
                IFigure clonedFigure = figure.Clone();

                figure.GetInfo();
                clonedFigure.GetInfo();
                Console.WriteLine("Це різні об'єкти: " + !ReferenceEquals(figure, clonedFigure));
                Console.WriteLine();
            }
        }
    }
}
