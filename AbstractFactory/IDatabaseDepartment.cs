using System;

namespace AbstractFactory
{
    /// <summary>
    /// 抽象产品（部门）
    /// </summary>
    public interface IDatabaseDepartment
    {
        void Insert(Department department);
        Department Get(int id);
    }

    public class SqlServerDepartment : IDatabaseDepartment
    {
        public Department Get(int id)
        {
            Console.WriteLine($"SqlServer get department by id : {id} ");
            return null;
        }

        public void Insert(Department department)
        {
            Console.WriteLine($"SqlServer insert department : {department.Name}");
        }
    }

    public class MySqlDepartment : IDatabaseDepartment
    {
        public Department Get(int id)
        {
            Console.WriteLine($"MySql get department by id : {id} ");
            return null;
        }

        public void Insert(Department department)
        {
            Console.WriteLine($"MySql insert department : {department.Name}");
        }
    }

    public class SqliteDepartment : IDatabaseDepartment
    {
        public Department Get(int id)
        {
            Console.WriteLine($"Sqlite get department by id : {id} ");
            return null;
        }

        public void Insert(Department department)
        {
            Console.WriteLine($"Sqlite insert department : {department.Name}");
        }
    }
}
