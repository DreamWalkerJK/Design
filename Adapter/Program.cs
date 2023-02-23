using System;

namespace Adapter
{
    /// <summary>
    /// 适配器模式
    /// 优点：
    /// 1、复用性
    /// 2、若功能已存在，只是接口不兼容，适配器模式可是这些功能得到更好的复用
    /// 缺点：增加系统的复杂度
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---适配器模式---");

            IPhoneCharge phoneCharge = new PhoneChargeAdapter();
            phoneCharge.PhoneCharge();

            Console.ReadKey();
        }
    }
}
