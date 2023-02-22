using System;

/// <summary>
/// 原型模式
/// 不需要每次都new一个新的实例，而是通过拷贝现有对象来完成创建
/// 解决需要使用的实例创建过多耗费资源或创建繁琐的问题
/// 浅拷贝
/// 值类型成员：全都复制一份，并生成新的
/// 引用类型成员：复制其引用，并不复制其对象生成新的
/// </summary>
namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            ShadowCloneByMemberwiseClone.Test();
            ShadowCloneByICloneable.Test();

            Console.ReadKey();
        }
    }
}
