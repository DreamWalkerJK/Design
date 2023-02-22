using System;

namespace Prototype
{
    /// <summary>
    /// 通过this.MemberwiseClone()实现浅拷贝
    /// 实现步骤：
    /// 1、定义一个抽象原型类
    /// 2、继承该抽象类，重写抽象方法，逻辑使用this.MemberwiseClone()
    /// </summary>
    public class ShadowCloneByMemberwiseClone
    {
        public static void Test() 
        {
            Console.WriteLine("---通过this.MemberwiseClone()实现浅克隆---");
            Student student = new Student("Jack");
            Student student1 = (Student)student.Clone();

            Console.WriteLine($"student : {student.GetHashCode()}");
            Console.WriteLine($"student1 : {student1.GetHashCode()}");
            Console.WriteLine($"student1's name : {student1.Name}");
        }
    }

    /// <summary>
    /// 原型抽象类（学生）
    /// </summary>
    public abstract class StudentPrototype
    {
        public string Name { get; set; }

        public StudentPrototype(string name)
        {
            Name = name;
        }

        public abstract StudentPrototype Clone();
    }

    /// <summary>
    /// 学生类，重写clone()
    /// </summary>
    public class Student : StudentPrototype
    {
        public Student(string name) : base(name) { }

        public override StudentPrototype Clone()
        {
            return (StudentPrototype)this.MemberwiseClone();
        }
    }
}
