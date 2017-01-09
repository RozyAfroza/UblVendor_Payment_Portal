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
    public partial class UserList : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "User List";

            if (!IsPostBack)
            {
                LoadData("UserName", "ASC");
                ViewState["sortColumn"] = "UserID";
                ViewState["sortDirection"] = "ASC";
            }
        }

        #region Methods
        private void LoadData(string sortColumn, string sortDirection)
        {
            List<Vendor.BO.User> items = Vendor.BO.User.GetAllData(sortColumn, sortDirection);
            gvUser.DataSource = items;
            gvUser.DataBind();
        }
        #endregion

        #region Grid Events
        protected void gvUser_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("UserDetails.aspx?ID=" + gvUser.Rows[e.NewSelectedIndex].Cells[1].Text);
        }
        protected void gvUser_Sorting(object sender, GridViewSortEventArgs e)
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
        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            gvUser.PageIndex = e.NewPageIndex;
            LoadData(sortColumn, sortDirection);
        }
        #endregion

        #region Button Events
        protected void btn1ADD_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx");
            //gvUser gc;
            //gvUser.TemplateControl.FindControl("chkSelectH");

        }
        protected void btn1DELETE_Click(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            string id = string.Empty;

            for (int i = 0; i < gvUser.Rows.Count; i++)//loop the GridView Rows
            {
                CheckBox cb = (CheckBox)gvUser.Rows[i].Cells[0].FindControl("chkSelect"); //find the CheckBox
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        id = gvUser.Rows[i].Cells[1].Text;
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
                    new Vendor.BO.User().Delete(Convert.ToInt32(nid));
                }
                //SQLConnector.CommitTransaction();
                _message.Text = "Data successfully deleted.";

                //LoadData("UserName", "ASC");
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


