using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;

namespace QuizApp
{
    public partial class QuizResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadResults();
            }
        }

        private void LoadResults()
        {
            string score = Request.QueryString["score"];
            string questionCount = Request.QueryString["question_count"];
            lblScore.Text = "Your Score: " + score +"/" + questionCount ;
            double percentage = Math.Round( (double.Parse(score) / double.Parse(questionCount)) * 100 , 2);
            lblPercentage.Text = "Score in Percentage " + percentage.ToString() + "%";
            lblisPassed.Text = (percentage >= 75.00) ? "Passed" : "Failed";


            //using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            //{
            //    con.Open();

            //    string selectQuiz = "SELECT questions FROM Quiz WHERE quizId = @quizId";

            //    using (SqlCommand cmd = new SqlCommand(selectQuiz, con))
            //    {
            //        cmd.Parameters.AddWithValue("@quizId", quizCode);
            //        SqlDataReader reader;
            //        using (reader = cmd.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                int columnCount = reader.FieldCount;
            //                object[] rowValues = new object[columnCount];
            //                reader.GetValues(rowValues);
            //                string jsonQuestions = (string)rowValues[0];
            //                var jsonSerialiser = new JavaScriptSerializer();
            //                try
            //                {
            //                    questions = jsonSerialiser.Deserialize<List<Question>>(jsonQuestions);
            //                }
            //                catch
            //                {
            //                    Response.Redirect("ErrorPage.aspx");
            //                }
            //            }
            //        }
            //    }
            //}


            //var correctAnswers = new List<Question>
            //{
            //    new Question { QuestionText = "What is 2+2?", CorrectAnswer = "4" },
            //    new Question { QuestionText = "Capital of France?", CorrectAnswer = "Paris" }
            //};
            //rptCorrectAnswers.DataSource = correctAnswers;
            //rptCorrectAnswers.DataBind();
        }
    }
}
