using System;

namespace Builder
{
    /// <summary>
    /// 建造者模式
    /// 1、注重方法的调用顺序
    /// 2、建造者模式创建复杂的对象
    /// 3、建造者不仅创建对象还需知道此对象由哪些对象组成
    /// 4、根据创建过程中的顺序不同，最终的对象部件组成也不一样
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---建造者模式---");

            IBuilderComputer builder = new ComputerA();
            IBuilderComputer builder1 = new ComputerB();
            Directory directory = new Directory();
            directory.BuildComputer(builder);
            var computerA = builder.GetComputer();
            computerA.ShowComputer();

            directory.BuildComputer(builder1);
            var computerB = builder1.GetComputer();
            computerB.ShowComputer();

            Console.ReadKey();
        }
    }
}
