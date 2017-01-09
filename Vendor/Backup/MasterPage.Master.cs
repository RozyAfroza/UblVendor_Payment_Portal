using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vendor.BO;

namespace Vendor.UI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Vendor.BO.User user = (Vendor.BO.User)Session["User"];
            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
            lblUserName.Text = user.UserName;
        }

        protected void mnuSystemMenu_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void lnkbtnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
        }
    }
}
