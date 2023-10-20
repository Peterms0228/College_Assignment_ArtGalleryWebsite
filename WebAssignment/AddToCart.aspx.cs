using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebAssignment
{
    public partial class AddToCart : System.Web.UI.Page
    {
        Boolean isDeleteCart = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isDeleteCart = false; 
                DisplayCartQuant();
                //DataList_AddToCart.DataBind();

                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                if(Session["userid"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT AddToCart.CartId, AddToCart.ProdId, Products.ProdName, " +
                        "Products.ProdImg, Products.ProdDesc, Products.ProdPrice, Users.UserName, AddToCart.CartQuant, " +
                        "AddToCart.CartPrice FROM AddToCart INNER JOIN Products ON AddToCart.ProdId = Products.ProdId " +
                        "INNER JOIN Users ON AddToCart.SellerId = Users.UserId where AddToCart.BuyerId ='" + Session["userid"] +
                        "'order by AddToCart.CartId desc", con);
                    con.Open();
                    SqlDataReader dt = cmd.ExecuteReader();
                    DataList_AddToCart.DataSource = dt;
                    DataList_AddToCart.DataBind();
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

        protected void DataList_AddToCart_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (isDeleteCart == true)
            {
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                con.Open();
                string cartId = e.CommandArgument.ToString();

                string strDelete = "Delete from AddToCart where CartId='" + cartId + "'";
                SqlCommand cmdDelete = new SqlCommand(strDelete, con);

                int intDeleteStatus = cmdDelete.ExecuteNonQuery();
                if (intDeleteStatus > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),"alert", "alert('Cart removed!'); window.location ='AddToCart.aspx';", true);
                }
                con.Close();

                /*
                SqlCommand cmd = new SqlCommand("SELECT AddToCart.CartId, AddToCart.ProdId, Products.ProdName, " +
                        "Products.ProdImg, Products.ProdDesc, Products.ProdPrice, Users.UserName, AddToCart.CartQuant, " +
                        "AddToCart.CartPrice FROM AddToCart INNER JOIN Products ON AddToCart.ProdId = Products.ProdId " +
                        "INNER JOIN Users ON AddToCart.SellerId = Users.UserId where AddToCart.BuyerId ='" + Session["userid"] + "'", con);
                con.Open();
                SqlDataReader dt = cmd.ExecuteReader();
                DataList_AddToCart.DataSource = dt;
                DataList_AddToCart.DataBind();
                con.Close();
                */

                //DisplayCartQuant();
                //Response.Redirect("AddToCart.aspx");
            }
            
        }
        protected void DataList_AddToCart_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl = (Label)e.Item.FindControl("lblTotalPrice");
                string totalPrice = DisplayTotalPrice();
                lbl.Text = Convert.ToString("RM " + totalPrice);
            }
        }


        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            isDeleteCart = true;
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            string totalPrice = DisplayTotalPrice();
            if(totalPrice == "0")
            {
                popUpMsg("You havent buy anything yet!");
            }
            else
            {       
                Session["totalPrice"] = totalPrice;
                Response.Redirect("PaymentPage.aspx");
            }

        }
        public void DisplayCartQuant()
        {
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


            con.Open();
            string strCount = "SELECT COUNT(*) FROM AddToCart where BuyerId ='" + UserID + "'";
            SqlCommand cmdCount = new SqlCommand(strCount, con);
            int rowsAmount = (int)cmdCount.ExecuteScalar();
            lblAddToCartNo.Text = rowsAmount.ToString();
            con.Close();
        }

        public string DisplayTotalPrice()
        {

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

            con.Open();
            string strSum = "SELECT SUM(cartPrice) FROM AddToCart where BuyerId ='" + UserID + "'";
            SqlCommand cmdSum = new SqlCommand(strSum, con);
            object total = cmdSum.ExecuteScalar();
            string totalPrice = Convert.ToString(total);
            if (totalPrice == "")
            {
                totalPrice = "0";
            }
            con.Close();
            return totalPrice;

        }
        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);

            con.Open();

            string strDelete = "Delete from AddToCart where BuyerId='" + Session["userid"] + "'";
            SqlCommand cmdDelete = new SqlCommand(strDelete, con);

            int intDeleteStatus = cmdDelete.ExecuteNonQuery();
            if (intDeleteStatus > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All Cart removed!'); window.location ='AddToCart.aspx';", true);
            }
            con.Close();
        }

    }
        
}