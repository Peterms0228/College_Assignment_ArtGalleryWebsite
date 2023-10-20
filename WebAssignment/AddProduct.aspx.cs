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
    public partial class AddProduct : System.Web.UI.Page
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

                }
            }
        }



        protected void btnPost_Click(object sender, EventArgs e)
        {


            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();

            //string strCount = "SELECT COUNT(*) from Products";
            //SqlCommand cmdCount;
            //cmdCount = new SqlCommand(strCount, con);
            //int rowsAmount = (int)cmdCount.ExecuteScalar();
            //int idNo = 1000 + rowsAmount;

            string strInsert = "";
            strInsert = "Insert Into Products (ArtistId, ProdName, ProdDesc, ProdImg, ProdPrice, ProdQuant) Values (@artistid, @pname, @pdesc, @pimg, @pprice, @pquant)";

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




            //string strProdId;
            //string strUserId;
            string strProdName, strProdDesc;
            float deciProdPrice;
            int intProdQuant;

            byte[] data;
            using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                data = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
            }

            //strProdId = "p"+ idNo;

            strProdName = txtProdName.Text;
            strProdDesc = txtProdDesc.Text;
            deciProdPrice = float.Parse(txtProdPrice.Text);
            intProdQuant = int.Parse(txtProdQuant.Text);

            con.Open();
            SqlCommand cmdInsert;
            cmdInsert = new SqlCommand(strInsert, con);

            //cmdInsert.Parameters.AddWithValue("@pid", strProdId);
            cmdInsert.Parameters.AddWithValue("@artistid", UserID);
            cmdInsert.Parameters.AddWithValue("@pname", strProdName);
            cmdInsert.Parameters.AddWithValue("@pdesc", strProdDesc);
            cmdInsert.Parameters.AddWithValue("@pimg", data);
            cmdInsert.Parameters.AddWithValue("@pprice", deciProdPrice);
            cmdInsert.Parameters.AddWithValue("@pquant", intProdQuant);

            int intInsertStatus = cmdInsert.ExecuteNonQuery();
            // executenonquery = return noOfRows (records) that are affected in the database table 

            if (intInsertStatus > 0)
            {

                //postSuccessMsg.Text = "Post Successfully.";
                postSuccessLink.Text = "View your posted Artwork";
                //Response.Write("<script>alert('Artwork has Posted! You are able to manage it anytime.');</script>");

                //display message box in this way wont change page layout
                string message = "Artwork has Posted! You are able to manage it anytime.";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                //postSuccessMsg.Text = "Post Failed.";
                Response.Write("<script>alert('Artwork post failed!');</script>");
            }

            con.Close();
        }
    }
}