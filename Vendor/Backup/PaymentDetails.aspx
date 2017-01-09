<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="PaymentDetails.aspx.cs" Inherits="Vendor.UI.PaymentDetails" Title="Payment Details" %>

<asp:Content ID="paymentDetail" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 1726px; width: 1483px">
        <br />
        <asp:Button ID="btnPaid" runat="server" Height="29px" OnClick="btnPaid_Click" Text="Paid"
            Width="70px" />
        &nbsp;&nbsp;
        <asp:Button ID="btnReject" runat="server" Height="29px" Text="Reject" Width="66px"
            OnClick="btnReject_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnList" runat="server" Height="38px" Style="height: 29px; width: 70px"
            Text="List" Width="88px" OnClick="btnList_Click" />
        &nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxUserName" runat="server" Width="172px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lblInvoiceReference" runat="server" Text="Invoice Reference"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtbxInvoiceReference" runat="server" 
            Width="171px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<asp:TextBox ID="txtbxInvoiceDate" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnInvoiceDate" runat="server"
            OnClick="btnInvoiceDate_Click" Text="Date" />
        &nbsp;&nbsp;
        <asp:Calendar ID="calInvoiceDate" runat="server" BackColor="White" BorderColor="#999999"
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
        <asp:Label ID="lblPOReference" runat="server" Text="PO Reference"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxPOReference" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblInvoiceValue" runat="server" Text="Invoice Value"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox
            ID="txtbxInvoiceValue" runat="server" Width="169px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="lblOmniflowreference" runat="server" Text="Omniflow Reference"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxOmniflowReference" runat="server" Width="168px"></asp:TextBox>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
</asp:Content>
