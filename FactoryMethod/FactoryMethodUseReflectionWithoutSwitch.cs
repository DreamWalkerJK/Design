using System;
using System.Collections.Generic;
using System.Reflection;

namespace FactoryMethod
{
    public class OperFactory : Attribute
    {
        public string Oper { get; }
        
        public OperFactory(string value)
        {
            Oper = value;
        }
    }

    public interface ICalFactoryNew
    {
        ICalculator GetCalculator();
    }

    [OperFactory("+")]
    public class AddFactoryNew : ICalFactoryNew
    {
        public ICalculator GetCalculator()
        {
            return new Add();
        }
    }

    [OperFactory("-")]
    public class SubFactoryNew : ICalFactoryNew
    {
        public ICalculator GetCalculator()
        {
            return new Sub();
        }
    }

    [OperFactory("*")]
    public class MulFactoryNew : ICalFactoryNew
    {
        public ICalculator GetCalculator()
        {
            return new Mul();
        }
    }

    [OperFactory("/")]
    public class DivFactoryNew : ICalFactoryNew
    {
        public ICalculator GetCalculator()
        {
            return new Div();
        }
    }

    public class ReflectionFactory
    {
        // 根据用户输入的操作符，返回一个对象
        Dictionary<string, ICalFactoryNew> dic = new Dictionary<string, ICalFactoryNew>();

        public ReflectionFactory()
        {
            // 获取当前正在运行的程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach(var item in assembly.GetTypes())
            {
                // IsAssignableFrom 表示item继承了ICalFactoryNew或实现了ICalFactoryNew
                if (typeof(ICalFactoryNew).IsAssignableFrom(item) && !item.IsInterface)
                {
                    OperFactory of = item.GetCustomAttribute<OperFactory>();
                    if(of != null)
                    {
                        // 给键值对字典赋值
                        dic[of.Oper] = Activator.CreateInstance(item) as ICalFactoryNew;
                    }
                }
            }
        }

        public ICalFactoryNew GetFactory(string s)
        {
            if (dic.ContainsKey(s))
            {
                return dic[s];
            }
            return null;
        }
    }

    public class FactoryMethodUseReflectionWithoutSwitch
    {
        public static void Test()
        {
            Console.WriteLine("---工厂方法设计模式（通过反射消除switch分支）---");
            Console.WriteLine("请输入操作数1：");
            var d1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作数2：");
            var d2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入操作符：");
            string oper = Console.ReadLine();

            ReflectionFactory reflectionFactory = new ReflectionFactory();
            ICalFactoryNew calFactoryNew = reflectionFactory.GetFactory(oper);
            var result = calFactoryNew.GetCalculator().GetResult(d1, d2);
            Console.WriteLine("结果为：{0}", result);
        }
    }
}
