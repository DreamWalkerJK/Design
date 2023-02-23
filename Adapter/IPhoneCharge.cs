namespace Adapter
{
    /// <summary>
    /// Target:目标角色，定义了用户希望的接口
    /// </summary>
    public interface IPhoneCharge
    {
        void PhoneCharge();
    }

    /// <summary>
    /// Adapter：适配器角色，实现目标接口
    /// 实现方法是内部包含了一个Adaptee对象，通过调用此对象原有的方法实现功能
    /// </summary>
    public class PhoneChargeAdapter : IPhoneCharge
    {
        // Adapter中封装了一个实际实现功能对象的Adapter
        private AndroidChargeAdapter androidChargeAdapter = new AndroidChargeAdapter();
        public void PhoneCharge()
        {
            androidChargeAdapter.AndroidCharge();
        }
    }
}
