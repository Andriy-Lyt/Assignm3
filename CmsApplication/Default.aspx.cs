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
    /// Default page: list of pages + actions 
    /// </summary>
    public partial class _Default : Page
    {
        DataProvider dp;

        protected void Page_Load(object sender, EventArgs e)
        {
            // object that communicates with database
            dp = new DataProvider();            

            // menu (list of pages)
            List<PageInfo> pages = dp.GetAllPages();
            rptMenu.DataSource = pages;
            rptMenu.DataBind();

            // pages list (for table with actions)
            rptPages.DataSource = pages;
            rptPages.DataBind();

            // Page.Title for master page 
            this.Title = "Main page";
        }
    }
}