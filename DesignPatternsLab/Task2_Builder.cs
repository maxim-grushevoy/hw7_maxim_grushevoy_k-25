namespace DesignPatternsLab.Task2_Builder
{
    public class Pizza
    {
        private string _dough;
        private string _sauce;
        private string _topping;

        public void SetDough(string d) { _dough = d; }
        public void SetSauce(string s) { _sauce = s; }
        public void SetTopping(string t) { _topping = t; }

        public void Info()
        {
            Console.WriteLine("Dough: {0}\nSauce: {1}\nTopping: {2}", _dough, _sauce, _topping);
        }
    }

    // Abstract Builder
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public Pizza GetPizza() { return pizza; }
        public void CreateNewPizza() { pizza = new Pizza(); }

        public abstract void BuildDough();
        public abstract void BuildSauce();
        public abstract void BuildTopping();
    }

    // Concrete Builder 1
    public class HawaiianPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() { pizza.SetDough("cross"); }
        public override void BuildSauce() { pizza.SetSauce("mild"); }
        public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
    }

    // Concrete Builder 2
    public class SpicyPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() { pizza.SetDough("pan baked"); }
        public override void BuildSauce() { pizza.SetSauce("hot"); }
        public override void BuildTopping() { pizza.SetTopping("pepperoni+salami"); }
    }

    // Concrete Builder 3 (нове)
    public class MargaritaPizzaBuilder : PizzaBuilder
    {
        public override void BuildDough() { pizza.SetDough("thin"); }
        public override void BuildSauce() { pizza.SetSauce("tomato"); }
        public override void BuildTopping() { pizza.SetTopping("mozzarella+basil"); }
    }

    // Director
    public class Waiter
    {
        private PizzaBuilder _pizzaBuilder;

        public void SetPizzaBuilder(PizzaBuilder pb) { _pizzaBuilder = pb; }
        public Pizza GetPizza() { return _pizzaBuilder.GetPizza(); }

        public void ConstructPizza()
        {
            _pizzaBuilder.CreateNewPizza();
            _pizzaBuilder.BuildDough();
            _pizzaBuilder.BuildSauce();
            _pizzaBuilder.BuildTopping();
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 2: Builder ---");

            Waiter waiter = new Waiter();

            PizzaBuilder[] builders =
            {
                new HawaiianPizzaBuilder(),
                new SpicyPizzaBuilder(),
                new MargaritaPizzaBuilder()
            };

            foreach (PizzaBuilder builder in builders)
            {
                waiter.SetPizzaBuilder(builder);
                waiter.ConstructPizza();

                Console.WriteLine(builder.GetType().Name + ":");
                waiter.GetPizza().Info();
                Console.WriteLine();
            }
        }
    }
}
