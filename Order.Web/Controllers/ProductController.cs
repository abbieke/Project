using Project.Repository.Models;
using Project.Service;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    /// <summary>
    ///商品控制器
    /// </summary>
    public class ProductController : Controller
    {
        /// <summary>
        /// 商品服務
        /// </summary>
        private readonly IProductService ProductService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="productService">商品服務</param>
        public ProductController(IProductService productService)
        {
            this.ProductService = productService;
        }

        /// <summary>
        /// 商品詳細資料
        /// </summary>
        /// <param name="id">商品編號</param>
        /// <returns>商品資訊</returns>
        public ActionResult Detail(int id)
        {
            Product product = this.ProductService.GetProductDetail(id);
            return View(product);
        }
    }
}