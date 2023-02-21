using System;

namespace Single
{
    /// <summary>
    /// 饿汉式单例
    /// 缺点：还未调用对象就已创建，造成资源的浪费
    /// </summary>
    public class Hungry
    {
        private readonly static Hungry _single = new Hungry();

        private Hungry() { }

        public static Hungry GetSingle()
        {
            return _single;
        }
    }

    public class HungryTest
    {
        private static void TestHashCodeIsSame()
        {
            Console.WriteLine("测试生成的多个单例哈希值是否一致");

            var single = Hungry.GetSingle();
            var single1 = Hungry.GetSingle();
            var single2 = Hungry.GetSingle();

            Console.WriteLine("single:{0}", single.GetHashCode());
            Console.WriteLine("single1:{0}", single1.GetHashCode());
            Console.WriteLine("single2:{0}", single2.GetHashCode());
        }

        public static void Test()
        {
            Console.WriteLine("---饿汉式单例测试---");
            TestHashCodeIsSame();
        }
    }
}
