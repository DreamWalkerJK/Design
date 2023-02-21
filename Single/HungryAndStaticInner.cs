namespace Single
{
    /// <summary>
    /// 饿汉式+静态内部类
    /// 优点：线程安全
    /// </summary>
    public class HungryAndStaticInner
    {
        public static class InnerClass
        {
            public readonly static HungryAndStaticInner _single = new HungryAndStaticInner();
        }

        public static HungryAndStaticInner GetSingle()
        {
            return InnerClass._single;
        }
    }
}
