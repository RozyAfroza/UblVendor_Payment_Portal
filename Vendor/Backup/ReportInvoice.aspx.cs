using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    public partial class ReportInvoice : System.Web.UI.Page
    {
        string str = "Data Source=DELL-PC;uid=VendorUser;pwd=x;database=VendorDB";

        protected void Page_Load(object sender, EventArgs e)
        {
            string command = "SELECT * FROM Vendor";
            SqlDataAdapter adpt = new SqlDataAdapter(command, SQLConnector.Connection);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "UserName";
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataBind();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            SQLConnector con = new SQLConnector();
            SqlCommand command = new SqlCommand("SELECT * FROM [Invoice] where ID = '" + DropDownList1.SelectedValue + "'", SQLConnector.Connection);
            SqlDataAdapter Adpt = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            Adpt.Fill(dt);
            gvReport.DataSource = dt;
            gvReport.DataBind();
            Label1.Text = "Record Found";
        }

         #region Methods
        private void LoadVendor(string sortColumn, string sortDirection)
        {
            List<Vendor.BO.Report> items = Vendor.BO.Report.GetAllData("Entry", sortColumn, sortDirection);
            gvReport.DataSource = items;
            gvReport.DataBind();
        }
        #endregion

        #region Grid Events
        protected void gvReport_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("ReportInvoice.aspx?ID=" + gvReport.Rows[e.NewSelectedIndex].Cells[1].Text);
        }
        protected void gvReport_Sorting(object sender, GridViewSortEventArgs e)
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

            LoadVendor(e.SortExpression, sortDirection);
        }
        protected void gvReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            gvReport.PageIndex = e.NewPageIndex;
            LoadVendor (sortColumn, sortDirection);
        }
        #endregion

        protected void btnFromDate1_Click(object sender, EventArgs e)
        {
            calFromDate1.Visible = true;
        }

        protected void calFromDate1_SelectionChanged(object sender, EventArgs e)
        {
            txtbxFromDate1.Text = calFromDate1.SelectedDate.ToString();
            calFromDate1.Visible = false;
        }

        protected void btnToDate_Click(object sender, EventArgs e)
        {
            calToDate.Visible = true;
        }

        protected void calToDate_SelectionChanged(object sender, EventArgs e)
        {
            txtbxToDate.Text = calToDate.SelectedDate.ToString();
            calToDate.Visible = false;
        }

        protected void ddbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      


    }
}


    