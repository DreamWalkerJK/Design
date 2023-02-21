using System;

namespace Single
{
    /// <summary>
    /// 懒汉式双锁单例尝试解决反射问题
    /// 第一次通过执行GetSingle获取单例，其次再执行反射执行构造函数才会抛出异常
    /// </summary>
    public class LazyDoubleLockAndReflection
    {
        private volatile static LazyDoubleLockAndReflection _single;
        private static object _obj = new object();

        /// <summary>
        /// 反射通过构造函数创建对象，对构造函数做处理
        /// </summary>
        private LazyDoubleLockAndReflection()
        {
            lock (_obj)
            {
                if(_single != null)
                {
                    throw new Exception("不要通过反射来创建对象！");
                }
            }
        }

        public static LazyDoubleLockAndReflection GetSingle()
        {
            if(_single == null)
            {
                lock (_obj)
                {
                    if(_single == null)
                    {
                        Console.WriteLine("单例被创建一次！");
                        _single = new LazyDoubleLockAndReflection();
                    }
                }
            }
            return _single;
        }
    }

    public class LazyDoubleLockAndReflectionTest
    {
        private static void TestReflection()
        {
            Console.WriteLine("测试反射是否破坏单例");

            var single = LazyDoubleLockAndReflection.GetSingle();

            var type = Type.GetType("Single.LazyDoubleLockAndReflection");
            // 获取私有的构造函数
            var ctors = type?.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            // 执行构造函数
            LazyDoubleLockAndReflection single1 = (LazyDoubleLockAndReflection)ctors[0].Invoke(null);
            Console.WriteLine("single:{0}", single.GetHashCode());
            Console.WriteLine("single1:{0}", single1.GetHashCode());
        }

        public static void Test()
        {
            Console.WriteLine("---懒汉式双锁尝试解决反射问题测试---");
            TestReflection();
        }
    }
}
