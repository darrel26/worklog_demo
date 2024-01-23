using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Models;

namespace worklog_demo.Data
{
    public class WorklogsContext
    {
        public string ConnectionString { get; set; }

        public WorklogsContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<TbWorklog> GetWorklogsByUserId(int id)
        {
            List<TbWorklog> list = new List<TbWorklog>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_worklog WHERE userId = @userId", conn);
                cmd.Parameters.AddWithValue("@userId", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TbWorklog()
                        {
                            LogId = reader.GetInt32("LogId"),
                            LogStart = reader.GetTimeSpan("LogStart"),
                            LogEnd = reader.GetTimeSpan("LogEnd"),
                            LogDate = reader.GetDateTime("LogDate"),
                            LogDetails = reader.GetString("LogDetails"),
                            UserId = reader.GetInt32("UserId"),
                            ProjectId = reader.GetInt32("ProjectId")
                        });
                    }
                }
            }
            return list;
        }
    }
}
