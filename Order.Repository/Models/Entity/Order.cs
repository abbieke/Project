using System.ComponentModel;

namespace Project.Repository.Models
{
    /// <summary>
    /// 訂單
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 訂單編號
        /// </summary>
        [DisplayName("訂單編號")]
        public string Id { get; set; }

        /// <summary>
        /// 會員編號
        /// </summary>
        [DisplayName("會員編號")]
        public int MemberId { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        [DisplayName("訂單狀態")]
        public int Status { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        [DisplayName("價格")]
        public decimal Price { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        [DisplayName("成本")]
        public decimal Cost { get; set; }

        /// <summary>
        /// 訂單狀態列舉
        /// </summary>
        public OrderStatusEnum OrderStatus
        {
            get => (OrderStatusEnum)this.Status;
            set => this.Status = (int)value;
        }
    }
}