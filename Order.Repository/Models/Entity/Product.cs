namespace Project.Repository.Models
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        public decimal Cost { get; set; }
    }
}