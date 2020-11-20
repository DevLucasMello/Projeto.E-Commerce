using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace PcSantos.Repository
{
    public static class DbHelper
    {
        private const string _conexao =
            @"server=localhost;database=PcSantosDb;user=root;password=Lm@518792";

        public static MySqlConnection ObterConexao()
        {
            var cn = new MySqlConnection();
            cn.ConnectionString = _conexao;
            return cn;
        }

        public static int Execute(string sql, object parametro)
        {
            using (var cn = ObterConexao())
            {
                return cn.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
            }
        }

        public static List<T> Query<T>(string sql, object parametro)
        {
            using (var cn = ObterConexao())
            {
                return cn.Query<T>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        public static T QueryFirstOrDefault<T>(string sql, object parametro)
        {
            using (var cn = ObterConexao())
            {
                return cn.QueryFirstOrDefault<T>(sql, parametro, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
