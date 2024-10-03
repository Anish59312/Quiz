using System;
using System.Collections.Generic;

namespace QuizApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCreatedQuizzes();
            }
        }

        protected void btnCreateQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateQuiz.aspx");
        }

        protected void btnJoinQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("JoinQuiz.aspx");
        }

        protected void btnDeleteQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
            if ((bool)Session["AdminLoggedIn"] == true)
            {
                Response.Redirect("DeleteQuiz.aspx");
            }
        }

        private void LoadCreatedQuizzes()
        {
            gvCreatedQuizzes.DataSource = new List<Quiz>
            {
                new Quiz { QuizName = "Sample Quiz 1" }
            };
            gvCreatedQuizzes.DataBind();
        }
    }

    public class Quiz
    {
        public string QuizName { get; set; }
    }
}
