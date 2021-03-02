using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Project.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service.Test
{
    [TestClass]
    public class OrderServiceTest
    {
        /// <summary>
        /// 訂單儲存庫
        /// </summary>
        private IOrderRepository OrderRepository;

        /// <summary>
        /// TestInit
        /// </summary>
        public OrderServiceTest()
        {
            this.OrderRepository = Substitute.For<IOrderRepository>();
        }

        /// <summary>
        /// 取得會員訂單清單_取得成功
        /// </summary>
        [TestMethod]
        public void GetMemberOrderList_取得會員訂單清單_取得成功()
        {
            var service = GetService();
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

            List<OrderViewModel> actualModel = service.GetMemberOrderList();

            Assert.AreEqual(model.First().Id, actualModel.First().Id);
        }

        private OrderService GetService()
        {
            return new OrderService(this.OrderRepository);
        }
    }
}