using Project.Service.Models;

namespace Project.Service
{
    public interface IMemberService
    {
        /// <summary>
        /// 會員登入
        /// </summary>
        /// <param name="login">登入 ViewModel</param>
        /// <returns>帳密是否正確</returns>
        (bool, int?) Login(LoginViewModel login);
    }
}