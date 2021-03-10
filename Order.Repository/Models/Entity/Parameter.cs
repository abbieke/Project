using System;

namespace Project.Repository.Models
{
    /// <summary>
    /// 參數表
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 參數鍵
        /// </summary>
        public string ParameterKey { get; set; }

        /// <summary>
        /// 參數值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}