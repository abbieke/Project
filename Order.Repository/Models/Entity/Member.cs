namespace Project.Repository.Models
{
    /// <summary>
    /// 會員
    /// </summary>
    public class Member
    {
        /// <summary>
        /// 會員編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 會員姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 會員手機號碼
        /// </summary>
        public string Phone { get; set; }
    }
}