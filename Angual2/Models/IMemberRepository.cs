using System.Collections.Generic;

namespace Angual2.Models
{
    public interface IMemberRepository
    {
        List<Member> GetList();
        void Add(string name);
    }
}