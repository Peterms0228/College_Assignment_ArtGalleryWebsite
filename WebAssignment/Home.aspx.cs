using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAssignment
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int j = rand.Next(1, 6);
            bannerImage.ImageUrl = "~/Images/" + j.ToString() + ".jpg";
        }
    }
}