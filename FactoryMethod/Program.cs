using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactory.Test();

            FactoryMethod.Test();

            FactoryMethodUseReflectionWithoutSwitch.Test();

            Console.ReadKey();
        }
    }
}
