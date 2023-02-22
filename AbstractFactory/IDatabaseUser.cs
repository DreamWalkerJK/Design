using System;

namespace AbstractFactory
{
    /// <summary>
    /// 抽象产品（用户）
    /// </summary>
    public interface IDatabaseUser
    {
        void Insert(User user);
        User Get(int id);
    }

    public class SqlServerUser : IDatabaseUser
    {
        public User Get(int id)
        {
            Console.WriteLine($"SqlServer get user by id : {id} ");
            return null;
        }

        public void Insert(User user)
        {
            Console.WriteLine($"SqlServer insert user : {user.Name}");
        }
    }

    public class MySqlUser : IDatabaseUser
    {
        public User Get(int id)
        {
            Console.WriteLine($"MySql get user by id : {id} ");
            return null;
        }

        public void Insert(User user)
        {
            Console.WriteLine($"MySql insert user : {user.Name}");
        }
    }

    public class SqliteUser : IDatabaseUser
    {
        public User Get(int id)
        {
            Console.WriteLine($"Sqlite get user by id : {id} ");
            return null;
        }

        public void Insert(User user)
        {
            Console.WriteLine($"Sqlite insert user : {user.Name}");
        }
    }
}
