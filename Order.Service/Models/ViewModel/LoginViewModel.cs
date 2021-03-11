using System.ComponentModel.DataAnnotations;

namespace Project.Service.Models
{
    /// <summary>
    /// 登入 ViewModel
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// 會員手機號碼
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 會員密碼
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "請輸入密碼")]
        public string Password { get; set; }
    }
}