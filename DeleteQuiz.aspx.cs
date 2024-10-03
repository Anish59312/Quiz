using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApp
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminLoggedIn"] == null || (bool)Session["AdminLoggedIn"] != true)
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        protected void btnSubmitDelete_Click(object sender, EventArgs e)
        {
            string quizId = txtQuizId.Text;

            if (!string.IsNullOrEmpty(quizId))
            {

                bool isDeleted = DeleteQuizFromDatabase(quizId);

                if (isDeleted)
                {
                    lbl2QuizId.Text = "Quiz deleted successfully.";
                }
                else
                {
                    lbl2QuizId.Text = "Error: Quiz deletion failed.";
                }

                ClearForm();
            }
        }
        private void ClearForm()
        {
            txtQuizId.Text = "";
        }

        //running the code is still remaining
        private bool DeleteQuizFromDatabase(string quizId)
        {

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True"))
            {
                string deleteQuery = "DELETE FROM Quiz WHERE quizId = @quizId";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@quizId", quizId);

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

                return true;
        }
    }
}