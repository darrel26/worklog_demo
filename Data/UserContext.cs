using System.Collections.Generic;

using MySql.Data.MySqlClient;
using worklog_demo.Models;
using worklog_demo.Models.DTO.Responses;

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

        public List<UsersResponse> GetAllUsers()
        {
            List<UsersResponse> list = new List<UsersResponse>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UsersResponse()
                        {
                            UserId = reader.GetInt32("UserId"),
                            Username = reader.GetString("Username"),
                            FullName = reader.GetString("Fullname")
                        });
                    }
                }
            }
            return list;
        }

        public UsersResponse GetSpecificUser(int id)
        {
            UsersResponse user = new UsersResponse();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users WHERE userId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user = new UsersResponse()
                        {
                            UserId = reader.GetInt32("UserId"),
                            Username = reader.GetString("Username"),
                            FullName = reader.GetString("Fullname"),
                        };
                    }
                }
                return user;
            }
        }

        public UserDetailResponse GetUserDetail(int id)
        {
            UserDetailResponse userDetail = new UserDetailResponse();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users WHERE userId = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userDetail = new UserDetailResponse()
                        {
                            UserId = reader.GetInt32("UserId"),
                            Username = reader.GetString("Username"),
                            FullName = reader.GetString("Fullname")
                        };
                    }
                }
                return userDetail;
            }
        }
    }
}
