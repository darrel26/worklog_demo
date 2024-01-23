using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Models;
using worklog_demo.Models.DTO.Flattening;

namespace worklog_demo.Data
{
    public class WorklogContext
    {
        public string ConnectionString { get; set; }

        public WorklogContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<WorklogDTO> GetWorklogsByUserId(int id)
        {
            List<WorklogDTO> list = new List<WorklogDTO>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"
                    SELECT w.*, p.ProjectName
                    FROM tb_worklog w
                    JOIN tb_projects p ON w.ProjectId = p.ProjectId
                    WHERE w.UserId = @userId
                    ORDER BY w.logDate ASC", conn
                );
                cmd.Parameters.AddWithValue("@userId", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new WorklogDTO()
                        {
                            LogId = reader.GetInt32("LogId"),
                            LogStart = reader.GetTimeSpan("LogStart"),
                            LogEnd = reader.GetTimeSpan("LogEnd"),
                            LogDate = reader.GetDateTime("LogDate"),
                            LogDetails = reader.GetString("LogDetails"),
                            UserId = reader.GetInt32("UserId"),
                            Project = new ProjectDTO()
                            {
                                ProjectId = reader.GetInt32("ProjectId"),
                                ProjectName = reader.GetString("ProjectName")
                            }
                        });
                    }
                }
            }
            return list;
        }
    }
}
