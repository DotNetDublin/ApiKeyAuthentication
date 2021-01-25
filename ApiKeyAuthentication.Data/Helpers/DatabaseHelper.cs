using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ApiKeyMiddleware.Data.Helpers
{
    class DatabaseHelper
    {
        public readonly IDbConnection _dbConnection;

        public DatabaseHelper(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public bool Delete<T>(T entity) where T : class
        {
            return _dbConnection.Delete(entity);
        }

        public bool Delete(string query, object parameters)
        {
            return _dbConnection.Execute(query, parameters) > 0;
        }

        public int Execute(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            return _dbConnection.Execute(query, parameters, commandType: commandType);
        }

        public List<T> GetAll<T>() where T : class
        {
            return _dbConnection.GetAll<T>().ToList();
        }

        public T GetById<T>(int id) where T : class
        {
            return _dbConnection.Get<T>(id);
        }

        public T GetById<T>(string id) where T : class
        {
            return _dbConnection.Get<T>(id);
        }

        public T GetFirst<T>(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            return _dbConnection.Query<T>(query, parameters, commandType: commandType).First();
        }

        public T GetFirstOrDefault<T>(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            return _dbConnection.Query<T>(query, parameters, commandType: commandType).FirstOrDefault();
        }

        public long Insert<T>(T entity) where T : class
        {
            return _dbConnection.Insert(entity);
        }

        public List<T> Query<T>(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            return _dbConnection.Query<T>(query, parameters, commandType: commandType).ToList();
        }

        public T QueryFirstOrDefault<T>(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            return _dbConnection.QueryFirstOrDefault<T>(query, parameters, commandType: commandType);
        }

        public T QuerySingle<T>(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            return _dbConnection.QuerySingle<T>(query, parameters, commandType: commandType);
        }

        public bool Update<T>(T entity) where T : class
        {
            return _dbConnection.Update(entity);
        }
    }
}
