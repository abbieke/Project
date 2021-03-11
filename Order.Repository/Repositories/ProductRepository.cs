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
        /// <summary>
        /// 連線字串
        /// </summary>
        private static string connString;

        /// <summary>
        /// 開啟連接
        /// </summary>
        private SqlConnection conn;

        /// <summary>
        /// 建構子
        /// </summary>
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
            using (this.conn = new SqlConnection(connString))
            {
                return this.conn.QueryFirstOrDefault<TModel>(sql, param);
            }
        }
    }
}