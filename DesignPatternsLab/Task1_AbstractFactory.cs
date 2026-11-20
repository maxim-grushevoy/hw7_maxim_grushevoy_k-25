namespace DesignPatternsLab.Task1_AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    // ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    // ConcreteProductA3 (нове)
    public class Mercedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mercedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public abstract void GetPower();
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine 4.4");
        }
    }

    // ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine 3.2");
        }
    }

    // ConcreteProductB3 (нове)
    public class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine 3.0");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Ford();
        }

        public Engine CreateEngine()
        {
            return new FordEngine();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Toyota();
        }

        public Engine CreateEngine()
        {
            return new ToyotaEngine();
        }
    }

    // ConcreteFactory3 (нове)
    public class MercedesFactory : ICarFactory
    {
        public Car CreateCar()
        {
            return new Mercedes();
        }

        public Engine CreateEngine()
        {
            return new MercedesEngine();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 1: Abstract Factory ---");

            ICarFactory[] factories =
            {
                new ToyotaFactory(),
                new FordFactory(),
                new MercedesFactory()
            };

            foreach (ICarFactory factory in factories)
            {
                Car car = factory.CreateCar();
                car.Info();

                Engine engine = factory.CreateEngine();
                engine.GetPower();
            }
        }
    }
}
