using System;

namespace Single
{
    /// <summary>
    /// 懒汉式双锁
    /// 解决懒汉式单例线程不安全问题
    /// </summary>
    public class LazyDoubleLock
    {
        private LazyDoubleLock() { }

        // private static LazyAndReflection? _single; 版本不够，需C# 8.0 及 C# 8.0+
        private volatile static LazyDoubleLock _single;
        private static object _obj = new object();

        /// <summary>
        /// 双重锁定，减少系统消耗，节省资源
        /// </summary>
        /// <returns></returns>
        public static LazyDoubleLock GetSingle()
        {
            if(_single == null)
            {
                lock (_obj)
                {
                    if(_single == null)
                    {
                        Console.WriteLine("单例被创建一次！");
                        _single = new LazyDoubleLock();
                    }
                }
            }
            return _single;
        }
    }

    public class LazyDoublcLockTest
    {
        private static void TestReflection()
        {
            Console.WriteLine("测试反射是否破坏单例");

            var single = LazyDoubleLock.GetSingle();
            var type = Type.GetType("Single.LazyDoubleLock");
            // 获取私有函数
            var ctors = type?.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            // 执行构造函数
            LazyDoubleLock single1 = (LazyDoubleLock)ctors[0].Invoke(null);
            Console.WriteLine("single:{0}", single.GetHashCode());
            Console.WriteLine("single1:{0}", single1.GetHashCode());
        }

        public static void Test()
        {
            Console.WriteLine("---懒汉式双锁测试---");
            TestReflection();
        }
    }
}
