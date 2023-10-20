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
    public partial class ReceiptPage : System.Web.UI.Page
    {
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
                    con.Open();
                    string getUInfo = "Select * from Users where UserId='" + Session["userid"] + "'";
                    SqlCommand cmdGetUInfo = new SqlCommand(getUInfo, con);
                    SqlDataReader de = cmdGetUInfo.ExecuteReader();
                    var Address = "";
                    while (de.Read())
                    {
                        Address = de["UserAddress"].ToString();
                    }
                    de.Close();
                    con.Close();

                    lblReceiptId.Text = Session["receiptId"].ToString();
                    lblPurchasedBy.Text = Session["purchaseBy"].ToString();
                    lblDeliveryTo.Text = Address;
                    List<string> arrReceiptDate = Session["receiptDate"].ToString().Split(',').ToList();
                    lblReceiptDate.Text = arrReceiptDate[0];
                    lblReceiptTime.Text = arrReceiptDate[1];

                    SqlCommand cmd = new SqlCommand("SELECT AddToCart.CartId, AddToCart.ProdId, Products.ProdName, " +
                        "Products.ProdImg, Products.ProdDesc, Products.ProdPrice, Users.UserName, AddToCart.CartQuant, " +
                        "AddToCart.CartPrice FROM AddToCart INNER JOIN Products ON AddToCart.ProdId = Products.ProdId " +
                        "INNER JOIN Users ON AddToCart.SellerId = Users.UserId where AddToCart.BuyerId ='" + Session["userid"] +
                        "'order by AddToCart.CartId desc", con);
                    con.Open();
                    SqlDataReader dt = cmd.ExecuteReader();
                    DataList_Receipt.DataSource = dt;
                    DataList_Receipt.DataBind();
                    con.Close();

                    con.Open();
                    string strDelete = "Delete from AddToCart where BuyerId='" + Session["userid"] + "'";
                    SqlCommand cmdDelete = new SqlCommand(strDelete, con);
                    int intDeleteStatus = cmdDelete.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        protected void DataList_Receipt_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbl = (Label)e.Item.FindControl("lblTotalPrice");
                string totalPrice = Session["totalPrice"].ToString();
                lbl.Text = Convert.ToString("RM " + totalPrice);
            }
        }
    }
}