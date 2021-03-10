namespace Project.Service
{
    /// <summary>
    /// 參數表服務介面
    /// </summary>
    public interface IParameterService
    {
        /// <summary>
        /// 取得序列號
        /// </summary>
        /// <param name="key">序列號識別鍵</param>
        /// <param name="value">序列號預設基準值如 20180000，且目前的序列號小於該值即回傳20180001，如果目前序列號大於預設基準值則回傳目前序列號加1</param>
        /// <param name="retry">取號失敗重試次數，最多重取20次</param>
        /// <param name="retryInterval">取號失敗重試間格時間(millisecond)，間格時間最多10秒</param>
        /// <returns>序列號</returns>
        long GetSequence(string key, long value, int retry = 5, int retryInterval = 300);
    }
}