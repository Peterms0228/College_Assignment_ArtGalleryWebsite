using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace WebAssignment
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    SqlConnection con;
                    string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    con = new SqlConnection(strCon);

                    con.Open();

                    string getInfo = "Select * from Users where username='" + Session["username"] + "'";
                    SqlCommand cmdGetUserInfo = new SqlCommand(getInfo, con);
                    SqlDataReader dt = cmdGetUserInfo.ExecuteReader();
                    var UserID = "";
                    
                    while (dt.Read())
                    {
                        UserID = dt.GetString(0);
                        lblUserName.Text = dt.GetString(1);
                        txtUserEmail.Text = dt.GetString(4);
                        txtUserPhone.Text = dt.GetString(5);
                        txtUserAddr.Text = dt.GetString(6);

                    }
                    con.Close();

                    SqlCommand cmd = new SqlCommand("SELECT UserImg From Users where UserId ='" + UserID + "'", con);
                    con.Open();
                    SqlDataReader dt2 = cmd.ExecuteReader();
                    DataList1.DataSource = dt2;
                    DataList1.DataBind();
                    con.Close();
                }
            }
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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);

            con.Open();

            string getInfo = "Select * from Users where username='" + Session["username"] + "'";
            SqlCommand cmdGetUserInfo = new SqlCommand(getInfo, con);
            SqlDataReader dt = cmdGetUserInfo.ExecuteReader();
            var UserID = "";
            var DBPassw = "";

            while (dt.Read())
            {
                UserID = dt.GetString(0);
                DBPassw = dt.GetString(2);
            }
            con.Close();

            string strUpdateAll = "Update Users Set UserPassw = @upassw, UserImg = @uimg, UserEmail = @uemail, UserPhone = @uphone, UserAddress = @uaddress Where UserId = '"+ UserID + "'";
            string strUpdateNoImg = "Update Users Set UserPassw = @upassw, UserEmail = @uemail, UserPhone = @uphone, UserAddress = @uaddress Where UserId = '"+ UserID + "'";

            string userPasswOld, userEmail, userPhone, userAddress;
            string userPasswNew;
            bool isUpdate = false;
            bool isUpdatePassw = false;

            byte[] userImg;
            using (BinaryReader br = new BinaryReader(fuUserPic.PostedFile.InputStream))
            {
                userImg = br.ReadBytes(fuUserPic.PostedFile.ContentLength);
            }

            userEmail = txtUserEmail.Text;
            userPhone = txtUserPhone.Text;
            userAddress = txtUserAddr.Text;
            userPasswOld = txtUserPasswOld.Text;
            userPasswNew = DBPassw;

            if (userImg != null && userImg.Length > 0)
            {
                if (userPasswOld.Equals(DBPassw))
                {
                    if (!txtUserPasswNew.Text.Equals(txtUserPasswConf.Text))
                    {
                        //Response.Write("<script>alert('Password is unmatch!');</script>");
                        popUpMsg("Password is unmatch!");

                    }
                    else if (txtUserPasswNew.Text == "")
                    {
                        popUpMsg("New password cannot be empty!");
                    }
                    else
                    {
                        userPasswNew = txtUserPasswNew.Text;
                        isUpdate = true;
                        isUpdatePassw = true;
                    }
                }
                else if (userPasswOld == "")
                {
                    isUpdate = true;
                    isUpdatePassw = false;
                }
                else
                {
                    //Response.Write("<script>alert('Old Password is incorrect!');</script>");
                    popUpMsg("Old Password is incorrect!");

                }

                if (isUpdate == true)
                {
                    con.Open();
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateAll, con);
                    cmdUpdate.Parameters.AddWithValue("@upassw", userPasswNew);
                    cmdUpdate.Parameters.AddWithValue("@uimg", userImg);
                    cmdUpdate.Parameters.AddWithValue("@uemail", userEmail);
                    cmdUpdate.Parameters.AddWithValue("@uphone", userPhone);
                    cmdUpdate.Parameters.AddWithValue("@uaddress", userAddress);

                    int intInsertStatus = cmdUpdate.ExecuteNonQuery();
                    con.Close();

                    if (intInsertStatus > 0 && isUpdatePassw == true)
                    {
                        popUpMsg("User Update Successfully!");
                    }
                    else if (intInsertStatus > 0 && isUpdatePassw == false)
                    {
                        popUpMsg("User Update Successfully and Password remains unchanged!");
                    }
                    else
                    {
                        popUpMsg("User Update Failed!");
                    }
                    SqlCommand cmd = new SqlCommand("SELECT UserImg From Users where UserId ='" + UserID + "'", con);
                    con.Open();
                    SqlDataReader dt2 = cmd.ExecuteReader();
                    DataList1.DataSource = dt2;
                    DataList1.DataBind();
                    con.Close();
                }
            }
            else
            {
                if (userPasswOld.Equals(DBPassw))
                {
                    if (!txtUserPasswNew.Text.Equals(txtUserPasswConf.Text))
                    {
                        //Response.Write("<script>alert('Password is unmatch!');</script>");
                        popUpMsg("Password is unmatch!");

                    }
                    else if (txtUserPasswNew.Text == "")
                    {
                        popUpMsg("New password cannot be empty!");
                    }
                    else
                    {
                        userPasswNew = txtUserPasswNew.Text;
                        isUpdate = true;
                        isUpdatePassw = true;
                    }
                }
                else if (userPasswOld == "")
                {
                    isUpdate = true;
                    isUpdatePassw = false;
                }
                else
                {
                    //Response.Write("<script>alert('Old Password is incorrect!');</script>");
                    popUpMsg("Old Password is incorrect!");

                }

                if (isUpdate == true)
                {
                    con.Open();
                    SqlCommand cmdUpdate = new SqlCommand(strUpdateNoImg, con);
                    cmdUpdate.Parameters.AddWithValue("@upassw", userPasswNew);
                    cmdUpdate.Parameters.AddWithValue("@uemail", userEmail);
                    cmdUpdate.Parameters.AddWithValue("@uphone", userPhone);
                    cmdUpdate.Parameters.AddWithValue("@uaddress", userAddress);

                    int intInsertStatus = cmdUpdate.ExecuteNonQuery();
                    con.Close();

                    if (intInsertStatus > 0 && isUpdatePassw == true)
                    {
                        popUpMsg("User Update Successfully!");
                    }
                    else if (intInsertStatus > 0 && isUpdatePassw == false)
                    {
                        popUpMsg("User Update Successfully and Password remains unchanged!");
                    }
                    else
                    {
                        popUpMsg("User Update Failed!");
                    }
                }
            }


            

        }

        protected void btnCancelRegs_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}