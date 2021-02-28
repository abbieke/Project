using Project.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    /// <summary>
    /// 訂單控制器
    /// </summary>
    public class OrderController : Controller
    {
        /// <summary>
        /// 訂單服務
        /// </summary>
        private readonly IOrderService OrderService;

        /// <summary>
        /// 建構子
        /// </summary>
        public OrderController()
        {
            this.OrderService = new OrderService();
        }

        /// <summary>
        /// 訂單清單
        /// </summary>
        /// <returns>訂單清單列表</returns>
        public ActionResult Index()
        {
            List<OrderViewModel> viewModel = this.OrderService.GetMemberOrderList();

            return View(viewModel);
        }

        /// <summary>
        /// 更新訂單狀態
        /// </summary>
        /// <param name="viewModel">訂單ViewModel</param>
        /// <returns>訂單清單列表</returns>
        [HttpPost]
        public ActionResult Index(List<OrderViewModel> viewModel)
        {
            if (viewModel != null)
            {
                this.OrderService.UpdateOrderStatus(viewModel);
            }

            return this.RedirectToAction("Index", "Order");
        }
    }
}