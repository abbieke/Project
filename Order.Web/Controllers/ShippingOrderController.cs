using Project.Repository.Models;
using Project.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class ShippingOrderController : Controller
    {
        /// <summary>
        /// 訂單服務
        /// </summary>
        private readonly IShippingOrderService ShippingOrderService;

        /// <summary>
        /// 建構子
        /// </summary>
        public ShippingOrderController(IShippingOrderService shippingOrderService)
        {
            this.ShippingOrderService = shippingOrderService;
        }

        // GET: ShippingOrder
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