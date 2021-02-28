using Project.Repository;

namespace Project.Service
{
    /// <summary>
    /// 會員服務
    /// </summary>
    public class MemberService : IMemberService
    {
        /// <summary>
        /// 會員儲存庫
        /// </summary>
        private readonly IMemberRepository MemberRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        public MemberService()
        {
            this.MemberRepository = new MemberRepository();
        }
    }
}