using System;

namespace Adapter
{
    /// <summary>
    /// Adaptee：初始角色，实现了用户想要的功能，但是接口不匹配
    /// </summary>
    public class AndroidChargeAdapter
    {
        public void AndroidCharge()
        {
            Console.WriteLine("Android充电线充电！");
        }
    }
}
