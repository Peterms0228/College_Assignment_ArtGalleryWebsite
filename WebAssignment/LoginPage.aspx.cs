using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAssignment
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.Title = "Mr.P Artwork Gallery";
        }
        public void popUpMsg(string message)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();

            SqlCommand check_User = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE ([UserName] = @username) AND ([UserPassw] = @userpassw)", con);
            check_User.Parameters.AddWithValue("@username", txtUserName.Text);
            check_User.Parameters.AddWithValue("@userpassw", txtUserPassw.Text);

            int UserExist = (int)check_User.ExecuteScalar();
            if (UserExist > 0)
            {
                popUpMsg("Login Successfully!");

                string username = txtUserName.Text.Trim();
                Session["username"] = username;

                string getID = "Select UserId from Users where username='" + Session["username"] + "'";
                SqlCommand cmdGetUserId = new SqlCommand(getID, con);
                SqlDataReader dt = cmdGetUserId.ExecuteReader();
                var UserID = "";
                while (dt.Read())
                {
                    UserID = dt.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                              // Do somthing with this rows string, for example to put them in to a list
                }
                dt.Close();

                string userid = UserID;
                Session["userid"] = userid;

                Response.Redirect("Home.aspx");
            }
            else
            {
                popUpMsg("Incorrect user name or password!");
            }
            con.Close();

        }

        protected void btnCancelLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}