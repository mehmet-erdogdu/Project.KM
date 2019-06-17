using Dapper;
using Dapper.FastCrud;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace Project.Domain
{
    public abstract class BaseDataServices<T> where T : BaseDataEntities
    {
        readonly string ConnectionString = "Data Source=MEHMET-PC;Initial Catalog=Project_KM;Integrated Security=True";

        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }

        protected T GetData(string query, object param = null)
        {
            return Connection.QuerySingleOrDefault<T>(query, param);
        }

        protected List<T> GetDataList(string query, object param = null)
        {
            return Connection.Query<T>(query, param).ToList();
        }

        protected int ExecuteCommandText(string query, object param = null)
        {
            return Connection.Execute(query, param, commandType: CommandType.Text);
        }

        protected int ExecuteCommandScalar(string query,object param=null)
        {
            return Connection.ExecuteScalar<int>(query, param, commandType: CommandType.Text);
        }

        protected List<T> ExecuteCommandProcedure(string query, object param = null)
        {
            return Connection.Query<T>(query, param, commandType: CommandType.StoredProcedure).ToList();
        }


        protected int Insert(T item) //FastCrud
        {
             Connection.Insert<T>(item);
            return item.Id; //Kayıttan sonra id döner
        }

        protected bool Update(T item) //FastCrud
        {
             return Connection.Update<T>(item);
        }

        protected bool Delete(T item) //FastCrud
        {
            return Connection.Delete<T>(item);
        }
    }
}
