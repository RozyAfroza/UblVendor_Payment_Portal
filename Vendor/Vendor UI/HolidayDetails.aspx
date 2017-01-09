<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="HolidayDetails.aspx.cs" Inherits="Vendor.UI.HolidayDetails" Title="Holiday Details" %>

<asp:Content ID="holidayDetail" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 919px; width: 945px;">
    
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Onclick="btnSave_Click" Text="Save" 
            Width="60px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Onclick="btnCancel_Click" 
            Text="Cancel" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnList" runat="server" Onclick="btnList_Click" Text="List" 
            Width="73px" />
        <br />
        <br />
        <br />
    
        <br />
        <asp:Label ID="lblCode" runat="server" Text="Code"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtbxcode" runat="server" Height="39px" Width="298px" 
            BorderColor="#0066FF"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
            ID="lbldescription" runat="server" Text="Description"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:TextBox 
            ID="txtbxdescription" runat="server" Width="298px" BorderColor="#0066FF" 
            Height="43px"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lbltodate" runat="server" Text="ToDate"></asp:Label>
        &nbsp;<asp:Calendar ID="calFromDate" 
            runat="server" BackColor="White" BorderColor="#999999" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            Height="180px" Width="200px" CellPadding="4" DayNameFormat="Shortest">
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
        <asp:Label ID="lblfromdate" runat="server" Text="FromDate"></asp:Label>
        <br />
        <br />
        <asp:Calendar ID="calToDate" runat="server" Height="180px" Width="200px" 
            BackColor="White" BorderColor="#999999" 
            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" CellPadding="4" 
            DayNameFormat="Shortest">
    <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
            <SelectorStyle BackColor="#CCCCCC" />
            <WeekendDayStyle BackColor="#FFFFCC" />
    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
    <OtherMonthDayStyle ForeColor="#808080" />
    <NextPrevStyle VerticalAlign="Bottom" />
    <DayHeaderStyle Font-Bold="True" Font-Size="7pt" BackColor="#CCCCCC" />
    <TitleStyle BackColor="#999999" Font-Bold="True" BorderColor="Black" /></asp:Calendar>
        <br />
        <br />
        <br />
        <br />
    
    </div>
  </asp:Content>
