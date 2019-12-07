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
    /// Page that allows to add new page information into database 
    /// </summary>
    public partial class AddNew : System.Web.UI.Page
    {
        DataProvider dp;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (IsPostBack)
            {
                // get user input
                string title = itTitle.Value;
                string body = taBody.Value;

                // insert new page information into database
                dp = new DataProvider();
                dp.InsertPage(title, body);
                h1SuccessMessage.Style.Clear();
            }
        }
    }
}