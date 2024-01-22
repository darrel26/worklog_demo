using System.Collections.Generic;

using MySql.Data.MySqlClient;
using worklog_demo.Models;

namespace worklog_demo.Data
{
    public class UserContext
    {
        public string ConnectionString { get; set; }

        public UserContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<TbUser> GetAllUsers()
        {
            List<TbUser> list = new List<TbUser>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TbUser()
                        {
                            UserId = reader.GetInt32("UserId"),
                            Username = reader.GetString("Username"),
                            Password = reader.GetString("Password"),
                            FullName = reader.GetString("Fullname")
                        });
                    }
                }
            }
            return list;
        }
    }
}
