using System;

namespace Proxy
{
    /// <summary>
    /// Subject接口
    /// 定义了RealSubject和Proxy的公用接口，这样就在任何使用RealSubject的地方都可以使用Proxy
    /// </summary>
    public interface ISubject
    {
        void VisitWebSite();
        void WatchVideo();
        void BrowseNews();
    }

    /// <summary>
    /// RealSubject类
    /// 定义Proxy代理所代表的真实实体
    /// </summary>
    public class RealIP : ISubject
    {
        private readonly IP _iP;
        
        public RealIP(IP iP)
        {
            _iP = iP;
        }

        public void BrowseNews()
        {
            Console.WriteLine($"{_iP.Address} : 浏览新闻");
        }

        public void VisitWebSite()
        {
            Console.WriteLine($"{_iP.Address} : 访问网址");
        }

        public void WatchVideo()
        {
            Console.WriteLine($"{_iP.Address} : 查看视频");
        }
    }

    /// <summary>
    /// Proxy类
    /// 代理类，保存一个实体引用使得代理可以访问实体
    /// </summary>
    public class Proxy : ISubject
    {
        private readonly RealIP _realIP;

        public Proxy(RealIP realIP)
        {
            _realIP = realIP;
        }

        public void BrowseNews()
        {
            _realIP.BrowseNews();
        }

        public void VisitWebSite()
        {
            _realIP.VisitWebSite();
        }

        public void WatchVideo()
        {
            _realIP.WatchVideo();
        }
    }
}
