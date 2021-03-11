using Project.Repository;
using Project.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="parameterService">參數表服務</param>
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
                Id = this.GetShippingOrderSequence(),
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
        /// 取得配送編號
        /// </summary>
        /// <returns>編號</returns>
        private string GetShippingOrderSequence()
        {
            string initValue = DateTime.Now.ToString("yyyyMMdd00000");

            long sequence = this.ParameterService
                                .GetSequence("ShippingOrder", long.Parse(initValue));
            return $"SO{sequence}";
        }
    }
}