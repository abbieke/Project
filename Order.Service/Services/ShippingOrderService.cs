using Project.Repository;
using Project.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    /// <summary>
    /// 配送訂單服務
    /// </summary>
    public class ShippingOrderService : IShippingOrderService
    {
        /// <summary>
        /// 配送訂單儲存庫
        /// </summary>
        private readonly IShippingOrderRepository ShippingOrderRepository;

        /// <summary>
        /// 參數表服務
        /// </summary>
        private readonly IParameterService ParameterService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="shippingOrderRepository">配送訂單儲存庫</param>
        public ShippingOrderService(
            IShippingOrderRepository shippingOrderRepository,
            IParameterService parameterService)
        {
            this.ShippingOrderRepository = shippingOrderRepository;
            this.ParameterService = parameterService;
        }

        /// <summary>
        /// 新增配送訂單
        /// </summary>
        /// <param name="orderId">訂單編號</param>
        public void InsertShippingOrder(string orderId)
        {
            ShippingOrder model = new ShippingOrder()
            {
                Id = this.GetPromotionSequence(),
                OrderId = orderId,
                Status = 1,
                CteatedAt = DateTime.Now
            };

            ShippingOrderQueryBuilder builder = new ShippingOrderQueryBuilder();
            string sql = builder.GetInsertShippingOrderSql();

            this.ShippingOrderRepository.Execute(sql, model);
        }

        /// <summary>
        /// 取得配送訂單清單
        /// </summary>
        /// <param name="memberId">會員編號</param>
        /// <returns>配送訂單清單</returns>
        public List<ShippingOrder> GetShippingOrders(int memberId)
        {
            ShippingOrderQueryBuilder builder = new ShippingOrderQueryBuilder();
            string sql = builder.GetShippingOrdersSql();

            return this.ShippingOrderRepository.Query<ShippingOrder>(sql, new { MemberId = memberId }).ToList();
        }

        /// <summary>
        /// 取得 B2B 促案編號號
        /// </summary>
        /// <returns>促案編號號</returns>
        private string GetPromotionSequence()
        {
            string initValue = DateTime.Now.ToString("yyyyMMdd00000");

            long sequence = this.ParameterService
                                .GetSequence("ShippingOrder", long.Parse(initValue));
            return $"SO{sequence}";
        }
    }
}
