namespace Project.Service
{
    /// <summary>
    /// 訂單QueryBuilder
    /// </summary>
    public class OrderQueryBuilder
    {
        public OrderQueryBuilder()
        { }

        /// <summary>
        /// 取得會員訂單清單 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetMemberOrderListSql()
        {
            return @"
                    SELECT
                            order_id              AS Id       ,
                            order_memberid        AS MemberId ,
                            order_status          AS Status   ,
                            order_price           AS Price    ,
                            order_cost            AS Cost     ,
                            orderdetail_productid AS ProductId
                    FROM
                            [ORDER]
                    INNER JOIN
                            orderdetail
                    ON
                            [ORDER].order_id = orderdetail.orderdetail_orderid
                    WHERE
                            order_memberid = @MemberId";
        }

        /// <summary>
        /// 取得更新訂單狀態 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetUpdateStatusSql()
        {
            return @"
                      UPDATE
                              [ORDER]
                      SET
                              order_status = @Status
                      WHERE
                              order_id IN @OrderIds";
        }
    }
}