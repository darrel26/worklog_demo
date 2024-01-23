using MySql.Data.MySqlClient;
using System.Collections.Generic;
using worklog_demo.Models.DTO.Flattening;

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

        public List<ProjectDTO> GetAllProject()
        {
            List<ProjectDTO> list = new List<ProjectDTO>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_projects", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProjectDTO()
                        {
                            ProjectId = reader.GetInt32("projectID"),
                            ProjectName = reader.GetString("projectName")
                        });
                    }
                }
            }
            return list;
        }

        public List<ProjectDTO> GetProjectForSpecificUser(int userId)
        {
            List<ProjectDTO> list = new List<ProjectDTO>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT tbup.projectID, tbp.projectName FROM tb_users_projects tbup LEFT JOIN tb_projects tbp ON tbup.projectID = tbp.projectID WHERE tbup.userID = @userId;", conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ProjectDTO()
                        {
                            ProjectId = reader.GetInt32("ProjectId"),
                            ProjectName = reader.GetString("ProjectName")
                        });
                    }
                }
                return list;
            }
        }

    }
}
