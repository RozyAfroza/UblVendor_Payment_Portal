<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="VendorDetails.aspx.cs" Inherits="Vendor.UI.VendorDetails" Title="Vendor List" %>

<asp:Content ID="vendorDetail" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 455px; width: 1008px">
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="29px" Width="196px">
            &nbsp;<asp:Button ID="btnsave" runat="server" ForeColor="Blue" Height="23px" Text="Save"
                Width="84px" OnClick="btnsave_Click" />
            &nbsp; &nbsp;
            <asp:Button ID="btnlist" runat="server" Height="25px" Text="List" Width="87px" OnClick="btnlist_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:Panel>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;
        <br />
        <asp:Label ID="lblcode" runat="server" Text="Code :" BorderStyle="None"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxcode" runat="server" Height="30px" Width="206px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
            ID="lblUserName" runat="server" Text="UserName :" BorderStyle="None"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtbxUserName" runat="server" Height="33px" Width="292px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblemail" runat="server" Text="Email :" BorderStyle="None"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxemail" runat="server" Height="30px" Width="205px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
            ID="lblcontactno" runat="server" Text="Contact No :" BorderStyle="None"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtbxcontactno" runat="server" Height="34px" Width="291px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblbnkname" runat="server" Text="Bank Name :" BorderStyle="None"></asp:Label>
        &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxbankname" runat="server" Height="30px" Width="205px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
            ID="lblaccountno" runat="server" Text="Account No :" BorderStyle="None"></asp:Label>
        &nbsp;<asp:TextBox ID="txtbxaccountno" runat="server" Height="30px" Width="294px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbladdress" runat="server" Text="Address :" BorderStyle="None"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtbxaddress" runat="server" Height="52px" Width="659px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblpaymenttrm" runat="server" Text="Payment Term" BorderStyle="None"
            Height="20px" Width="113px"></asp:Label>
        &nbsp;<asp:TextBox ID="txtbxpaymentterm" runat="server" Height="30px" Width="201px"></asp:TextBox>
        &nbsp;<asp:RangeValidator ID="rvPaymentTerm" runat="server" ControlToValidate="txtbxpaymentterm"
            ErrorMessage="Payment Term invalid (number only)" MaximumValue="100" MinimumValue="1"
            SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
        &nbsp;<asp:Label ID="lblisactive" runat="server" Text="Is Active :" BorderStyle="None"
            Height="30px" Width="151px"></asp:Label>
        <asp:CheckBox ID="chkbxisactive" runat="server" OnCheckedChanged="chkbxisactive_CheckedChanged" />
        <br />
        &nbsp;&nbsp;
        <br />
    </div>
</asp:Content>
