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
    /// Page that displays cms-page
    /// </summary>
    public partial class View : System.Web.UI.Page
    {
        DataProvider dp;

        protected void Page_Load(object sender, EventArgs e)
        {
            int pageId = Int32.Parse(Request.QueryString["pageId"]);

            // get page information from database
            dp = new DataProvider();
            PageInfo page = dp.GetPage(pageId);
            dContent.InnerHtml = page.Body;
            Page.Title = page.Title;
        }
    }
}