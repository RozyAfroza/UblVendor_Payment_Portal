<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="InvoiceList.aspx.cs" Inherits="Vendor.UI.InvoiceList" Title="Invoice List" %>

<asp:Content ID="invoiceList" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 511px; width: 1568px">
        <br />
        <asp:Button ID="btnAdd" runat="server" Height="22px" Text="Add" Width="74px" OnClick="btnAdd_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Height="22px" Text="Delete" Width="73px"
            OnClick="btnDelete_Click" />
        <br />
        <asp:GridView ID="gvInvoice" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" Height="370px"
            OnPageIndexChanging="gvInvoice_PageIndexChanging" Width="1558px" OnSorting="gvInvoice_Sorting"
            OnSelectedIndexChanging="gvInvoice_SelectedIndexChanging">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="InvoiceReference" HeaderText="Invoice Reference" SortExpression="Invoice Reference" />
                <asp:BoundField DataField="InvoiceValue" HeaderText="Invoice Value" SortExpression="Invoice Value" />
                <asp:BoundField DataField="POReference" HeaderText="PO Reference" SortExpression="PO Reference" />
                <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" SortExpression="Invoice Date" />
                <asp:BoundField DataField="OmniflowReference" HeaderText="Omniflow Reference" SortExpression="Omniflow Reference" />
                <asp:BoundField DataField="ReceiveDate" HeaderText="Receive Date" SortExpression="Receive Date" />
                <asp:BoundField DataField="PaymentdueDate" HeaderText="Paymentdue Date" SortExpression="Paymentdue Date" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
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
