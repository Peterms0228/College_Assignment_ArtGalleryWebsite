using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssignment
{
    public partial class ViewArtwork : System.Web.UI.Page
    {
        String Productid;

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
                    ShowProduct();
                }

            }
        }

        public void ShowProduct()
        {
            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);

            SqlCommand cmd = new SqlCommand("Select * from Products where ArtistId='" + Session["userid"] + "'", con); //show all product from database
            con.Open();
            SqlDataReader dt = cmd.ExecuteReader();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowProduct();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            ShowProduct();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;
            int index = e.NewEditIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];
            Label productId = (Label)row.FindControl("lblId");
            Productid = productId.Text;

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("Select * from Products where ProdId='" + Productid + "'", con);
            con.Open();
            SqlDataReader dt = cmd.ExecuteReader();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            FileUpload fileup = (FileUpload)row.FindControl("FileUpload1");
            if (fileup.HasFile)
            {
                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                con = new SqlConnection(strCon);
                con.Open();

                Label productID = (Label)row.FindControl("lblId");
                TextBox pname = (TextBox)row.FindControl("txtboxName");
                TextBox pdesc = (TextBox)row.FindControl("txtboxDesc");
                TextBox pprice = (TextBox)row.FindControl("txtboxPrice");
                TextBox pquant = (TextBox)row.FindControl("txtboxQuant");

                byte[] data;
                using (BinaryReader br = new BinaryReader(fileup.PostedFile.InputStream))
                {
                    data = br.ReadBytes(fileup.PostedFile.ContentLength);
                }

                SqlCommand cmdUpdate = new SqlCommand("UPDATE Products SET ProdName = @pname, ProdDesc = @pdesc, ProdImg = @pimg, ProdPrice = @pprice, ProdQuant = @pquant WHERE ProdId = @pid", con);
                cmdUpdate.Parameters.AddWithValue("@pname", pname.Text);
                cmdUpdate.Parameters.AddWithValue("@pdesc", pdesc.Text);
                cmdUpdate.Parameters.AddWithValue("@pimg", data);
                cmdUpdate.Parameters.AddWithValue("@pprice", pprice.Text);
                cmdUpdate.Parameters.AddWithValue("@pquant", pquant.Text);
                cmdUpdate.Parameters.AddWithValue("@pid", productID.Text);

                int intInsertStatus = cmdUpdate.ExecuteNonQuery();
                // executenonquery = return noOfRows (records) that are affected in the database table 

                if (intInsertStatus > 0)
                {
                    Response.Write("<script>alert('Artwork Update Successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Artwork Update Failed.');</script>");
                }

                con.Close();
                GridView1.EditIndex = -1;
                ShowProduct();
            }
            else
            {
                Response.Write("<script>alert('Artwork Image Cannot Be Empty. Please Select an image!');</script>");
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                GridViewRow row = (GridViewRow)GridView1.Rows[index];

                SqlConnection con;
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                con = new SqlConnection(strCon);
                con.Open();

                Label productId = (Label)row.FindControl("lblId");
                Productid = productId.Text;
                SqlCommand cmdDelete = new SqlCommand("delete from Products where ProdId='" + Productid + "'", con);

                int intInsertStatus = cmdDelete.ExecuteNonQuery();
                // executenonquery = return noOfRows (records) that are affected in the database table 

                if (intInsertStatus > 0)
                {
                    Response.Write("<script>alert('Artwork has Deleted.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Artwork Delete Failed.');</script>");
                }
                con.Close();
                GridView1.EditIndex = -1;
                ShowProduct();

            }
            catch (ArithmeticException ex)
            {
                Response.Write(ex.Message);
            }
            catch (FormatException ex)
            {
                Response.Write(ex.Message);
            }
            catch (Exception ex)
            {
                Response.Write("<p><h2>Sorry, Something went wrong. <br/> IT Team is working on this issue. Please check back later<br/>");
                Response.Write("<p><h3><span style= 'color:red'>Redirecting to Home Page....<span><br/><br/>");
                Response.AddHeader("REFRESH", "5;URL=Home.aspx");   //pause 5 sec and then redirect
            }

        }

        void Page_Error()
        {
            Response.Write("<p><h2>Sorry, Something went wrong. <br/> IT Team is working on this issue. Please check back later");
            Response.Write("<p><h3><span style= 'color:red'>Redirecting to Home Page....<span><br/><br/>");
            Response.AddHeader("REFRESH", "5;URL=Home.aspx");   //pause 5 sec and then redirect

            Server.ClearError();      //comment this line of code, if want to go to the application error
        }
    }
}