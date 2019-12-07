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
    /// Page that allows to edit page information
    /// </summary>
    public partial class Edit : System.Web.UI.Page
    {
        DataProvider dp;

        protected void Page_Load(object sender, EventArgs e)
        {
            dp = new DataProvider();
            int pageId = Int32.Parse(Request.QueryString["pageId"]);

            if (IsPostBack)
            {
                // Get user input 
                string title = itTitle.Value;
                string body = taBody.Value;

                // Update database 
                dp = new DataProvider();
                dp.UpdatePage(pageId, title, body);
                h1SuccessMessage.Style.Clear();
            } else
            {
                // show page information
                PageInfo page = dp.GetPage(pageId);
                itTitle.Value = page.Title;
                taBody.Value = page.Body;
            }
        }
    }
}