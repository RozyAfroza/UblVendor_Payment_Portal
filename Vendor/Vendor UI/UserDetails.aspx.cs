using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
    public partial class UserDetails : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        private Vendor.BO.User _user;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "User Details";

            if (!IsPostBack)
            {
                int id = 0;
                if (Page.Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Page.Request.QueryString["ID"]);
                }
                ViewState["ID"] = id;

                _user = new Vendor.BO.User().GetData(id);

                RefreshControl();
            }
        }
        #endregion

        #region Button Events
        protected void btnsave_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (ViewState["ID"] != null)
            {
                id = Convert.ToInt32(ViewState["ID"]);
            }
            _user = new Vendor.BO.User().GetData(id);
            try
            {
                RefreshObject();

                _user.Save();

                _message.Text = "Data Saved Successfully";
                _message.CssClass = "MessageSuccess";

                if (id > 0)
                {
                    Response.Redirect("UserList.aspx");
                }
                else
                {
                    _user = new Vendor.BO.User();
                    RefreshControl();
                }
            }
            catch (Exception exp)
            {
                _message.Text = exp.Message;
                _message.CssClass = "MessageError";
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }
        protected void btnlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserList.aspx");
        }
        #endregion

        #region Methods

        private void RefreshControl()
        {
            txtbxUserName.Text = _user.UserName;
            txtbxUserID.Text = _user.UserID;
            txtbxPassword.Text = _user.Password;
            chckbxIsAdmin.Checked = _user.IsAdmin;
            chckbxIsOperator.Checked = _user.IsOperator;

        }
        private void RefreshObject()
        {
            _user.UserName = txtbxUserName.Text;
            _user.UserID = txtbxUserID.Text;
            _user.Password = txtbxPassword.Text;
            _user.IsAdmin = chckbxIsAdmin.Checked;
            _user.IsOperator = chckbxIsOperator.Checked;

        }
        #endregion



    }
}