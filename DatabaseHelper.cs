using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace dynamicwebsite
{
    public class DatabaseHelper
    {

        
        
        private string connectionString; // Your database connection string

        public DatabaseHelper(string connectionString)
        {
            connectionString = ConfigurationManager.ConnectionStrings["Articlesview"].ConnectionString;
            this.connectionString = connectionString;
        }

        public int ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
                connection.Close();
            }
        }

        // Method to retrieve a list of articles from the "Articles" table
        public List<Articles> GetArticles()
        {
            List<Articles> articles = new List<Articles>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT ArticleId, Title, Content, PublishDate FROM Articles";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create an Article object and populate it with data from the database
                            Articles article = new Articles
                            {
                                ArticleId = (int)reader["ArticleId"],
                                Title = reader["Title"].ToString(),
                                Content = reader["Content"].ToString(),
                                PublishDate = (DateTime)reader["PublishDate"]
                            };

                            // Add the article to the list
                            articles.Add(article);
                        }
                    }
                }
            }

            return articles;
        }

        // Add more methods for database operations as needed
    }
}
