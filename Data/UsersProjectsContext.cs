using AutoMapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Models;

namespace worklog_demo.Data
{
    public class UsersProjectsContext
    {

        public readonly IMapper _mapper;
        public string ConnectionString { get; set; }

        public UsersProjectsContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<TbUsersProject> GetProjectById(int id)
        {
            List<TbUsersProject> list = new List<TbUsersProject>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_users_projects WHERE userId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TbUsersProject()
                        {
                            ProjectId = reader.GetInt32("ProjectID"),
                            UserId = reader.GetInt32("UserId"),
                        });
                    }
                }
            }
            return list;
        }
    }
}
