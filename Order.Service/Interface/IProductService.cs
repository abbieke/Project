using Project.Repository.Models;

namespace Project.Service
{
    /// <summary>
    /// 商品服務介面
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 取得商品詳細資料
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <returns>商品詳細資料</returns>
        Product GetProductDetail(int productId);
    }
}