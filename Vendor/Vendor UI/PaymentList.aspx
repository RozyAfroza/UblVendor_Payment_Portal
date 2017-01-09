<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="PaymentList.aspx.cs" Inherits="Vendor.UI.PaymentList" Title="Payment List" %>

<asp:Content ID="paymentList" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 367px">
        <asp:GridView ID="gvPayment" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
            OnPageIndexChanging="gvPayment_PageIndexChanging" OnSelectedIndexChanging="gvPayment_SelectedIndexChanging"
            OnSorting="gvPayment_Sorting" Width="1277px" 
            onselectedindexchanged="gvPayment_SelectedIndexChanged">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="InvoiceReference" HeaderText="Invoice Reference" 
                    SortExpression="Invoice Reference" />
                <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" SortExpression="Invoice Date" />
                <asp:BoundField DataField="POReference" HeaderText="PO Reference" SortExpression="PO Reference" />
                <asp:BoundField DataField="InvoiceValue" HeaderText="Invoice Value" SortExpression="Invoice Value" />
                <asp:BoundField DataField="OmniflowReference" HeaderText="Omniflow Reference" 
                    SortExpression="Omniflow Reference" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
</asp:Content>
