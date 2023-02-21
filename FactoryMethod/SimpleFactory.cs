using System;

namespace FactoryMethod
{
    public interface ICalculator
    {
        double GetResult(double d1, double d2);
    }

    public class Add : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 + d2;
        }
    }

    public class Sub : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 - d2;
        }
    }

    public class Mul : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 * d2;
        }
    }

    public class Div : ICalculator
    {
        public double GetResult(double d1, double d2)
        {
            return d1 / d2;
        }
    }

    public class CalFactory
    {
        public static ICalculator GetCalculator(string oper)
        {
            ICalculator calculator = null;
            switch (oper)
            {
                case "+":
                    calculator = new Add();
                    break;
                case "-":
                    calculator = new Sub();
                    break;
                case "*":
                    calculator = new Mul();
                    break;
                case "/":
                    calculator = new Div();
                    break;
            }
            return calculator;
        }
    }

    /// <summary>
    /// 简单工厂模式
    /// 优点：
    /// 1. 解决了客户端直接依赖具体对象的问题，消除了创建对象的责任
    /// 2.代码复用
    /// 缺点：
    /// 1.系统扩展困难，一旦加入新功能，就必须修改工厂逻辑，破坏了开闭原则
    /// 2.集合了多个创建对象的逻辑，一旦不能正常工作，会导致整个系统出现问题
    /// </summary>
    public class SimpleFactory
    {
        public static void Test()
        {
            Console.WriteLine("---简单工厂设计模式---");
            Console.WriteLine("请输入操作数1：");
            var d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作数2：");
            var d2 = Convert.ToDouble(Console.ReadLine());
            ICalculator calculator = null;
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();

            calculator = CalFactory.GetCalculator(oper);
            double result = calculator.GetResult(d1, d2);
            Console.WriteLine("结果为：{0}", result);
        }
    }
}
