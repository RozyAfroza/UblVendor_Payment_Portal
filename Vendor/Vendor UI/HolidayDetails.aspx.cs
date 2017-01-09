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
    public partial class HolidayDetails : System.Web.UI.Page
    {
        #region Variables
        private Label _message;
        private Vendor.BO.Holiday _holiday;
        #endregion

        #region Page Events

        protected void Page_Load(object sender, EventArgs e)
        {
            _message = (Label)Master.FindControl("lblMessage");
            Label header = (Label)Master.FindControl("lblHeader");
            header.Text = "Holiday Detail";

            if (!IsPostBack)
            {
                int id = 0;
                if (Page.Request.QueryString["ID"] != null)
                {
                    id = Convert.ToInt32(Page.Request.QueryString["ID"]);
                }
                ViewState["ID"] = id;

                _holiday = new Vendor.BO.Holiday().GetData(id);

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
            _holiday = new Vendor.BO.Holiday().GetData(id);

            try
            {
                RefreshObject();

                _holiday.Save();

                _message.Text = "Data Saved Successfully";
                _message.CssClass = "MessageSuccess";

                if (id > 0)
                {
                    Response.Redirect("HolidayList.aspx");
                }
                else
                {
                    _holiday = new Vendor.BO.Holiday();
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
            Response.Redirect("HolidayList.aspx");
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("HolidayList.aspx");
        }
        #endregion

        #region Methods
        private void RefreshControl()
        {
            txtbxcode.Text = _holiday.Code;
            txtbxdescription.Text = _holiday.Description;
            calFromDate.SelectedDate = _holiday.FromDate;
            calToDate.SelectedDate = _holiday.ToDate;
        }
        private void RefreshObject()
        {
            _holiday.Code = txtbxcode.Text;
            _holiday.Description = txtbxdescription.Text;
            _holiday.FromDate = calFromDate.SelectedDate;
            _holiday.ToDate = calToDate.SelectedDate;
        }
        #endregion
    }
}
