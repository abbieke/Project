using Project.Service;
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

        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
    }
}