using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<UserItem> GetAllUsers()
        {
            List<UserItem> list = new List<UserItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserItem()
                        {
                            userID = reader.GetInt32("userID"),
                            fullName = reader.GetString("fullName"),
                            username = reader.GetString("username"),
                            password = reader.GetString("password")
                        });
                    }
                }
            }
            return list;
        }
    }
}
