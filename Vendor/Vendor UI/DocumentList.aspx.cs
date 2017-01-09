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
    public partial class DocumentList : System.Web.UI.Page
       {
        #region Variables
        private Label _message;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Document List";

            if (!IsPostBack)
            {
                LoadData("Description", "ASC");
                ViewState["sortColumn"] = "Description";
                ViewState["sortDirection"] = "ASC";
            }
        }

        #region Methods
        private void LoadData(string sortColumn, string sortDirection)
        {
            List<Vendor.BO.Document> items = Vendor.BO.Document.GetAllData(sortColumn, sortDirection);
            gvDocument.DataSource = items;
            gvDocument.DataBind();
        }
        #endregion
        
        #region Grid Events
        protected void gvDocument_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("DocumentDetails.aspx?ID=" + gvDocument.Rows[e.NewSelectedIndex].Cells[1].Text);
        }
        protected void gvDocument_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string sortColumn = "Description";
            string sortDirection = "ASC";
            if (ViewState["sortColumn"] != null)
            {
                sortColumn = ViewState["sortColumn"].ToString();
            }
            if (ViewState["sortDirection"] != null)
            {
                sortDirection = ViewState["sortDirection"].ToString();
            }
            gvDocument.PageIndex = e.NewPageIndex;
            
            LoadData(sortColumn, sortDirection);
        }
        #endregion 
     
        
        #region Button Events
        protected void gvDocument_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("DocumentList.aspx");
        }

        protected void gvDocument_Sorting(object sender, GridViewSortEventArgs e)
        {
            Response.Redirect("DocumentList.aspx");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentDetails.aspx");

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentList.aspx");
            //gvDocument gc;
            //gvDocument.TemplateControl.FindControl("chkSelectH");

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();
            string id = string.Empty;

            for (int i = 0; i < gvDocument.Rows.Count; i++)//loop the GridView Rows
            {
                CheckBox cb = (CheckBox)gvDocument.Rows[i].Cells[0].FindControl("chkSelect"); //find the CheckBox
                if (cb != null)
                {
                    if (cb.Checked)
                    {
                        id = gvDocument.Rows[i].Cells[1].Text;
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
                    new Vendor.BO.Document().Delete(Convert.ToInt32(nid));
                }
                //SQLConnector.CommitTransaction();
                _message.Text = "Data successfully deleted.";
                
                //LoadData("Description", "ASC");
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
