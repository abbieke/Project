using Project.Repository.Models;
using System.Collections.Generic;

namespace Project.Service
{
    /// <summary>
    /// 配送訂單服務介面
    /// </summary>
    public interface IShippingOrderService
    {
        /// <summary>
        /// 新增配送訂單
        /// </summary>
        /// <param name="orderId">訂單編號</param>
        void InsertShippingOrder(string orderId);

        /// <summary>
        /// 取得配送訂單清單
        /// </summary>
        /// <param name="memberId">會員編號</param>
        /// <returns>配送訂單清單</returns>
        List<ShippingOrder> GetShippingOrders(int memberId);
    }
}