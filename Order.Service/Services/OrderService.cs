using Project.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service
{
    /// <summary>
    /// 訂單服務
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <summary>
        /// 訂單儲存庫
        /// </summary>
        private readonly IOrderRepository OrderRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        public OrderService(IOrderRepository orderRepository)
        {
            this.OrderRepository = orderRepository;
        }

        /// <summary>
        /// 取得會員訂單清單
        /// </summary>
        /// <returns>訂單清單</returns>
        public List<OrderViewModel> GetMemberOrderList()
        {
            int memberId = 1;

            OrderQueryBuilder builder = new OrderQueryBuilder();
            string sql = builder.GetMemberOrderListSql();

            return this.OrderRepository.Query<OrderViewModel>(sql, new { MemberId = memberId }).ToList();
        }

        /// <summary>
        /// 更新訂單狀態
        /// </summary>
        /// <param name="viewModel">訂單ViewModel</param>
        public void UpdateOrderStatus(List<OrderViewModel> viewModel)
        {
            viewModel = viewModel.Where(x => x.IsSelect == true).ToList();

            OrderQueryBuilder builder = new OrderQueryBuilder();
            string sql = builder.GetUpdateStatusSql();

            if (viewModel.Count != 0)
            {
                this.OrderRepository.Execute(sql, new { Status = (int)OrderStatusEnum.ToBeShipped, OrderIds = viewModel.Select(x => x.Id).ToArray() });
            }
        }
    }
}