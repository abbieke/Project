using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class ShippingOrderQueryBuilder
    {
        public ShippingOrderQueryBuilder()
        { 
        }

        /// <summary>
        /// 取得新增配送訂單Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetInsertShippingOrderSql()
        {
            return @"
                    INSERT INTO
                            shippingorder
                            (
                                    shippingorder_id     ,
                                    shippingorder_orderid,
                                    shippingorder_status ,
                                    shippingorder_createdat
                            )
                            VALUES
                            (
                                    @Id      ,
                                    @OrderId ,
                                    @Status  ,
                                    @CteatedAt
                            )";
        }

        /// <summary>
        /// 取得查詢配送訂單Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetShippingOrdersSql()
        {
            return @"
                    SELECT
                            shippingorder_id        AS Id     ,
                            shippingorder_orderid   AS OrderId,
                            shippingorder_status    AS Status ,
                            shippingorder_createdat AS CteatedAt
                    FROM
                            shippingorder
                    INNER JOIN
                            [ORDER]
                    ON
                            [ORDER].order_id = shippingorder.shippingorder_orderid
                    WHERE
                            order_memberid = @MemberId 	";
        }
    }
}
