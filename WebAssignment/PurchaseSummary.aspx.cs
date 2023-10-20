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
    public partial class PurchaseSummary : System.Web.UI.Page
    {
        Boolean isDeleteHistory = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isDeleteHistory = false;

                //DataList_AddToCart.DataBind();

                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                if (Session["userid"] == null)
                {
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT PaymentHistory.HistoryId, PaymentHistory.ProdId, " +
                        "Products.ProdName, Products.ProdImg, Products.ProdPrice, Users.UserName, " +
                        "PaymentHistory.CartQuant, PaymentHistory.CartPrice, PaymentHistory.BuyDate, " +
                        "PaymentHistory.BuyTime FROM PaymentHistory INNER JOIN Products ON PaymentHistory.ProdId = " +
                        "Products.ProdId INNER JOIN Users ON PaymentHistory.SellerId = Users.UserId " +
                        "where PaymentHistory.BuyerId ='" + Session["userid"] + "'order by PaymentHistory.HistoryId desc", con);

                    con.Open();
                    SqlDataReader dt = cmd.ExecuteReader();
                    DataList_PurcSummary.DataSource = dt;
                    DataList_PurcSummary.DataBind();
                    con.Close();

                }

            }
        }
        protected void DataList_PurcSummary_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (isDeleteHistory == true)
            {
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con = new SqlConnection(strCon);

                con.Open();
                string historyId = e.CommandArgument.ToString();

                string strDelete = "Delete from PaymentHistory where HistoryId='" + historyId + "'";
                SqlCommand cmdDelete = new SqlCommand(strDelete, con);

                int intDeleteStatus = cmdDelete.ExecuteNonQuery();
                if (intDeleteStatus > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('History removed!'); window.location ='PurchaseSummary.aspx';", true);
                }
                con.Close();
            }
        }
        protected void btnRemoveHistory_Click(object sender, EventArgs e)
        {
            isDeleteHistory = true;
        }

        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);

            con.Open();

            string strDelete = "Delete from PaymentHistory where BuyerId='" + Session["userid"] + "'";
            SqlCommand cmdDelete = new SqlCommand(strDelete, con);

            int intDeleteStatus = cmdDelete.ExecuteNonQuery();
            if (intDeleteStatus > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All History removed!'); window.location ='PurchaseSummary.aspx';", true);
            }
            con.Close();
        }
    }
}