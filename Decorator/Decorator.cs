using System;

namespace Decorator
{
    /// <summary>
    /// Decorator
    /// 维持一个指向Component的指针，并定义一个与Component接口一致的接口
    /// </summary>
    public abstract class Decorator : Drinks
    {
        /// <summary>
        /// 添加一个指向Component的引用
        /// </summary>
        private Drinks _drinks;

        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="drinks"></param>
        public void SetComponent(Drinks drinks)
        {
            _drinks = drinks;
        }

        public override double Cost()
        {
            return _drinks.Cost();
        }
    }

    #region 配料种类
    /// <summary>
    /// ConcreteDecorator
    /// 负责向ConcreteComponent添加功能
    /// 在ConcreteDecorator中添加一些新的方法，即是装饰
    /// </summary>
    public class Pearl : Decorator
    {
        private static double _money = 3;

        public override double Cost()
        {
            Console.WriteLine("珍珠3/份");
            return base.Cost() + _money;
        }
    }

    public class Cream : Decorator
    {
        private static double _money = 7;
        public override double Cost()
        {
            Console.WriteLine("奶油7/份");
            return base.Cost() + _money ;
        }
    }
    #endregion
}
