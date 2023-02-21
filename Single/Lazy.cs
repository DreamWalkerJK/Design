using System;
using System.Threading;

namespace Single
{
    /// <summary>
    /// 懒汉式单例
    /// 优点：只有在调用方法时才会去创建，不会造成资源的浪费
    /// 缺点：线程不安全
    /// </summary>
    public class Lazy
    {
        private static Lazy _single;

        private Lazy() { }

        public static Lazy GetSingle()
        {
            if(_single == null)
            {
                Console.WriteLine("单例被创建一次！");
                _single = new Lazy();
            }
            return _single;
        }
    }

    public class LazyTest
    {
        private static void TestHashCodeIsSame()
        {
            Console.WriteLine("测试生成的多个单例哈希值是否一致");

            var single = Lazy.GetSingle();
            var single1 = Lazy.GetSingle();
            Console.WriteLine("single:{0}", single.GetHashCode());
            Console.WriteLine("single1:{0}", single1.GetHashCode());
        }

        /// <summary>
        /// 测试多线程环境
        /// </summary>
        private static void TestMultiThread()
        {
            Console.WriteLine("测试多线程环境");
            for(var i = 0; i < 10; i++)
            {
                new Thread(() =>
                {
                    Lazy.GetSingle();
                }).Start();
            }
        }

        public static void Test()
        {
            Console.WriteLine("---懒汉式单例测试---");
            TestHashCodeIsSame();
            TestMultiThread();
        }
    }
}
