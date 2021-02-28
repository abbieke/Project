namespace Project.Service
{
    /// <summary>
    /// 商品 QueryBuilder
    /// </summary>
    public class ProductQueryBuilder
    {
        /// <summary>
        /// 建構子
        /// </summary>
        public ProductQueryBuilder()
        { }

        /// <summary>
        /// 取得商品資訊 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetProductSql()
        {
            return @"
                    SELECT
                            product_id    AS Id    ,
                            product_name  AS Name  ,
                            product_price AS Price ,
                            product_cost  AS Cost
                    FROM
                            product
                    WHERE
                            product_id = @Id";
        }
    }
}