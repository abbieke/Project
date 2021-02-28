namespace Project.Repository.Models
{
    /// <summary>
    /// 訂單詳細資料
    /// </summary>
    public class OrderDetail
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 商品編號
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 購買數量
        /// </summary>
        public int Count { get; set; }
    }
}