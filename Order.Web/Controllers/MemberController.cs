using Project.Service;
using Project.Service.Models;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    /// <summary>
    /// 會員控制器
    /// </summary>
    public class MemberController : Controller
    {
        /// <summary>
        /// 會員服務
        /// </summary>
        private readonly IMemberService MemberService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="memberService">會員服務</param>
        public MemberController(IMemberService memberService)
        {
            this.MemberService = memberService;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns>登入 ViewModel</returns>
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="login"></param>
        /// <returns>登入結果</returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            (bool isSuccess, int? memberId) = this.MemberService.Login(login);

            if (isSuccess && memberId != null)
            {
                Session["MemberId"] = memberId;

                return this.RedirectToAction(nameof(OrderController.Index), "Order");
            }
            else
            {
                ViewBag.Msg = "登入失敗...";

                return View();
            }
        }
    }
}