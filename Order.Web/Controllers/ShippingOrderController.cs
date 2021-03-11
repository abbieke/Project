using Project.Repository.Models;
using Project.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    /// <summary>
    /// 配送訂單控制器
    /// </summary>
    public class ShippingOrderController : Controller
    {
        /// <summary>
        /// 配送訂單服務
        /// </summary>
        private readonly IShippingOrderService ShippingOrderService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="shippingOrderService">配送訂單服務</param>
        public ShippingOrderController(IShippingOrderService shippingOrderService)
        {
            this.ShippingOrderService = shippingOrderService;
        }

        /// <summary>
        /// 配送訂單清單
        /// </summary>
        /// <returns>清單</returns>
        public ActionResult Index()
        {
            if (Session["MemberId"] == null || string.IsNullOrWhiteSpace(Session["MemberId"].ToString()))
            {
                return this.RedirectToAction(nameof(MemberController.Login), "Member");
            }

            List<ShippingOrder> list = this.ShippingOrderService.GetShippingOrders((int)Session["MemberId"]);

            return View(list);
        }
    }
}