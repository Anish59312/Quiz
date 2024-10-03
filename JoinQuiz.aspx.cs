using System;
using System.Data.SqlClient;

namespace QuizApp
{
    public partial class JoinQuiz : System.Web.UI.Page
    {
        protected void btnJoinQuiz_Click(object sender, EventArgs e)
        {
            string quizCode = txtQuizCode.Text;
            int count = 0;

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                con.Open();
                string findQuizCode = "SELECT COUNT(*) FROM Quiz WHERE quizId = @quizId";

                using (SqlCommand cmd = new SqlCommand(findQuizCode, con))
                {
                    cmd.Parameters.AddWithValue("@quizId", quizCode);
                    count = (int)cmd.ExecuteScalar();
                }

            }

            if (count > 0)
            {
                Response.Redirect($"TakeQuiz.aspx?code={quizCode}");
            }
            else
            {
                Response.Redirect($"ErrorPage.aspx");
            }
        }
    }
}
