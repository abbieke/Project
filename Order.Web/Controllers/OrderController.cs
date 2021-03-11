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
        /// <param name="orderService">訂單服務</param>
        public OrderController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }

        /// <summary>
        /// 訂單清單
        /// </summary>
        /// <returns>訂單清單列表</returns>
        public ActionResult Index()
        {
            if (Session["MemberId"] == null || string.IsNullOrWhiteSpace(Session["MemberId"].ToString()))
            {
                return this.RedirectToAction(nameof(MemberController.Login), "Member");
            }

            int memberId = (int)Session["MemberId"];

            List<OrderViewModel> viewModel = this.OrderService.GetMemberOrderList(memberId);

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

            return this.RedirectToAction(nameof(OrderController.Index));
        }
    }
}