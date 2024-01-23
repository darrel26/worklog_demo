using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Models.DTO.Requests;
using worklog_demo.Models.DTO.Responses;

namespace worklog_demo.Data
{
    public class LoginContext
    {
        public string ConnectionString { get; set; }

        public LoginContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public UsersResponse Login(LoginRequest login)
        {
            UsersResponse userLogin = new UsersResponse();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users WHERE username = @username AND password = @password", conn);
                cmd.Parameters.AddWithValue("@username", login.username);
                cmd.Parameters.AddWithValue("@password", login.password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userLogin = new UsersResponse()
                        {
                            UserId = reader.GetInt32("UserId"),
                            Username = reader.GetString("Username"),
                            FullName = reader.GetString("Fullname")
                        };
                    }
                }
                return userLogin;
            }
        }
    }
}
