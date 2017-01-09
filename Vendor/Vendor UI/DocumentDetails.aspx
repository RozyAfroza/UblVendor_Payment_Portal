<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="DocumentDetails.aspx.cs" Inherits="Vendor.UI.DocumentDetails" Title="DocumentDetails" %>

<asp:Content ID="documentDetail" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 478px">
        <br />
        <asp:Button ID="btnSave" runat="server" Height="23px" Text="Save" Width="83px" OnClick="btnSave_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Height="23px" Text="Cencel" Width="85px"
            OnClick="btnCancel_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnList" runat="server" Height="23px" Text="List" Width="83px" OnClick="btnList_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="lbldescription" runat="server" Text="Description"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxdescription" runat="server" Height="41px" Width="303px" BorderColor="#0066FF"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblismendatory" runat="server" Text="Is Mendatory"></asp:Label>
        &nbsp;<asp:CheckBox ID="chkbxismendatory" runat="server" BorderColor="#0066FF" />
    </div>
</asp:Content>
