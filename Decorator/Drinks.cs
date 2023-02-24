using System;

namespace Decorator
{
    /// <summary>
    /// Component
    /// 定义一个对象接口，可以给这些对象动态地添加职责
    /// </summary>
    public abstract class Drinks
    {
        public abstract double Cost();
    }

    #region 饮料种类
    /// <summary>
    /// ConcreteComponent
    /// 定义一个对象，继承Component，可以给这个对象添加一些职责
    /// </summary>
    public class MilkTea : Drinks
    {
        public override double Cost()
        {
            Console.WriteLine("奶茶10/杯");
            return 10;
        }
    }

    public class FruitTea : Drinks
    {
        public override double Cost()
        {
            Console.WriteLine("水果茶15/杯");
            return 15;
        }
    }

    public class Soda : Drinks
    {
        public override double Cost()
        {
            Console.WriteLine("苏打水5/杯");
            return 5;
        }
    }
    #endregion
}
