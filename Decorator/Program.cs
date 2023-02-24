using System;

namespace Decorator
{
    /// <summary>
    /// 装饰器模式
    /// 允许向一个现有的对象添加新的功能，同时不改变其结构
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---装饰器模式---");

            MilkTea milkTea = new MilkTea();
            Cream cream = new Cream();
            Pearl pearl = new Pearl();

            cream.SetComponent(milkTea);
            pearl.SetComponent(cream);
            Console.WriteLine(pearl.Cost());

            Console.ReadKey();
        }
    }
}
