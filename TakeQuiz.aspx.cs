using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace QuizApp
{
    public partial class TakeQuiz : System.Web.UI.Page
    {
        public List<Question> questions = new List<Question>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadQuiz();
        }

        private void LoadQuiz()
        {
            // Fetch the quiz from the database using the query string code
            string quizCode = Request.QueryString["code"];
            lblQuizName.Text = "Quiz Code: " + quizCode;

            //function to get stored quiz by code
            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();

                string selectQuiz = "SELECT questions FROM Quiz WHERE quizId = @quizId";

                using(SqlCommand cmd = new SqlCommand(selectQuiz, con))
                {
                    cmd.Parameters.AddWithValue("@quizId", quizCode);
                    SqlDataReader reader;
                    using (reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            int columnCount = reader.FieldCount;
                            object[] rowValues = new object[columnCount];
                            reader.GetValues(rowValues);
                            string jsonQuestions = (string)rowValues[0];
                            var jsonSerialiser = new JavaScriptSerializer();
                            try
                            {
                                questions = jsonSerialiser.Deserialize<List<Question>>(jsonQuestions);
                            }
                            catch
                            {
                                Response.Redirect("ErrorPage.aspx");
                            }
                        }
                    }
                }
            }

            if (!IsPostBack)
            {
                rptQuestions.DataSource = questions;
                rptQuestions.DataBind();
            }
        }

        protected void btnSubmitQuiz_Click(object sender, EventArgs e)
        {
            int score = 0;
            var userAnswers = new List<string>();

            foreach (RepeaterItem item in rptQuestions.Items)
            {
                Debug.WriteLine(item.ItemIndex);

                var rbl = (RadioButtonList)item.FindControl("rblOptions");
                userAnswers.Add(rbl.SelectedValue);

                string correctAnswer = questions[item.ItemIndex].CorrectAnswer; 
                if (rbl.SelectedValue == correctAnswer)
                {
                    score++;
                }
            }

            // Save user submission to the database and calculate score
            Response.Redirect($"QuizResults.aspx?score={score}&question_count={rptQuestions.Items.Count}");
        }

        protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var question = (Question)e.Item.DataItem;

                RadioButtonList rblOptions = (RadioButtonList)e.Item.FindControl("rblOptions");
                rblOptions.Items.Add(new ListItem(question.Option1, "Option 1"));
                rblOptions.Items.Add(new ListItem(question.Option2, "Option 2"));
                rblOptions.Items.Add(new ListItem(question.Option3, "Option 3"));
                rblOptions.Items.Add(new ListItem(question.Option4, "Option 4"));
            }
        }
    }
}
