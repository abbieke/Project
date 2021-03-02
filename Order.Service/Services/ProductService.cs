using Project.Repository;
using Project.Repository.Models;

namespace Project.Service
{
    /// <summary>
    /// 商品服務
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// 商品儲存庫
        /// </summary>
        private readonly IProductRepository ProductRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="productRepository">商品儲存庫</param>
        public ProductService(IProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }

        /// <summary>
        /// 取得商品詳細資料
        /// </summary>
        /// <param name="productId">商品編號</param>
        /// <returns>商品詳細資料</returns>
        public Product GetProductDetail(int productId)
        {
            ProductQueryBuilder builder = new ProductQueryBuilder();
            string sql = builder.GetProductSql();

            return this.ProductRepository.Query<Product>(sql, new { Id = productId });
        }
    }
}