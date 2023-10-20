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
    public partial class WishlistPage : System.Web.UI.Page
    {
        Boolean isDelete = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                if (Session["userid"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT Wishlist.WishlistId, Wishlist.UserId, Wishlist.ProdId, " +
                        "Products.ProdName, Products.ProdDesc, Products.ProdImg, Products.ProdPrice, Products.ProdQuant, " +
                        "Products.ArtistId, Users.UserName FROM Wishlist INNER JOIN Products ON Wishlist.ProdId = " +
                        "Products.ProdId INNER JOIN Users ON Products.ArtistId = Users.UserId where Wishlist.UserId ='" + 
                        Session["userid"] + "'", con);
                    con.Open();
                    SqlDataReader dt = cmd.ExecuteReader();
                    DataList_Wishlist.DataSource = dt;
                    DataList_Wishlist.DataBind();
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
        protected void DataList_Wishlist_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (isDelete == true)
            {
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                con.Open();
                string wishlistId = e.CommandArgument.ToString();

                string strDelete = "Delete from Wishlist where WishlistId='" + wishlistId + "'";
                SqlCommand cmdDelete = new SqlCommand(strDelete, con);

                int intDeleteStatus = cmdDelete.ExecuteNonQuery();
                if (intDeleteStatus > 0)
                {
                    popUpMsg("Wishlist removed!");
                }
                con.Close();
                Response.Redirect("WishlistPage.aspx");
            }

        }
        protected void btnRemoveWishlist_Click(object sender, EventArgs e)
        {
            isDelete = true;
        }
        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);

            con.Open();

            string strDelete = "Delete from Wishlist where UserId='" + Session["userid"] + "'";
            SqlCommand cmdDelete = new SqlCommand(strDelete, con);

            int intDeleteStatus = cmdDelete.ExecuteNonQuery();
            if (intDeleteStatus > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All Wishlist removed!'); window.location ='WishlistPage.aspx';", true);
            }
            con.Close();
        }
    }

}