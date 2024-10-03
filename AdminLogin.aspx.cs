using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuizApp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }

            //ViewState["goBackTo"] = Request.UrlReferrer.ToString();
        }

        protected void btnLogin_click(object sender, EventArgs e)
        {
            string username = tbUserName.Text;
            string password = tbPassword.Text;

            if(username == "admin" && password == "admin@314")
            {
                Session["AdminLoggedIn"] = true;

                Response.Redirect("DeleteQuiz.aspx");
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}