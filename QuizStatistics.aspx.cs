using System;
using System.Collections.Generic;

namespace QuizApp
{
    public partial class QuizStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }

        private void LoadStatistics()
        {
            // Fetch the quiz statistics from the database
            string quizCode = Request.QueryString["code"];
            lblQuizName.Text = "Statistics for Quiz: " + quizCode;

            // Example statistics (replace with DB data)
            lblTotalParticipants.Text = "Total Participants: 10";
            lblAverageMarks.Text = "Average Marks: 7.5";

            // Example participant data (replace with DB data)
            var participants = new List<Participant>
            {
                new Participant { ParticipantName = "John Doe", Score = 8 },
                new Participant { ParticipantName = "Jane Smith", Score = 7 }
            };

            gvParticipants.DataSource = participants;
            gvParticipants.DataBind();
        }
    }

    public class Participant
    {
        public string ParticipantName { get; set; }
        public int Score { get; set; }
    }
}
