﻿using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Project.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private static string connString;
        private SqlConnection conn;

        public MemberRepository()
        {
            if (string.IsNullOrEmpty(connString))
            {
                connString = ConfigurationManager.ConnectionStrings["Order"].ConnectionString;
            }
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <typeparam name="TModel">查詢回傳類型</typeparam>
        /// <param name="sql">查詢語法</param>
        /// <param name="param">參數物件</param>
        /// <returns>結果</returns>
        public IEnumerable<TModel> Query<TModel>(string sql, object param = null)
        {
            using (conn = new SqlConnection(connString))
            {
                return conn.Query<TModel>(sql, param);
            }
        }
    }
}