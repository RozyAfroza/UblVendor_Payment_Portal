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
    public partial class DocumentDetails : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        private Vendor.BO.Document _document;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Document Details";

            if (!IsPostBack)
            {
                int id = 0;
                if (Page.Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Page.Request.QueryString["ID"]);
                }
                ViewState["ID"] = id;

                _document = new Vendor.BO.Document().GetData(id);

                RefreshControl();
            }

        }
        #endregion

        #region Button Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (ViewState["ID"] != null)
            {
                id = Convert.ToInt32(ViewState["ID"]);
            }
            _document = new Vendor.BO.Document().GetData(id);
            
            try
            {
                RefreshObject();

                _document.Save();

                _message.Text = "Data Saved Successfully";
                _message.CssClass = "MessageSuccess";

                if (id > 0)
                {
                    Response.Redirect("DocumnetList.aspx");
                }
                else
                {
                    _document = new Vendor.BO.Document();
                    RefreshControl();
                }
            }
            catch (Exception exp)
            {
                _message.Text = exp.Message;
                _message.CssClass = "MessageError";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentList.aspx");
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentList.aspx");
        }
        #endregion

        #region Methods
        private void RefreshControl()
        {
            txtbxdescription.Text = _document.Description;
            chkbxismendatory.Checked = _document.IsMendatory;

        }
        private void RefreshObject()
        {
            _document.Description = txtbxdescription.Text;
            _document.IsMendatory = chkbxismendatory.Checked;

        }
        #endregion


    }
}
