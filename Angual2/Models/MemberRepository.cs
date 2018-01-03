using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Angual2.Models
{
    public class MemberRepository : IMemberRepository
    {
        private SqlConnection con;

        public MemberRepository()
        {
            con = new SqlConnection(
               "Server=(localdb)\\MSSQLLocalDB;database=MemberMgmt;Integrated Security=true;"
             );
        }

        public List<Member> GetList()
        {
            List<Member> list = new List<Member>();
            con.Open();
            string sql = "Select * from Members";
            SqlCommand com = new SqlCommand(sql, con);

            using (SqlDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    Member mem = new Member();
                    mem.Id = Int32.Parse(reader["Id"].ToString());
                    mem.Name = reader["Name"].ToString();
                    list.Add(mem);
                }
                reader.Close();
            }
            con.Close();
            return list;
        }

        public void Add(String name)
        {
            con.Open();
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "INSERT INTO Members (Name) VALUES (@Name)";
                com.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar);
                com.Parameters["@Name"].Value = name;
                com.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}

