using System;

namespace Proxy
{
    /// <summary>
    /// 代理模式
    /// 给某个对象提供一个代理，并由代理对象控制原对象的引用
    /// 代理对象可以在客户端和目标对象之间起到中介的作用
    /// 优点：
    /// 1、代理模式能够将真正被调用的对象隔离，降低系统耦合度
    /// 2、代理对象在客户端和目标对象之间起到一个中介的作用，这样可以起到对目标对象的保护。
    /// 缺点：
    /// 1、由于增加了一个代理对象，会造成请求的处理速度变慢
    /// 2、实现代理类增加了系统的实现复杂度
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---代理模式---");
            IP iP = new IP("127.0.0.1");
            RealIP realIP = new RealIP(iP);

            // 生成代理对象，传入被代理的对象
            Proxy proxy = new Proxy(realIP);
            ISubject subject = proxy;
            subject.VisitWebSite();
            subject.WatchVideo();
            subject.BrowseNews();

            Console.ReadKey();
        }
    }
}
