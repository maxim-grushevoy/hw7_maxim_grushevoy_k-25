namespace DesignPatternsLab.Task3_Mediator
{
    // Mediator
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    // Colleague
    public abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void Notify(string message);
    }

    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Colleague1 gets message: " + message);
        }
    }

    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Colleague2 gets message: " + message);
        }
    }

    // Новий колега
    public class ConcreteColleague3 : Colleague
    {
        public ConcreteColleague3(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Colleague3 gets message: " + message);
        }
    }

    // ConcreteMediator: пересилає повідомлення всім колегам, крім відправника
    public class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }
        public ConcreteColleague3 Colleague3 { get; set; }

        public override void Send(string message, Colleague colleague)
        {
            Colleague[] all = { Colleague1, Colleague2, Colleague3 };

            foreach (Colleague c in all)
            {
                if (c != null && c != colleague)
                {
                    c.Notify(message);
                }
            }
        }
    }

    public static class Demo
    {
        public static void Run()
        {
            Console.WriteLine("--- Завдання 3: Mediator ---");

            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 c1 = new ConcreteColleague1(m);
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            ConcreteColleague3 c3 = new ConcreteColleague3(m);

            m.Colleague1 = c1;
            m.Colleague2 = c2;
            m.Colleague3 = c3;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");
            c3.Send("Hello!");
        }
    }
}
