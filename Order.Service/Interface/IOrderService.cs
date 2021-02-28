using System.Collections.Generic;

namespace Project.Service
{
    /// <summary>
    /// 訂單服務介面
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// 取得會員訂單清單
        /// </summary>
        /// <returns>訂單清單</returns>
        List<OrderViewModel> GetMemberOrderList();

        /// <summary>
        /// 更新訂單狀態
        /// </summary>
        /// <param name="viewModel">訂單ViewModel</param>
        void UpdateOrderStatus(List<OrderViewModel> viewModel);
    }
}