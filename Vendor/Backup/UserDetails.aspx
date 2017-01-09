<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="UserDetails.aspx.cs" Inherits="Vendor.UI.UserDetails" Title="User Details" %>

<asp:Content ID="userDetail" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 786px">
        <br />
        <asp:Button ID="btnSave" runat="server" OnClick="btnsave_Click" Text="Save" Width="63px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" OnClick="btncancel_Click" Text="Cancel" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnList" runat="server" OnClick="btnlist_Click" Text="List" Width="75px" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lblUserName" runat="server" Text="UserName :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxUserName" runat="server" Width="236px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblUserID" runat="server" Text="UserID :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxUserID" runat="server" Width="235px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxPassword" runat="server" TextMode="Password" Width="230px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblIsAdmin" runat="server" Text="IsAdmin :"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chckbxIsAdmin" runat="server" />
        <br />
        <br />
        <asp:Label ID="lblIsOperator" runat="server" Text="IsOperator :"></asp:Label>
        &nbsp;&nbsp;
        <asp:CheckBox ID="chckbxIsOperator" runat="server" />
    </div>
</asp:Content>
