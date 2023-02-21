using System;
using System.Reflection;

namespace Single
{
    /// <summary>
    /// 懒汉式双锁尝试解决反射问题
    /// 第一次反射通过构造函数创建对象就报异常
    /// </summary>
    public class LazyDoubleLockAndReflectionFirst
    {
        private volatile static LazyDoubleLockAndReflectionFirst _single;
        private static object _obj = new object();
        private static bool _isOk = false;

        /// <summary>
        /// 反射通过构造函数创建对象，对构造函数做处理，增加局部变量
        /// </summary>
        private LazyDoubleLockAndReflectionFirst()
        {
            lock (_obj)
            {
                if(_isOk == false)
                {
                    _isOk = true;
                }
                else
                {
                    throw new Exception("只有第一次通过反射创建对象会成功！");
                }
            }
        }

        public static LazyDoubleLockAndReflectionFirst GetSingle()
        {
            if(_single == null)
            {
                lock (_obj)
                {
                    if(_single == null)
                    {
                        Console.WriteLine("单例被创建一次！");
                        _single = new LazyDoubleLockAndReflectionFirst();
                    }
                }
            }
            return _single;
        }
    }

    public class LazyDoubleLockAndReflectionFirstTest
    {
        private static LazyDoubleLockAndReflectionFirst GetReflectionInstance()
        {
            var type = Type.GetType("Single.LazyDoubleLockAndReflectionFirst");
            // 获取私有的构造函数
            var ctors = type?.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            // 执行构造函数
            LazyDoubleLockAndReflectionFirst single = (LazyDoubleLockAndReflectionFirst)ctors[0].Invoke(null);
            return single;
        }

        private static void TestReflection()
        {
            // 第一次通过反射创建对象会成功
            var single = GetReflectionInstance();

            // 第二次通过反射创建对象会失败，报异常
            var single1 = GetReflectionInstance();

            Console.WriteLine("single:{0}", single.GetHashCode());
            Console.WriteLine("single1:{0}", single1.GetHashCode());
        }

        private static void TestReflectionChangeIsOk()
        {
            var type = Type.GetType("Single.LazyDoubleLockAndReflectionFirst");

            // 获取私有的构造函数
            var ctors = type?.GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            // 执行构造函数
            LazyDoubleLockAndReflectionFirst single = (LazyDoubleLockAndReflectionFirst)ctors[0].Invoke(null);
            // 改变私有局部变量_isOk的值
            FieldInfo fieldInfo = type.GetField("_isOk", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            fieldInfo.SetValue("_isOk", false);
            LazyDoubleLockAndReflectionFirst single1 = (LazyDoubleLockAndReflectionFirst)ctors[0].Invoke(null);
            Console.WriteLine("single:{0}", single.GetHashCode());
            Console.WriteLine("single1:{0}", single1.GetHashCode());
        }

        public static void Test()
        {
            Console.WriteLine("---懒汉式双锁+局部变量尝试解决反射问题测试---");
            TestReflectionChangeIsOk();
        }
    }
}
