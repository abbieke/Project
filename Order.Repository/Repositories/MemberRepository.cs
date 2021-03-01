using Dapper;
using Project.Repository.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

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
    }
}