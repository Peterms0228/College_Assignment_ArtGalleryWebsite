using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebAssignment
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
            Application.Lock();
            //Application["NoOfErrors"] = (int)Application["NoOfErrors"] + 1;
            Application.UnLock();
            Response.Write("<br/> There is an Application Error!");
            Response.Write("<p><h2>Sorry, Something went wrong. <br/> IT Team is working on this issue. Please check back later");
            Response.Write("<p><h3><span style= 'color:red'>Redirecting to Home Page....<span><br/><br/>");
            Response.AddHeader("REFRESH", "5;URL=Home.aspx");   //pause 5 sec and then redirect
            Server.ClearError();
            
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}