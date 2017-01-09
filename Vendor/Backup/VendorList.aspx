<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="VendorList.aspx.cs" Inherits="Vendor.UI.VendorList" Title="Vendor List" %>

<asp:Content ID="vendorList" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 862px; width: 1236px;">
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="83px" OnClick="btnAdd_Click"
            Height="43px" />
        &nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="83px" OnClick="btnDelete_Click"
            Height="41px" />
        &nbsp;<br />
        <br />
        <asp:GridView ID="gvVendor" runat="server" AutoGenerateColumns="False" Height="45px"
            Width="1236px" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True"
            AllowSorting="True" OnPageIndexChanging="gvVendor_PageIndexChanging" OnSorting="gvVendor_Sorting"
            OnSelectedIndexChanging="gvVendor_SelectedIndexChanging" PageSize="22" Style="margin-right: 153px">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID">
                    <HeaderStyle CssClass="ColHide" />
                    <ItemStyle CssClass="ColHide" />
                </asp:BoundField>
                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" />
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="ContactNo" HeaderText="Contact No" SortExpression="ContactNo" />
                <asp:BoundField DataField="PaymentTerm" HeaderText="Payment Term" SortExpression="PaymentTerm" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <br />
    </div>
</asp:Content>
