using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssignment
{
    public partial class AdBanner : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            SqlConnection con;
            string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            con = new SqlConnection(strCon);
            con.Open();

            string strReceive = "Select UserAddress from Users where username='" + Session["username"] + "'";

            SqlCommand cmdRetrieve;
            cmdRetrieve = new SqlCommand(strReceive, con);

            if(cmdRetrieve.ExecuteScalar() != null)
            {
                string addr = cmdRetrieve.ExecuteScalar().ToString();

                if (addr.Contains("kuala lumpur") || addr.Contains("Kuala Lumpur"))
                {
                    Random rand = new Random();
                    int j = rand.Next(8, 11);
                    BannerImage.ImageUrl = "~/Images/" + j.ToString() + ".jpg";
                }
                else if (addr.Contains("sarawak") || addr.Contains("Sarawak"))
                {
                    Random rand = new Random();
                    int j = rand.Next(12, 15);
                    BannerImage.ImageUrl = "~/Images/" + j.ToString() + ".jpg";
                }
                else
                {
                    Random rand = new Random();
                    int j = rand.Next(15, 18);
                    BannerImage.ImageUrl = "~/Images/" + j.ToString() + ".jpg";
                }
            }
            else
            {
                Random rand = new Random();
                int j = rand.Next(15, 18);
                BannerImage.ImageUrl = "~/Images/" + j.ToString() + ".jpg";
            }
            
        }
    }
}