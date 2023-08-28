using System;
using System.Data;
using dynamicwebsite; // Update this with your actual namespace
using System.Configuration;

namespace dynamicwebsite
{
    public partial class Articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArticles();
            }
        }

        private void BindArticles()
        {
            // Initialize your DatabaseHelper with the connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Articlesview"].ConnectionString;
            DatabaseHelper dbHelper = new DatabaseHelper(connectionString);

            // Retrieve the list of articles from the database
            DataTable dt = dbHelper.ExecuteQuery("SELECT ArticleId, Title, PublishDate, Content FROM Articles");

            // Bind the data to the Repeater control
            if (dt != null && dt.Rows.Count > 0)
            {
                RepeaterArticles.DataSource = dt;
                RepeaterArticles.DataBind();
            }
        }
    }
}
