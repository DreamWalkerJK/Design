using System;

namespace Prototype
{
    /// <summary>
    /// 通过继承实现ICloneable接口实现浅拷贝
    /// 实现步骤：
    /// 1、定义一个类继承ICloneable接口
    /// 2、使用this.MemberwiseClone实现接口
    /// </summary>
    public class ShadowCloneByICloneable
    {
        public static void Test()
        {
            Console.WriteLine("---继承ICloneable实现浅克隆---");
            Teacher teacher = new Teacher("Ross");
            Teacher teacher1 = (Teacher)teacher.Clone();

            Console.WriteLine($"teacher : {teacher.GetHashCode()}");
            Console.WriteLine($"teacher1 : {teacher1.GetHashCode()}");
            Console.WriteLine($"teacher1's name : {teacher1.Name}");

            teacher.MyStudent = new MyStudent()
            {
                Name = "张三",
                Age = 21
            };
            Teacher teacher2 = (Teacher)teacher.Clone();
            teacher2.Name = "Ross2";
            teacher2.MyStudent.Name = "李四";
            teacher2.MyStudent.Age = 12;

            Console.WriteLine($"Teacher:{teacher.Name}; MyStudent : {teacher.MyStudent.Name} {teacher.MyStudent.Age}");
            Console.WriteLine($"Teacher2:{teacher2.Name}; MyStudent : {teacher2.MyStudent.Name} {teacher2.MyStudent.Age}");

            Console.WriteLine("---伪深拷贝测试---");
            TeacherNew teacherNew = new TeacherNew();
            teacherNew.Name = "Tom";
            teacherNew.MyStudentNew = new MyStudentNew()
            {
                Name = "xiyangyang",
                Age = 11
            };
            TeacherNew teacherNew1 = (TeacherNew)teacherNew.Clone();
            teacherNew1.Name = "Tom1";
            teacherNew1.MyStudentNew.Name = "lanyangyang";
            teacherNew1.MyStudentNew.Age = 10;

            Console.WriteLine($"TeacherNew:{teacherNew.Name}; MyStudentNew : {teacherNew.MyStudentNew.Name} {teacherNew.MyStudentNew.Age}");
            Console.WriteLine($"TeacherNew1:{teacherNew1.Name}; MyStudentNew : {teacherNew1.MyStudentNew.Name} {teacherNew1.MyStudentNew.Age}");
        }
    }

    public class Teacher : ICloneable
    {
        public string Name { get; set; }

        public Teacher(string name)
        {
            Name = name;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// 验证浅拷贝只对值类型成员复制生成新值，对引用类型只是复制其引用，并不复制其对象
        /// </summary>
        public MyStudent MyStudent { get; set; }

        public void Show()
        {
            Console.WriteLine($"Teacher : {Name}");
            Console.WriteLine($"MyStudent Name : {MyStudent.Name}");
            Console.WriteLine($"MyStudent Age : {MyStudent.Age}");
        }
    }

    public class MyStudent
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// 伪深拷贝方式
    /// </summary>
    public class TeacherNew : ICloneable
    {
        public string Name { get; set; }
        public MyStudentNew MyStudentNew { get; set; }

        public TeacherNew()
        {
            MyStudentNew = new MyStudentNew();
        }

        public TeacherNew(MyStudentNew myStudentNew)
        {
            MyStudentNew = (MyStudentNew)myStudentNew.Clone();
        }
        public object Clone()
        {
            TeacherNew teacherNew = new TeacherNew(MyStudentNew)
            {
                Name = Name
            };
            return teacherNew;
        }

        public void Show(string objectName)
        {
            Console.WriteLine($"object name {objectName} : {Name}");
            Console.WriteLine($"MyStudentNew : {MyStudentNew.Name} - {MyStudentNew.Age}") ;
        }
    }

    public class MyStudentNew : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
