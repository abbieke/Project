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

            //conn = new SqlConnection(connString);
        }

        public List<Member> SelectMembers(string sql)
        {
            List<Member> members;
            using (conn = new SqlConnection(connString))
            {
                sql = "SELECT member_id AS Id, member_name AS Name, member_phone AS Phone FROM Member";
                members = conn.Query<Member>(sql).ToList();
            }
            return members;
        }
    }
}