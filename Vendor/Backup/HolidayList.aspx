<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="HolidayList.aspx.cs" Inherits="Vendor.UI.HolidayList" Title="Holiday List" %>

<asp:Content ID="holidayList" runat="server" ContentPlaceHolderID="cph">

    <div style="height: 434px; width: 1131px;">
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Height="23px" Onclick="btnAdd_Click" 
            Text="Add" Width="83px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Height="23px" 
            Onclick="btnDelete_Click" Text="Delete" Width="83px" />
        <br />
        <br />
        <br />
        <asp:GridView ID="gvHoliday" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" Height="297px" 
            Onpageindexchanging="gvHoliday_PageIndexChanging" 
            Onselectedindexchanging="gvHoliday_SelectedIndexChanging" 
            Onsorting="gvHoliday_Sorting" PageSize="5" Width="1133px">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" />
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="FromDate" HeaderText="FromDate" SortExpression="FromDate" />
                <asp:BoundField DataField="Todate" HeaderText="Todate" SortExpression="ToDate" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    
    </div>
</asp:Content>



