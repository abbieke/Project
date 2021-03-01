using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace Project.Repository
{
    /// <summary>
    /// 商品儲存庫
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private static string connString;
        private SqlConnection conn;

        public ProductRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["Order"].ConnectionString;
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <typeparam name="TModel">查詢回傳類型</typeparam>
        /// <param name="sql">查詢語法</param>
        /// <param name="param">參數物件</param>
        /// <returns>結果</returns>
        public TModel Query<TModel>(string sql, object param = null)
        {
            using (conn = new SqlConnection(connString))
            {
                return conn.QueryFirstOrDefault<TModel>(sql, param);
            }
        }
    }
}