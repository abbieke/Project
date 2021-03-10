using System;

namespace Project.Repository.Models
{
    /// <summary>
    /// 配送訂單
    /// </summary>
    public class ShippingOrder
    {
        /// <summary>
        /// 配送編號
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 配送狀態
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CteatedAt { get; set; }
    }
}