using System;

namespace Single
{
    class Program
    {
        static void Main(string[] args)
        {
            //HungryTest.Test();
            //LazyTest.Test();

            //LazyDoublcLockTest.Test();

            //LazyDoubleLockAndReflectionTest.Test();

            LazyDoubleLockAndReflectionFirstTest.Test();

            Console.ReadKey();
        }
    }
}
