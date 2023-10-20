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
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.Title = "Mr.P Artwork Gallery";
            if (!IsPostBack)
            {
                //to check if user ady login
                if (Session["userid"] != null)
                {
                    NavMenu.Items[4].Text = "User Profile";
                    NavMenu.Items[4].Value = "User Profile";

                    NavMenu.Items[5].Text = "Log Out";
                    NavMenu.Items[5].Value = "Log Out";
                }


                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);


                con.Open();

                string getID = "Select UserId from Users where username='" + Session["username"] + "'";
                SqlCommand cmdGetUserId = new SqlCommand(getID, con);
                SqlDataReader dt = cmdGetUserId.ExecuteReader();
                var UserID = "";
                while (dt.Read())
                {
                    UserID = dt.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                              // Do somthing with this rows string, for example to put them in to a list
                }
                con.Close();

                if (Session["userid"] != null)
                {
                    con.Open();
                    string strCount = "SELECT COUNT(*) from AddToCart where BuyerId = '" + UserID + "'";
                    SqlCommand cmdCount;
                    cmdCount = new SqlCommand(strCount, con);
                    int rowsAmount = (int)cmdCount.ExecuteScalar();
                    lblNumInCart.Text = rowsAmount.ToString();
                    con.Close();
                }
                else
                {
                    lblNumInCart.Text = "0";
                }

            }
            lblDateTime.Text = DateTime.Now.ToString();
        }


        protected void NavMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //to check if user ady login
            if (Session["userid"] != null)
            {

                switch (e.Item.Text)
                {
                    case "Home":
                        Response.Redirect("Home.aspx");
                        break;
                    case "Artwork Menu":
                        Response.Redirect("ProductMenu.aspx");
                        break;
                    case "View My Artwork":
                        Response.Redirect("ViewArtwork.aspx");
                        break;
                    case "Post Artwork":
                        Response.Redirect("AddProduct.aspx");
                        break;
                    case "User Profile":
                        Response.Redirect("UserProfile.aspx");      //need to change to user profile page
                        break;
                    case "Log Out":
                        Session["userid"] = null;
                        Response.Redirect("Home.aspx");  //need to do modification
                        break;
                    default:
                        Response.Redirect("~/");
                        break;
                }
            }
            else
            {
                //user havent login
                switch (e.Item.Text)
                {
                    case "Home":
                        Response.Redirect("Home.aspx");
                        break;
                    case "Artwork Menu":
                        Response.Redirect("ProductMenu.aspx");
                        break;
                    case "View My Artwork":
                        Response.Redirect("ViewArtwork.aspx");
                        break;
                    case "Post Artwork":
                        Response.Redirect("AddProduct.aspx");
                        break;
                    case "User Login":
                        Response.Redirect("LoginPage.aspx");
                        break;
                    case "Registration":
                        Response.Redirect("RegisterPage.aspx");  //need to do modification
                        break;
                    default:
                        Response.Redirect("~/");
                        break;
                }
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AddToCart.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WishlistPage.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("PurchaseSummary.aspx");
        }
    }
}