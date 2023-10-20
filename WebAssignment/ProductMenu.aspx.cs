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
    public partial class ProductMenu : System.Web.UI.Page
    {
        int optionAdd = 0; // 0: do nothing, 1: add to cart, 2: add to wishlist
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                optionAdd = 0;
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                
                SqlCommand cmd = new SqlCommand("SELECT Products.ProdId, Products.ProdName, Products.ProdDesc, " +
                    "Products.ProdImg, Products.ProdPrice, Products.ProdQuant, Products.ArtistId, Users.UserName " +
                    "FROM Products INNER JOIN Users ON Products.ArtistId = Users.UserId", con);
                con.Open();
                SqlDataReader dt2 = cmd.ExecuteReader();
                DataList_Product.DataSource = dt2;
                DataList_Product.DataBind();
                con.Close();

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
                    //lblAddToCartQuant.Text = rowsAmount.ToString();
                    con.Close();

                }
                else
                {
                    //lblAddToCartQuant.Text = "0";
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
        protected void DataList_Product_ItemCommand(object source, DataListCommandEventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);

            if (optionAdd == 1) //add to cart
            {
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

                int intInsertStatus = 0;
                //checkCartExist
                SqlCommand cmdFindExist = new SqlCommand("Select * from AddToCart " +
                "where BuyerId = '" + UserID + "' and ProdId = '" + e.CommandArgument.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdFindExist;
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //exist
                    popUpMsg("Cart Existed!");
                }
                else
                {
                    //non exist


                    //if out of stock
                    Label lbl = e.Item.FindControl("dlProdQuant") as Label;
                    if (lbl.Text == "Out of Stock!")
                    {
                        popUpMsg("Product is Out of Stock!");
                    }
                    else
                    {

                        con.Open();
                        string strInsert = "Insert Into AddToCart (BuyerId, SellerId, ProdId, CartQuant, " +
                            "CartPrice) Values (@buyerid, @sellerid, @prodid, @cartquant, @cartprice)";
                        string buyerId, sellerId, prodId;
                        int cartQuant, prodquant;
                        float cartPrice;
                        float prodPrice;

                        DropDownList dlist = (DropDownList)(e.Item.FindControl("ddlToBuy"));
                        SqlCommand cmdInsert = new SqlCommand(strInsert, con);
                        SqlCommand cmdGetProdInfo = new SqlCommand("Select * from Products " +
                            "where ProdId = '" + e.CommandArgument.ToString() + "'", con);

                        SqlDataReader dr = cmdGetProdInfo.ExecuteReader();
                        if (dr.Read())
                        {
                            buyerId = UserID;
                            sellerId = dr["ArtistId"].ToString();
                            prodId = dr["ProdId"].ToString();
                            prodPrice = int.Parse(dr["ProdPrice"].ToString());
                            cartQuant = int.Parse(dlist.SelectedValue.ToString());
                            cartPrice = prodPrice * cartQuant;

                            prodquant = int.Parse(dr["ProdQuant"].ToString());


                            if (cartQuant <= prodquant)
                            {
                                cmdInsert.Parameters.AddWithValue("@buyerid", buyerId);
                                cmdInsert.Parameters.AddWithValue("@sellerid", sellerId);
                                cmdInsert.Parameters.AddWithValue("@prodid", prodId);
                                cmdInsert.Parameters.AddWithValue("@cartquant", cartQuant);
                                cmdInsert.Parameters.AddWithValue("@cartprice", cartPrice);
                                dr.Close();
                                intInsertStatus = cmdInsert.ExecuteNonQuery();
                            }
                            else
                            {
                                dr.Close();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Quantity Exceeded'); window.location ='ProductMenu.aspx';", true);

                                //Response.Redirect("ProductMenu.aspx");
                            }

                        }
                    }
                }
                //dr.Close();


                if (intInsertStatus > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Product Added'); window.location ='AddToCart.aspx';", true);
                    Response.Redirect("AddToCart.aspx");
                }
                con.Close();
            }
            else if (optionAdd == 2) //wishlist
            {
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
                string prodId = e.CommandArgument.ToString();

                ImageButton btn = e.Item.FindControl("btnAddToWishlist") as ImageButton;
                if (btn.ImageUrl == "~/Images/unwishlist-icon.png")
                {
                    //add to wishlist

                    con.Open();
                    string strInsert = "Insert Into Wishlist (UserId, ProdId) Values (@buyerid, @prodid)";
                    SqlCommand cmdInsert = new SqlCommand(strInsert, con);

                    cmdInsert.Parameters.AddWithValue("@buyerid", UserID);
                    cmdInsert.Parameters.AddWithValue("@prodid", prodId);

                    int intInsertStatus = cmdInsert.ExecuteNonQuery();
                    if (intInsertStatus > 0)
                    {
                        btn.ImageUrl = "~/Images/wishlist-icon.png";
                    }
                    con.Close();
                }
                else
                {
                    //remove from wishlist

                    con.Open();
                    string strDelete = "Delete from Wishlist where ProdId='" + prodId + "' and UserId='" + UserID + "'";
                    SqlCommand cmdDelete = new SqlCommand(strDelete, con);

                    int intInsertStatus = cmdDelete.ExecuteNonQuery();
                    if (intInsertStatus > 0)
                    {
                        btn.ImageUrl = "~/Images/unwishlist-icon.png";
                    }
                    con.Close();
                }
            }
            else
            {

            }
            //Response.Redirect("AddToCart.aspx?id=" + e.CommandArgument.ToString());
        }
        protected void DataList_Product_ItemDataBound(object sender, DataListItemEventArgs e)
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
            Label lbl = e.Item.FindControl("dlProdId") as Label;
            ImageButton btn = e.Item.FindControl("btnAddToWishlist") as ImageButton;

            SqlCommand cmdFindExist = new SqlCommand("Select * from Wishlist " +
                "where UserId = '" + UserID + "' and ProdId = '" + lbl.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmdFindExist;
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                btn.ImageUrl = "~/Images/wishlist-icon.png";
            }
            else
            {
                btn.ImageUrl = "~/Images/unwishlist-icon.png";

            }

            //add drop down list value
            DropDownList ddl = e.Item.FindControl("ddlToBuy") as DropDownList;
            string getQuant = "Select ProdQuant from Products where ProdId='" + lbl.Text + "'";
            SqlCommand cmdGetProdQuant = new SqlCommand(getQuant, con);
            SqlDataReader ddr = cmdGetProdQuant.ExecuteReader();
            int prodQuant;
            while (ddr.Read())
            {
                prodQuant = int.Parse(ddr["ProdQuant"].ToString());
                //ddl.Items.Insert(0, new ListItem("", ""));
                for(int i = 1; i <= prodQuant; i++)
                {
                    ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            ddr.Close();

            con.Close();

            Label lblQuant = e.Item.FindControl("dlProdQuant") as Label;
            //if (lblQuant.Equals("Text = \"0\"}"))
            if(lblQuant.Text == "0")
            {
                lblQuant.Text = "Out of Stock!";
            }
            else
            {
                lblQuant.Text = "Quantity : " + lblQuant.Text + "pcs";
            }
        }

        protected void btnAddToCart_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["userid"] == null)
            {
                //popUpMsg("You need to login to add to cart!");
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                optionAdd = 1;
            }
        }

        protected void btnAddToWishlist_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["userid"] == null)
            {
                //popUpMsg("You need to login to add wishlist!");
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                optionAdd = 2;
            }
        }
    }
}