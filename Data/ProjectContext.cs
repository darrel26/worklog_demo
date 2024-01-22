using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<ProjectItem> GetAllProject()
        {
            List<ProjectItem> list = new List<ProjectItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_projects", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProjectItem()
                        {
                            projectID = reader.GetInt32("projectID"),
                            projectName = reader.GetString("projectName")
                        });
                    }
                }
            }
            return list;
        }
    }
}
