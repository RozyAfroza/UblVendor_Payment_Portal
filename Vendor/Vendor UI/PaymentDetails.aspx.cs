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
    public partial class PaymentDetails : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        private Vendor.BO.Invoice _invoice;
        #endregion

        #region Page Events
        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Payment Detail";

            if (!IsPostBack)
            {
                int id = 0;
                if (Page.Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Page.Request.QueryString["ID"]);
                }
                ViewState["ID"] = id;

                _invoice = new Vendor.BO.Invoice().GetData(id);

                RefreshControl();
            }
        }
        #endregion

        #region Button Events
        protected void btnPaid_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (ViewState["ID"] != null)
            {
                id = Convert.ToInt32(ViewState["ID"]);
            }
            _invoice = new Vendor.BO.Invoice().GetData(id);
            try
            {
                RefreshObject();

                _invoice.Paid();

                _message.Text = "Data Saved Successfully";
                _message.CssClass = "MessageSuccess";

                if (id > 0)
                {
                    Response.Redirect("PaymentList.aspx");
                }
                else
                {
                    _invoice = new Vendor.BO.Invoice();
                    RefreshControl();
                }
            }
            catch (Exception exp)
            {
                _message.Text = exp.Message;
                _message.CssClass = "MessageError";
            }
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentList.aspx");
        }
        #endregion

        #region Methods
        private void RefreshControl()
        {
            txtbxUserName.Text = _invoice.UserName;
            txtbxInvoiceReference.Text = _invoice.InvoiceReference;
            calInvoiceDate.SelectedDate = _invoice.InvoiceDate;
            txtbxPOReference.Text = _invoice.POReference;
            txtbxInvoiceValue.Text = Convert.ToString(_invoice.InvoiceValue);
            txtbxOmniflowReference.Text = _invoice.OmniflowReference;
        }
        private void RefreshObject()
        {
            _invoice.UserName = txtbxUserName.Text;
            _invoice.InvoiceReference = txtbxInvoiceReference.Text;
            _invoice.InvoiceDate = calInvoiceDate.SelectedDate;
            _invoice.POReference = txtbxPOReference.Text;
            _invoice.InvoiceValue = Convert.ToInt32(txtbxInvoiceValue.Text);
            _invoice.OmniflowReference = txtbxOmniflowReference.Text;
        }
        #endregion

        protected void btnReject_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (ViewState["ID"] != null)
            {
                id = Convert.ToInt32(ViewState["ID"]);
            }
            _invoice = new Vendor.BO.Invoice().GetData(id);
            try
            {
                RefreshObject();

                _invoice.Reject();

                _message.Text = "Data Saved Successfully";
                _message.CssClass = "MessageSuccess";

                if (id > 0)
                {
                    Response.Redirect("PaymentList.aspx");
                }
                else
                {
                    _invoice = new Vendor.BO.Invoice();
                    RefreshControl();
                }
            }
            catch (Exception exp)
            {
                _message.Text = exp.Message;
                _message.CssClass = "MessageError";
            }
        }

        protected void btnInvoiceDate_Click(object sender, EventArgs e)
        {
            calInvoiceDate.Visible = true;
        }

        protected void calInvoiceDate_SelectionChanged(object sender, EventArgs e)
        {
            txtbxInvoiceDate.Text = calInvoiceDate.SelectedDate.ToString();
            calInvoiceDate.Visible = false;
        }
    }
}
