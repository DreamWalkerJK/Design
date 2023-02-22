using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---抽象工厂设计模式---");
            User user = new User();
            user.Id = 0;
            user.Name = "test";
            Department department = new Department();
            department.Id = 0;
            department.Name = "departmentTest";

            IFactory factory = new SqlServerFactory(); // new MySqlFactory() | new SqliteFactory()
            IDatabaseUser databaseUser = factory.GetDatabaseUser();
            databaseUser.Insert(user);
            databaseUser.Get(user.Id);
            IDatabaseDepartment databaseDepartment = factory.GetDatabaseDepartment();
            databaseDepartment.Insert(department);
            databaseDepartment.Get(department.Id);

            Console.ReadKey();
        }
    }
}
