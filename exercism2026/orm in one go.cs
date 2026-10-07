using System;

namespace Orm_in_one_go
{
    // Clase simulada para que Visual Studio reconozca 'Database'
    public class Database : IDisposable
    {
        public void BeginTransaction() { }
        public void Write(string data) { }
        public void EndTransaction() { }
        public void Dispose() { }
    }

    public class Orm
    {
        private readonly Database _database;

        public Orm(Database database)
        {
            _database = database;
        }

        public void Write(string data)
        {
            try
            {
                _database.BeginTransaction();
                _database.Write(data);
                _database.EndTransaction();
            }
            finally
            {
                _database.Dispose();
            }
        }

        public bool WriteSafely(string data)
        {
            try
            {
                Write(data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new Database();
            var orm = new Orm(db);
            orm.WriteSafely("test");
        }
    }
}