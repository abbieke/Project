using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

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
        /// 參數表服務
        /// </summary>
        private readonly IShippingOrderService ShippingOrderService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="orderRepository">訂單儲存庫</param>
        public OrderService(
            IOrderRepository orderRepository,
            IShippingOrderService shippingOrderService)
        {
            this.OrderRepository = orderRepository;
            this.ShippingOrderService = shippingOrderService;
        }

        /// <summary>
        /// 取得會員訂單清單
        /// </summary>
        /// <returns>訂單清單</returns>
        public List<OrderViewModel> GetMemberOrderList(int memberId)
        {
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
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        List<string> orderIds = viewModel.Select(x => x.Id).ToList();

                        this.OrderRepository.Execute(sql, new { Status = (int)OrderStatusEnum.ToBeShipped, OrderIds = orderIds.ToArray() });

                        orderIds.ForEach(x => this.ShippingOrderService.InsertShippingOrder(x));

                        scope.Complete();
                    }

                    // 紀錄更新完成
                }
                catch(Exception ex)
                {
                    // 紀錄訂單更新失敗
                }
                
            }
        }
    }
}