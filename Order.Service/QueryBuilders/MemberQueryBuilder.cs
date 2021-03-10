using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    /// <summary>
    /// 會員 QueryBuilder
    /// </summary>
    public class MemberQueryBuilder
    {
        public MemberQueryBuilder()
        { }

        /// <summary>
        /// 取得確認登入資訊 Sql
        /// </summary>
        /// <returns>Sql</returns>
        public string GetCheckMemberLoginSql()
        {
            return @"
                    SELECT
                            member_id       AS Id   ,
                            member_phone    AS Phone,
                            member_password AS Password
                    FROM
                            member
                    WHERE
                            member_phone    = @Phone
                    AND     member_password = @Password";
        }
    }
}
