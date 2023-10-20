using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;

namespace WebAssignment
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["totalPrice"] == null)
                {
                    Response.Redirect("AddToCart.aspx");
                }
                else
                {
                    lblTotalCost.Text = "RM " + Session["totalPrice"].ToString();
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
        protected void btnCancelPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddToCart.aspx");
        }
        protected void btnProceed_Click(object sender, EventArgs e)
        {
            Session["purchaseBy"] = txtCardholderName.Text;

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(strCon);

            con.Open();
            string getUserID = "Select UserId from Users where username='" + Session["username"] + "'";
            SqlCommand cmdGetUserId = new SqlCommand(getUserID, con);
            SqlDataReader dt = cmdGetUserId.ExecuteReader();
            var UserID = "";
            while (dt.Read())
            {
                UserID = dt.GetString(0); //The 0 stands for "the 0'th column", so the first column of the result.
                                          // Do somthing with this rows string, for example to put them in to a list
            }
            con.Close();

            con.Open();
            string strInsert = "Insert Into PaymentHistory (BuyerId, SellerId, ProdId, " +
                "CartQuant, CartPrice, BuyDate, BuyTime) Values (@buyerid, @selletid, " +
                "@prodid, @cartquant, @cartprice, @buydate, @buytime)";
            string buyerId, sellerId, prodId, buyDate, buyTime;
            int cartQuant, stockQuant;
            float cartPrice;
            string receiptStr = "";
            string prodName, prodPrice;
            SqlCommand cmdInsert = new SqlCommand(strInsert, con);

            SqlCommand cmdGetInfo = new SqlCommand("Select * from AddToCart INNER JOIN " +
                "Products ON AddToCart.ProdId = Products.ProdId " +
                "where AddToCart.BuyerId = '" + UserID + "'", con);

            SqlDataReader dr = cmdGetInfo.ExecuteReader();
            int intInsertStatus = 0;
            int intUpdateQuant = 0;
            while (dr.Read())
            {
                SqlConnection con2;
                string strCon2 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con2 = new SqlConnection(strCon2);

                SqlCommand cmdInsert2 = new SqlCommand(strInsert, con2);

                con2.Open();

                buyerId = UserID;
                sellerId = dr["SellerId"].ToString();
                prodId = dr["ProdId"].ToString();
                cartQuant = int.Parse(dr["CartQuant"].ToString());
                cartPrice = int.Parse(dr["CartPrice"].ToString());
                buyDate = DateTime.Now.ToString("dd/MM/yyyy");
                buyTime = DateTime.Now.ToString("HH:mm");

                cmdInsert2.Parameters.AddWithValue("@buyerid", buyerId);
                cmdInsert2.Parameters.AddWithValue("@selletid", sellerId);
                cmdInsert2.Parameters.AddWithValue("@prodid", prodId);
                cmdInsert2.Parameters.AddWithValue("@cartquant", cartQuant);
                cmdInsert2.Parameters.AddWithValue("@cartprice", cartPrice);
                cmdInsert2.Parameters.AddWithValue("@buydate", buyDate);
                cmdInsert2.Parameters.AddWithValue("@buytime", buyTime);

                prodName = dr["ProdName"].ToString();
                prodPrice = dr["ProdPrice"].ToString();


                //generate receipt
                Session["receiptDate"] = buyDate + "," + buyTime;
                receiptStr = receiptStr + prodName + "," + prodPrice + "," + cartQuant + "|";

                stockQuant = int.Parse(dr["ProdQuant"].ToString());
                stockQuant = stockQuant - cartQuant;
                intInsertStatus = cmdInsert2.ExecuteNonQuery();
                con2.Close();

                //deduct prod quant
                SqlConnection con3;
                string strCon3 = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                con3 = new SqlConnection(strCon3);

                con3.Open();
                string strUpdateQuant = "Update Products Set ProdQuant = @pquant where ProdId ='" + prodId + "'";
                SqlCommand cmdUpdate = new SqlCommand(strUpdateQuant, con3);
                cmdUpdate.Parameters.AddWithValue("@pquant", stockQuant);
                intUpdateQuant = cmdUpdate.ExecuteNonQuery();
                con3.Close();
            }
            dr.Close();
            con.Close();


            //receipt
            con.Open();
            string getUInfo = "Select * from Users where UserId='" + UserID + "'";
            SqlCommand cmdGetUInfo = new SqlCommand(getUInfo, con);
            SqlDataReader de = cmdGetUInfo.ExecuteReader();
            var Email = "";
            var Address = "";
            while (de.Read())
            {
                Email = de["UserEmail"].ToString();
                Address = de["UserAddress"].ToString();
            }
            de.Close();
            con.Close();

            Random rnd = new Random();
            int rndId = rnd.Next(0, 999999);
            Session["receiptId"] = String.Format("R{0:000000}", rndId);

            StringBuilder mailbody = new StringBuilder();
            mailbody.Append("Receipt Id: " + Session["receiptI"] + "<br />");
            mailbody.Append("Purchased By: " + Session["purchaseBy"] + "<br />");

            List<string> arrReceiptDate = Session["receiptDate"].ToString().Split(',').ToList();
            mailbody.Append("Purchased Date: " + arrReceiptDate[0] + "<br />");
            mailbody.Append("Purchased Time: " + arrReceiptDate[1] + "<br />");
            mailbody.Append("Delivery To: " + Address + " <br /> ");
            mailbody.Append(" <table border=" + 1 + " cellpadding=" + 0 + 
                " cellspacing=" + 0 + " width = " + 600 + ">" +
                "<tr bgcolor='#AAAADD' style='text-align: center;'>" +
                "<td><b>Artwork Name</b></td><td><b>Unit Price (RM)</b>" +
                "</td><td><b>Quantity (pcs)</b></td></tr>");
            List<string> arrReceiptProd = receiptStr.Split('|').ToList();
            for (int i = 0; i < arrReceiptProd.Count - 1; i++)
            {
                List<string> arrReceiptInfo = arrReceiptProd[i].Split(',').ToList();
                mailbody.Append("<tr style='text-align: center;' ><td>" + 
                    arrReceiptInfo[0] + "</td><td>" + arrReceiptInfo[1] + 
                    "</td><td>" + arrReceiptInfo[2] + "</td></tr>");
            }
            mailbody.Append("</table>");
            mailbody.Append("Total Price RM " + Session["totalPrice"].ToString() + " <br />");
            mailbody.Append("Customer Service Hotline: 03-4149 5655. <br />");
            mailbody.Append("Thank you for your purchased. Have a nice day :)");


            string to = Email; //To address    
            string from = "peterjxartworkgallery@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);            
            message.Subject = "Payment Receipt from Pater & Jx Artwork Gallery";
            message.Body = mailbody.ToString();


            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("peterjxartworkgallery@gmail.com", "1234abc.");
            client.UseDefaultCredentials = false; //
            client.Credentials = basicCredential1;
            client.EnableSsl = true;
            //client.Credentials = CredentialCache.DefaultNetworkCredentials;
            //client.Send(message);
            /*
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            */

            if (intInsertStatus > 0 && intUpdateQuant > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    //"alert('Payment Successful \\n Please check your email'); " +
                    "alert('Payment Successfully'); " +
                    "window.location ='ReceiptPage.aspx';", true);
            }
        }
    }
}