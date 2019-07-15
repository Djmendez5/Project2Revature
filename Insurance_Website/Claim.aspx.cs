using Insurance_Website.Class_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Insurance_Website
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Request.QueryString != null)
                {
                    Claim newClaim = new Claim(Request.Form["title"], Request.Form["PolicyNumber"], Request.Form["Amount"].ToString());
                    Record.Create(newClaim);
                }
            }
        }
    }
}