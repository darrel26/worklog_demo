using MySql.Data.MySqlClient;
using System.Collections.Generic;
using worklog_demo.Models;

namespace worklog_demo.Data
{
    public class ProjectContext
    {
        public string ConnectionString { get; set; }

        public ProjectContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<TbProject> GetAllProject()
        {
            List<TbProject> list = new List<TbProject>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_projects", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TbProject()
                        {
                            ProjectId = reader.GetInt32("projectID"),
                            ProjectName = reader.GetString("projectName")
                        });
                    }
                }
            }
            return list;
        }
    }
}
