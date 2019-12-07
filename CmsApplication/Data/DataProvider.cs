using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace CmsApplication.Data
{
    /// <summary>
    /// Provides data from MySql Database 
    /// </summary>
    public class DataProvider
    {
        /// <summary>
        /// Object that communicates with MySql database via SQL 
        /// </summary>
        MySqlConnection Connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public DataProvider()
        {
            // establish connection to database
            Connection = new MySqlConnection("Server=127.0.0.1;Database=cms;Uid=root");
            Connection.Open();
        }

        /// <summary>
        /// Updates page information
        /// </summary>
        public void UpdatePage(int pageId, string title, string body)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "UPDATE pages SET pagetitle = @title, pagebody = @body, publishdate = NOW() WHERE pageid=@id";
            command.Parameters.AddWithValue("id", pageId);
            command.Parameters.AddWithValue("title", title);
            command.Parameters.AddWithValue("body", body);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Clears all information about pages
        /// </summary>
        public void ClearPages()
        {
            var command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM pages";
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Inserts page information into database
        /// </summary>
        public void InsertPage(string title, string body)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO pages (pagetitle, pagebody, ispublished, publishdate) VALUES (@title, @body, 1, NOW())";
            command.Parameters.AddWithValue("title", title);
            command.Parameters.AddWithValue("body", body);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Delete page information
        /// </summary>        
        public void DeletePage(int pageId)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM pages WHERE pageid = @pageid";
            command.Parameters.AddWithValue("pageid", pageId);            
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns full page information
        /// </summary>
        public PageInfo GetPage(int pageId)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT pageid, pagetitle, pagebody, ispublished, publishdate FROM pages WHERE pageid = @pageid";
            command.Parameters.AddWithValue("pageid", pageId);
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new PageInfo
                {
                    Id = reader.GetInt32(0),
                    Title = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Body = reader.IsDBNull(2) ? null : reader.GetString(2),
                    IsPublished = reader.IsDBNull(3) ? (bool?)null : reader.GetBoolean(3),
                    PublishDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                };
            }

            return null;
        }

        /// <summary>
        /// Returns information about all pages
        /// </summary>        
        public List<PageInfo> GetAllPages()
        {
            var result = new List<PageInfo>();

            var command = Connection.CreateCommand();
            command.CommandText = "SELECT pageid, pagetitle, pagebody, ispublished, publishdate FROM pages";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new PageInfo
                {
                    Id = reader.GetInt32(0),
                    Title = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Body = reader.IsDBNull(2) ? null : reader.GetString(2),
                    IsPublished = reader.IsDBNull(3) ? (bool?)null : reader.GetBoolean(3),
                    PublishDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                });
            }

            return result;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~DataProvider()
        {
            // close database connection
            Connection.Close();
        }
    }
}