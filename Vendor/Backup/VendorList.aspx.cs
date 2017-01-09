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
    public partial class VendorList : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Vendor List";

            if (!IsPostBack)
            {
                LoadData("Code", "ASC");
                ViewState["sortColumn"] = "Code";
                ViewState["sortDirection"] = "ASC";
            }
        }

        #region Methods
        private void LoadData(string sortColumn, string sortDirection)
        {
            List<Vendor.BO.Vendor> items = Vendor.BO.Vendor.GetAllData(sortColumn, sortDirection);
            gvVendor.DataSource = items;
            gvVendor.DataBind();
        }
        #endregion

        #region Grid Events
        protected void gvVendor_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("VendorDetails.aspx?ID=" + gvVendor.Rows[e.NewSelectedIndex].Cells[1].Text);
        }
        protected void gvVendor_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvVendor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sortColumn = "Code";
            string sortDirection = "ASC";
            if (ViewState["sortColumn"] != null)
            {
                sortColumn = ViewState["sortColumn"].ToString();
            }
            if (ViewState["sortDirection"] != null)
            {
                sortDirection = ViewState["sortDirection"].ToString();
            }
            gvVendor.PageIndex = e.NewPageIndex;
            LoadData(sortColumn, sortDirection);
        }
        #endregion

        #region Button Events
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendorDetails.aspx");
            //gvVendor gc;
            //gvVendor.TemplateControl.FindControl("chkSelectH");

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            string id = string.Empty;

            for (int i = 0; i < gvVendor.Rows.Count; i++)//loop the GridView Rows
            {
                CheckBox cb = (CheckBox)gvVendor.Rows[i].Cells[0].FindControl("chkSelect"); //find the CheckBox
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        id = gvVendor.Rows[i].Cells[1].Text;
                        sc.Add(id); // Adding id is to be deleted in the StringCollection
                    }
                }
            }
            if (sc.Count == 0)
            {
                _message.Text = "No item is selected.";
                return;
            }

            try
            {
                ////SQLConnector.BeginTransaction(); 
                foreach (string nid in sc)
                {
                    new Vendor.BO.Vendor().Delete(Convert.ToInt32(nid));
                }
                //SQLConnector.CommitTransaction();
                _message.Text = "Data successfully deleted.";
                
                //LoadData("Code", "ASC");
                LoadData(ViewState["sortColumn"].ToString(), ViewState["sortDirection"].ToString());
            }
            catch (Exception exp)
            {
                _message.Text = exp.Message;
            }
        }
        #endregion

    
    }
}

