using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Project.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service.Test
{
    /// <summary>
    /// 訂單服務測試
    /// </summary>
    [TestClass]
    public class OrderServiceTest
    {
        /// <summary>
        /// 訂單儲存庫
        /// </summary>
        private IOrderRepository OrderRepository;

        /// <summary>
        /// 參數表服務
        /// </summary>
        private IShippingOrderService ShippingOrderService;

        /// <summary>
        /// TestInit
        /// </summary>
        public OrderServiceTest()
        {
            this.OrderRepository = Substitute.For<IOrderRepository>();
            this.ShippingOrderService = Substitute.For<IShippingOrderService>();
        }

        /// <summary>
        /// 取得會員訂單清單_取得成功
        /// </summary>
        [TestMethod]
        public void GetMemberOrderList_取得會員訂單清單_取得成功()
        {
            OrderService service = this.GetService();
            int memberId = 1;

            List<OrderViewModel> model = new List<OrderViewModel>()
            {
                new OrderViewModel()
                {
                    Id = "20210227001",
                    MemberId = 1,
                    ProductId = 1,
                    OrderStatus = OrderStatusEnum.PaymentCompleted,
                    Cost = 60,
                    Count = 1,
                    Price = 80
                }
            };

            this.OrderRepository.Query<OrderViewModel>(Arg.Any<string>(), Arg.Any<object>()).Returns(model);

            List<OrderViewModel> actualModel = service.GetMemberOrderList(memberId);

            Assert.AreEqual(model.First().Id, actualModel.First().Id);
        }

        /// <summary>
        /// 測試服務實體
        /// </summary>
        /// <returns>服務實體</returns>
        private OrderService GetService()
        {
            return new OrderService(
                this.OrderRepository,
                this.ShippingOrderService);
        }
    }
}