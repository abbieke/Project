using Project.Repository;
using Project.Repository.Models;
using System;
using System.Linq;
using System.Threading;
using static System.Math;

namespace Project.Service
{
    /// <summary>
    /// 參數表服務
    /// </summary>
    public class ParameterService : IParameterService
    {
        /// <summary>
        /// 參數表儲存庫
        /// </summary>
        private readonly IParameterRepository ParameterRepository;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="parameterRepository">參數表儲存庫</param>
        public ParameterService(
            IParameterRepository parameterRepository)
        {
            this.ParameterRepository = parameterRepository;
        }

        /// <summary>
        /// 取得序列號
        /// </summary>
        /// <param name="key">序列號識別鍵</param>
        /// <param name="value">序列號預設基準值如 20180000，且目前的序列號小於該值即回傳20180001，如果目前序列號大於預設基準值則回傳目前序列號加1</param>
        /// <param name="retry">取號失敗重試次數，最多重取20次</param>
        /// <param name="retryInterval">取號失敗重試間格時間(millisecond)，間格時間最多10秒</param>
        /// <returns>序列號</returns>
        public long GetSequence(string key, long value, int retry = 5, int retryInterval = 300)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            retry = Min(retry, 20);
            retryInterval = Min(retryInterval, 10000);
            long returnValue;

            ParameterQueryBuilder builder = new ParameterQueryBuilder();

            // 取號並更新
            do
            {
                string selectSql = builder.GetParametersSql();

                Parameter parameter = this.ParameterRepository
                                          .Query<Parameter>(selectSql, new { Key = key })
                                          .FirstOrDefault();

                // 未有序列號識別鍵，新增
                if (parameter == null)
                {
                    returnValue = ++value;
                    parameter = new Parameter
                    {
                        ParameterKey = key,
                        Value = returnValue.ToString(),
                        UpdatedAt = DateTime.Now
                    };

                    string insertSql = builder.GetInsertParameterSql();
                    this.ParameterRepository.Execute(insertSql, parameter);
                    retry = 0;
                    continue;
                }

                long.TryParse(parameter.Value, out long currentValue);
                returnValue = (value > currentValue ? value : currentValue) + 1;
                parameter.Value = returnValue.ToString();
                string updateSql = builder.GetUpdateParameterSql();
                int updateCount = this.ParameterRepository.Execute(updateSql, parameter);
                if (updateCount == 1)
                {
                    retry = 0;
                }

                if (retry > 0)
                {
                    Thread.Sleep(retryInterval);
                    retry--;
                }
            }
            while (retry > 0);

            return returnValue;
        }
    }
}