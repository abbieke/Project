using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Project.Repository
{
    /// <summary>
    /// 訂單儲存庫
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// 連接字串
        /// </summary>
        private static string connString;

        /// <summary>
        /// 開啟連接
        /// </summary>
        private SqlConnection conn;

        /// <summary>
        /// 建構子
        /// </summary>
        public OrderRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["Order"].ConnectionString;
            }

            //conn = new SqlConnection(connString);
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <typeparam name="TModel">查詢回傳類型</typeparam>
        /// <param name="sql">查詢語法</param>
        /// <param name="param">參數物件</param>
        /// <returns>結果</returns>
        public IEnumerable<TModel> Query<TModel>(string sql, object param = null)
        {
            using (conn = new SqlConnection(connString))
            {
                return conn.Query<TModel>(sql, param);
            }
        }

        /// <summary>
        /// 執行 Sql
        /// </summary>
        /// <param name="sql">Sql語法</param>
        /// <param name="param">參數物件</param>
        /// <returns>執行結果</returns>
        public int Execute(string sql, object param = null)
        {
            using (conn = new SqlConnection(connString))
            {
                return conn.Execute(sql, param);
            }
        }
    }
}