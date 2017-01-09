<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="ReportInvoice.aspx.cs" Inherits="Vendor.UI.ReportInvoice" Title="Report Invoice" %>

<asp:Content ID="reportInvoice" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 305px">
        <asp:Panel ID="Panel1" runat="server" Height="189px" Width="1061px">
            <asp:Label ID="lblFromDate1" runat="server" Text="FromDate1"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtbxFromDate1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnFromDate1" runat="server" OnClick="btnFromDate1_Click" Text="Date" />
            &nbsp;
            <asp:Calendar ID="calFromDate1" runat="server" BackColor="White" BorderColor="#999999"
                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="Black" Height="180px" Visible="False" OnSelectionChanged="calFromDate1_SelectionChanged">
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BackColor="#FFFFCC" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            </asp:Calendar>
            <br />
            <asp:Label ID="lblToDate" runat="server" Text="ToDate"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtbxToDate" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:Button ID="btnToDate" runat="server" OnClick="btnToDate_Click" Text="Date" />
            &nbsp;
            <br />
            <br />
            <asp:Calendar ID="calToDate" runat="server" BackColor="White" BorderColor="#999999"
                CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                ForeColor="Black" Height="180px" OnSelectionChanged="calToDate_SelectionChanged"
                Visible="False" Width="200px">
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <WeekendDayStyle BackColor="#FFFFCC" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            </asp:Calendar>
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList
                ID="ddbStatus" runat="server" Height="16px" OnSelectedIndexChanged="ddbStatus_SelectedIndexChanged"
                Width="493px">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>Paid</asp:ListItem>
                <asp:ListItem>Reject</asp:ListItem>
                <asp:ListItem>Send</asp:ListItem>
                <asp:ListItem>Entry</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server"
                Height="16px" Width="497px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            &nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                ID="btnSelect" runat="server" Height="25px" OnClick="btnSelect_Click" Style="height: 26px"
                Text="Select" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
        <br />
        <br />
        <asp:GridView ID="gvReport" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
            OnSelectedIndexChanging="gvReport_SelectedIndexChanging" OnSorting="gvReport_Sorting"
            PageSize="20">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelectH" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                <asp:BoundField DataField="InvoiceReference" HeaderText="Invoice Reference" SortExpression="Invoice Reference" />
                <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date" SortExpression="Invoice Date" />
                <asp:BoundField DataField="POReference" HeaderText="PO Reference" SortExpression="PO Reference" />
                <asp:BoundField DataField="InvoiceValue" HeaderText="Invoice Value" SortExpression="Invoice Value" />
                <asp:BoundField DataField="OmniflowReference" HeaderText="Omniflow Reference" SortExpression="Omniflow Reference" />
                <asp:BoundField DataField="ReceiveDate" HeaderText="Receive Date" SortExpression="Receive Date" />
                <asp:BoundField DataField="PaymentTerm" HeaderText="Payment Term" SortExpression="Payment Term" />
                <asp:BoundField DataField="PaymentdueDate" HeaderText="Paymentdue Date" SortExpression="Paymentdue Date" />
                <asp:BoundField DataField="PaymentDate" HeaderText="Payment Date" SortExpression="Payment Date" />
                <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount" SortExpression="Paid Amount" />
                <asp:BoundField DataField="TaxDeduction" HeaderText="Tax Deduction" SortExpression="Tax Deduction" />
                <asp:BoundField DataField="VatDeduction" HeaderText="Vat Deduction" SortExpression="Vat Deduction" />
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
