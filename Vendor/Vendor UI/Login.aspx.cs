using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Vendor.BO;
using DataAccess;


namespace Vendor.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["IsNew"] = true;
            this.lblMsg.Text = "";
        }
        protected void btnSignin_Click(object sender, EventArgs e)
        {
            if (txtbxUserID.Text.Length > 0)
            {
                Vendor.BO.User user = new Vendor.BO.User();
                user = user.GetData(txtbxUserID.Text);

                if (user == null)
                {
                    this.lblMsg.Text = "Invalid User ID";
                    return;
                }
                if (user.Password != txtbxPassword.Text)
                {
                    this.lblMsg.Text = "Invalid Password.";
                    return;
                }

                Session["User"] = user;
                Response.Redirect("VendorList.aspx");
            }
        }
                    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");  
        }
        
    }
}
