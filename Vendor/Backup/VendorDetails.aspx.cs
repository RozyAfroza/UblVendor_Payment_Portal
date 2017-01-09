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
    public partial class VendorDetails : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        private Vendor.BO.Vendor _vendor;
        #endregion
        
        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Vendor Detail";

            if (!IsPostBack)
            {
                int id = 0;
                if (Page.Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Page.Request.QueryString["ID"]);
                }
                ViewState["ID"] = id;
                
                _vendor = new Vendor.BO.Vendor().GetData(id);

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
            _vendor = new Vendor.BO.Vendor().GetData(id);
            try
            {
                RefreshObject();
                
                _vendor.Save();

                _message.Text = "Data Saved Successfully";
                _message.CssClass = "MessageSuccess";

                if (id > 0)
                {
                    Response.Redirect("VendorList.aspx");
                }
                else
                {
                    _vendor = new Vendor.BO.Vendor();
                    RefreshControl();
                }
            }
            catch (Exception exp)
            {
                _message.Text = exp.Message;
                _message.CssClass = "MessageError";
            }
        }

        protected void btnlist_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorList.aspx");
        }
        #endregion

        #region Methods
        private void RefreshControl()
        {
            txtbxcode.Text = _vendor.Code;
            txtbxUserName.Text = _vendor.UserName;
            txtbxaddress.Text = _vendor.Address;
            txtbxemail.Text = _vendor.Email;
            txtbxcontactno.Text = _vendor.ContactNo;
            txtbxbankname.Text = _vendor.BankName;
            txtbxaccountno.Text = _vendor.AccountNo;
            txtbxpaymentterm.Text = Convert.ToString(_vendor.PaymentTerm);
            chkbxisactive.Checked = _vendor.IsActive;

        }
        private void RefreshObject()
        {
            _vendor.Code = txtbxcode.Text;
            _vendor.UserName = txtbxUserName.Text;
            _vendor.Address = txtbxaddress.Text;
            _vendor.Email = txtbxemail.Text;
            _vendor.ContactNo = txtbxcontactno.Text;
            _vendor.BankName = txtbxbankname.Text;
            _vendor.AccountNo = txtbxaccountno.Text;
            _vendor.PaymentTerm = Convert.ToInt32(txtbxpaymentterm.Text);
            _vendor.IsActive = chkbxisactive.Checked;

        }
        #endregion 

        protected void chkbxisactive_CheckedChanged(object sender, EventArgs e)
        {

        }

        }
    }
