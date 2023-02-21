using System;

namespace FactoryMethod
{
    public interface ICalFactory
    {
        ICalculator GetCalculator();
    }

    public class AddFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Add();
        }
    }

    public class SubFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Sub();
        }
    }

    public class MulFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Mul();
        }
    }

    public class DivFactory : ICalFactory
    {
        public ICalculator GetCalculator()
        {
            return new Div();
        }
    }

    /// <summary>
    /// 工厂方法设计模式
    /// </summary>
    public class FactoryMethod
    {
        public static void Test()
        {
            Console.WriteLine("---工厂方法设计模式---");
            Console.WriteLine("请输入操作数1：");
            var d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作数2：");
            var d2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();

            ICalFactory calFactory = null;

            switch (oper)
            {
                case "+":
                    calFactory = new AddFactory();
                    break;
                case "-":
                    calFactory = new SubFactory();
                    break;
                case "*":
                    calFactory = new MulFactory();
                    break;
                case "/":
                    calFactory = new DivFactory();
                    break;
            }

            ICalculator calculator = calFactory?.GetCalculator();
            var result = calculator.GetResult(d1, d2);
            Console.WriteLine("结果为：{0}", result);
        }
    }
}
