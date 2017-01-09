<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="InvoiceDetails.aspx.cs" Inherits="Vendor.UI.InvoiceDetails" Title="Invoice Details" %>

<asp:Content ID="invoiceDetail" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 1726px; width: 1483px">
        <br />
        <asp:Button ID="btnSave" runat="server" Height="29px" OnClick="btnSave_Click" Text="Save"
            Width="72px" />
        &nbsp;&nbsp;
        <asp:Button ID="btnSend" runat="server" Height="29px" Text="Send" Width="72px" OnClick="btnSend_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnList" runat="server" Height="22px" Style="height: 29px; width: 70px"
            Text="List" Width="85px" OnClick="btnList_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="UserName :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
            ID="txtbxUserName" runat="server" Width="157px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPOReference" runat="server" Text="PO Reference :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxPOReference" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblInvoiceReference" runat="server" Text="Invoice Reference :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxInvoiceReference" runat="server" Width="161px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxInvoiceDate" runat="server" Width="162px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btnInvoiceDate"
            runat="server" OnClick="btnInvoiceDate_Click" Text="Date" />
        &nbsp;<asp:Calendar ID="calInvoiceDate" runat="server" BackColor="White" BorderColor="#999999"
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px"
            CellPadding="4" DayNameFormat="Shortest" OnSelectionChanged="calInvoiceDate_SelectionChanged"
            Visible="False">
            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
        </asp:Calendar>
        <br />
        <br />
        <asp:Label ID="lblInvoiceValue" runat="server" Text="Invoice Value :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
            ID="txtbxInvoiceValue" runat="server" Width="160px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblOmniflowReference" runat="server" Text="Omniflow Reference :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtbxOmniflowReference"
            runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblReceiveDate" runat="server" Text="Receive Date :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxReceiveDate" runat="server" Width="155px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReceiveDate" runat="server" OnClick="btnReceiveDate_Click" Text="Date" />
        &nbsp;<asp:Calendar ID="calReceiveDate" runat="server" BackColor="White" BorderColor="#999999"
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px"
            CellPadding="4" DayNameFormat="Shortest" OnSelectionChanged="calReceiveDate_SelectionChanged"
            Visible="False">
            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
        </asp:Calendar>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Payment Due Date :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
            ID="txtbxPaymentdueDate" runat="server" Width="152px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPaymentdueDate" runat="server" OnClick="btnPaymentdueDate_Click"
            Text="Date" />
        <br />
        <asp:Calendar ID="calPaymentdueDate" runat="server" BackColor="White" BorderColor="#999999"
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px"
            CellPadding="4" DayNameFormat="Shortest" OnSelectionChanged="calPaymentdueDate_SelectionChanged"
            Visible="False">
            <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" />
        </asp:Calendar>
        <br />
        <asp:Label ID="lblMissingDocuments" runat="server" Text="Missing Documents :"></asp:Label>
        <br />
        &nbsp;&nbsp;<asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="187px" Width="267px">
            <asp:ListItem>VAT Challan (Mushak -11)</asp:ListItem>
            <asp:ListItem>Tax exception certificate</asp:ListItem>
            <asp:ListItem>Invoice Incomplete</asp:ListItem>
            <asp:ListItem>Purchase order</asp:ListItem>
            <asp:ListItem>Delivery Challan</asp:ListItem>
        </asp:CheckBoxList>
        &nbsp;&nbsp;<br />
        <asp:Label ID="lblStatus" runat="server" Text="Status :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxStatus" runat="server" Width="160px"></asp:TextBox>
    </div>
</asp:Content>
