using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository
    {
        private string _conn { get; set; }

        public GenericRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public bool Insert(string query, object obj)
        {
            int result;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();

                result = db.Execute(query, obj);

                db.Close();
            }

            return result > 0;
        }

        public List<T> GetAll<T>(string query)
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();

                var list = db.Query<T>(query);
                return (List<T>)list;
            }
        }
    }
}
