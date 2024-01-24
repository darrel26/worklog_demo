using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worklog_demo.Models;
using worklog_demo.Models.DTO.Flattening;
using worklog_demo.Models.DTO.Requests;
using worklog_demo.Models.DTO.Responses;

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
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new WorklogDTO()
                    {
                        LogTitle = reader.GetString("LogTitle"),
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
            return list;
        }

        public bool CreateWorklog(WorklogRequest worklogData)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tb_worklog (`logStart`, `logEnd`, `logDate`, `logDetails`, `userID`, `projectID`, `logTitle`) VALUES(@logStart, @logEnd, @logDate, @logDetails, @userId, @projectId, @logTitle)", conn);
                    cmd.Parameters.AddWithValue("@logStart", worklogData.LogStart);
                    cmd.Parameters.AddWithValue("@logEnd", worklogData.LogEnd);
                    cmd.Parameters.AddWithValue("@logDate", worklogData.LogDate);
                    cmd.Parameters.AddWithValue("@logDetails", worklogData.LogDetails);
                    cmd.Parameters.AddWithValue("@userId", worklogData.UserId);
                    cmd.Parameters.AddWithValue("@projectId", worklogData.ProjectId);
                    cmd.Parameters.AddWithValue("@logTitle", worklogData.LogTitle);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }
    }
}
