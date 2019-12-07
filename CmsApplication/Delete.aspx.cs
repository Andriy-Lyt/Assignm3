using CmsApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CmsApplication
{
    /// <summary>
    /// Deletes page information from database
    /// </summary>
    public partial class Delete : System.Web.UI.Page
    {
        DataProvider dp;

        protected void Page_Load(object sender, EventArgs e)
        {
            // get page id from query string 
            int pageId = Int32.Parse(this.Request.QueryString["pageId"]);

            // delete page from database 
            dp = new DataProvider();
            dp.DeletePage(pageId);

            // redirect client browser to main page
            Response.Redirect("default.aspx");
        }
    }
}