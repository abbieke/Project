using Project.Repository.Models;
using System.ComponentModel;

namespace Project.Service
{
    /// <summary>
    /// 訂單 ViewModel
    /// </summary>
    public class OrderViewModel : Order
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        [DisplayName("商品編號")]
        public int ProductId { get; set; }

        /// <summary>
        /// 購買數量
        /// </summary>
        [DisplayName("購買數量")]
        public int Count { get; set; }

        /// <summary>
        /// 是否選取
        /// </summary>
        public bool IsSelect { get; set; } = false;
    }
}