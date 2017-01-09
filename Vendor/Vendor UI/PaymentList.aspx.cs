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
    public partial class PaymentList : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Payment List";

            if (!IsPostBack)
            {
                LoadData("UserName", "ASC");
                ViewState["sortColumn"] = "UserName";
                ViewState["sortDirection"] = "ASC";
            }
        }
        #region Methods
        private void LoadData(string sortColumn, string sortDirection)
        {
            List<Vendor.BO.Invoice> items = Vendor.BO.Invoice.GetAllData("Send", sortColumn, sortDirection);
            gvPayment.DataSource = items;
            gvPayment.DataBind();
        }
        #endregion

        #region Grid Events
        protected void gvPayment_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("PaymentDetails.aspx?ID=" + gvPayment.Rows[e.NewSelectedIndex].Cells[1].Text);
        }
        protected void gvPayment_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortDirection = string.Empty;
            if (ViewState["sortDirection"] == null)
            {
                sortDirection = " DESC";
                ViewState["sortDirection"] = "DESC";
            }
            else
            {
                if (ViewState["sortDirection"].ToString().ToLower() == "asc")
                {
                    sortDirection = " DESC";
                    ViewState["sortDirection"] = "DESC";
                }
                else
                {
                    sortDirection = " ASC";
                    ViewState["sortDirection"] = "ASC";
                }
            }
            ViewState["sortColumn"] = e.SortExpression;

            LoadData(e.SortExpression, sortDirection);
        }
        protected void gvPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sortColumn = "UserName";
            string sortDirection = "ASC";
            if (ViewState["sortColumn"] != null)
            {
                sortColumn = ViewState["sortColumn"].ToString();
            }
            if (ViewState["sortDirection"] != null)
            {
                sortDirection = ViewState["sortDirection"].ToString();
            }
            gvPayment.PageIndex = e.NewPageIndex;
            LoadData(sortColumn, sortDirection);
        }
        #endregion

        protected void gvPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Button Events
        #endregion



    }
}





    
