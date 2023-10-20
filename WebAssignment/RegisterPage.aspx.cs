using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WebAssignment
{
    public partial class RegisterPage : System.Web.UI.Page
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

        protected void btnUserRegs_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();

            string strInsert = "Insert Into Users (UserName, UserPassw, UserImg, UserEmail, UserPhone, UserAddress) Values (@uname, @upassw, @uimg, @uemail, @uph, @uad)";
            SqlCommand cmdInsert; //cmdCount;

            byte[] userImg;
            using (BinaryReader br = new BinaryReader(fuUserPic.PostedFile.InputStream))
            {
                userImg = br.ReadBytes(fuUserPic.PostedFile.ContentLength);
            }

            string userName, userPassw, userEmail, userPhone, userAddress;

            userName = txtUserName.Text;
            userPassw = txtUserPassw.Text;
            userEmail = txtUserEmail.Text;
            userPhone = txtUserPhone.Text;
            userAddress = txtUserAddr.Text;

            if (userImg != null && userImg.Length > 0)
            {
                
            }
            else
            {
                //string message = "User Image Cannot Be Empty. Please Select an image!";
                var dir = Server.MapPath("~/Images/noImg.jpg");
                byte[] bytes = System.IO.File.ReadAllBytes(dir);
                userImg = bytes;

            }

            SqlCommand check_User = new SqlCommand("SELECT COUNT(*) FROM [Users] WHERE ([UserName] = @username)", con);
            check_User.Parameters.AddWithValue("@username", userName);

            int UserExist = (int)check_User.ExecuteScalar();
            if (!txtUserPassw.Text.Equals(txtUserPasswConf.Text))
            {
                msgPasswUnmatch.Text = "Password is unmatch!";
                if (UserExist > 0)
                {
                    msgExistedUser.Text = "User name existed! Try another.";
                }
                else
                {
                    msgExistedUser.Text = "";
                }

            }
            else if (UserExist > 0)
            {
                msgExistedUser.Text = "User name existed! Try another.";
                if (!txtUserPassw.Text.Equals(txtUserPasswConf.Text))
                {
                    msgPasswUnmatch.Text = "Password is unmatch!";
                }
                else
                {
                    msgPasswUnmatch.Text = "";
                }

            }
            else
            {
                cmdInsert = new SqlCommand(strInsert, con);

                cmdInsert.Parameters.AddWithValue("@uname", userName);
                cmdInsert.Parameters.AddWithValue("@upassw", userPassw);
                cmdInsert.Parameters.AddWithValue("@uimg", userImg);
                cmdInsert.Parameters.AddWithValue("@uemail", userEmail);
                cmdInsert.Parameters.AddWithValue("@uph", userPhone);
                cmdInsert.Parameters.AddWithValue("@uad", userAddress);
                int intInsertStatus = cmdInsert.ExecuteNonQuery();

                if (intInsertStatus > 0)
                {
                    popUpMsg("Register Successfully.");
                    hlToLoginPage.Visible = true;
                }
                else
                {
                    popUpMsg("Register Failed.");
                }
            }
            con.Close();
            
            
        }
        protected void btnCancelRegs_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        
    }
}