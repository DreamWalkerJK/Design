namespace AbstractFactory
{
    /// <summary>
    /// 顶层抽象工厂
    /// </summary>
    public interface IFactory
    {
        IDatabaseUser GetDatabaseUser();
        IDatabaseDepartment GetDatabaseDepartment();
    }

    public class SqlServerFactory : IFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {
            return new SqlServerDepartment();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new SqlServerUser();
        }
    }

    public class MySqlFactory : IFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {
            return new MySqlDepartment();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new MySqlUser();
        }
    }

    public class SqliteFactory : IFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {
            return new SqliteDepartment();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new SqliteUser();
        }
    }
}
