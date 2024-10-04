using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApp
{
    public partial class CreateQuiz : System.Web.UI.Page
    {
        private static List<Question> questions = new List<Question>();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                dt.Columns.Add("QuestionText");
                dt.Columns.Add("Option1");
                dt.Columns.Add("Option2");
                dt.Columns.Add("Option3");
                dt.Columns.Add("Option4");
                dt.Columns.Add("Answer");

                ctlGrid.DataSource = dt;
                ctlGrid.DataBind();
            }
        }

        protected void ctlGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                questions.RemoveAt(index);

                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("QuestionText");
            dt.Columns.Add("Option1");
            dt.Columns.Add("Option2");
            dt.Columns.Add("Option3");
            dt.Columns.Add("Option4");
            dt.Columns.Add("CorrectAnswer");

            foreach (var row in questions)
            {
                DataRow dr = dt.NewRow();
                dr[0] = row.QuestionText;
                dr[1] = row.Option1;
                dr[2] = row.Option2;
                dr[3] = row.Option3;
                dr[4] = row.Option4;
                dr[5] = row.CorrectAnswer;
                dt.Rows.Add(dr);
            }

            ctlGrid.DataSource = dt;
            ctlGrid.DataBind();
        }


        protected void btnAddQuestion_Click(object sender, EventArgs e)
        
        {
            questions.Add(new Question
            { 
                QuestionText = txtQuestion.Text,
                Option1 = txtOption1.Text,
                Option2 = txtOption2.Text,
                Option3 = txtOption3.Text,
                Option4 = txtOption4.Text,
                CorrectAnswer = ddlCorrectAnswer.SelectedValue
            });

            BindGrid();
            ClearForm();
        }

        protected void btnSubmitQuiz_Click(object sender, EventArgs e)
        {
            string quizCode = Guid.NewGuid().ToString().Substring(0, 6);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonQuestions = jsonSerialiser.Serialize(questions);

            string name = ctlQuizName.Text.ToString();

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();

                string insertQuery = "INSERT INTO QUIZ (quizId, name, questions) VALUES (@quizId, @name, @questions)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@quizId", quizCode);
                    cmd.Parameters.AddWithValue("@questions", jsonQuestions);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }

            Response.Write($"Quiz submitted successfully. Your Quiz Code is: {quizCode}");
        }

        private void ClearForm()
        {
            txtQuestion.Text = string.Empty;
            txtOption1.Text = string.Empty;
            txtOption2.Text = string.Empty;
            txtOption3.Text = string.Empty;
            txtOption4.Text = string.Empty;
            ddlCorrectAnswer.SelectedIndex = 0;
        }
    }

    public class Question
    {
        public string QuestionText { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
