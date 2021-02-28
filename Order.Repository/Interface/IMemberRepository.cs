using Project.Repository.Models;
using System.Collections.Generic;

namespace Project.Repository
{
    public interface IMemberRepository
    {
        List<Member> SelectMembers(string sql);
    }
}