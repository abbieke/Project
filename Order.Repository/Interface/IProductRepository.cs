namespace Project.Repository
{
    /// <summary>
    /// 商品儲存庫介面
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// 查詢
        /// </summary>
        /// <typeparam name="TModel">查詢回傳類型</typeparam>
        /// <param name="sql">查詢語法</param>
        /// <param name="param">參數物件</param>
        /// <returns>結果</returns>
        TModel Query<TModel>(string sql, object param = null);
    }
}