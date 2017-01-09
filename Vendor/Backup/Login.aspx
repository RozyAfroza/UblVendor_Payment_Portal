<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vendor.UI.Login"
    Title="Log In" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login to Vendor Payment Portal</title>
    <link href="../App_Themes/CSS/Controls.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 417px;
            height: 341px;
            margin-left: 0px;
        }
        .style6
        {
            width: 122px;
            height: 75px;
        }
        .style7
        {
            width: 307px;
            height: 75px;
        }
        .style11
        {
            height: 115px;
        }
        .style14
        {
            width: 122px;
            height: 73px;
        }
        .style15
        {
            width: 307px;
            height: 73px;
        }
        .style16
        {
            width: 122px;
            height: 70px;
        }
        .style17
        {
            width: 307px;
            height: 70px;
        }
        #form2
        {
            height: 781px;
            width: 1257px;
            margin-left: 0px;
        }
        .style18
        {
            width: 99px;
        }
    </style>
</head>
<body class="BackgroundLogin">
    <form id="form2" runat="server">
    <img src="Image%20All/UBL%20Vendor%20Payment%20Portal%20Theme1.jpg" style="width: 1342px;
        height: 199px" /><asp:Image ID="Image1" runat="server" />
    <div align="center" style="width: 1075px; height: 419px; margin-left: 181px;">
        <br />
        <asp:Login ID="Login2" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderPadding="4"
            BorderStyle="Solid" BorderWidth="4px" Font-Names="Verdana" Font-Size="0.8em"
            ForeColor="#333333" Height="212px" Width="345px">
            <TextBoxStyle Font-Size="0.8em" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
                Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
            <LayoutTemplate>
                <table border="0" cellpadding="4" cellspacing="0" style="border-collapse: collapse;">
                    <tr>
                        <td align="right">
                            <table border="0" cellpadding="0" style="width: 399px; height: 196px">
                                <tr>
                                    <td align="justify" colspan="2" style="color: White; background-color: #5D7B9D; font-size: 0.9em;
                                        font-weight: bold;">
                                        Log In
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style18">
                                        <asp:Label ID="lblUserID" runat="server" AssociatedControlID="lblMsg">User ID:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtbxUserID" runat="server" Font-Size="0.8em" Height="29px" Width="280px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                            ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login2">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="style18">
                                        &nbsp;<asp:Label ID="lblPassword" runat="server" AssociatedControlID="lblMsg">Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ixtbxPassword" runat="server" Font-Size="0.8em" Height="30px" TextMode="Password"
                                            Width="278px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login2">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Label ID="lblMsg" runat="server" EnableViewState="False" SkinID="LabelRequired"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSignin" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                            BorderStyle="Solid" BorderWidth="1px" CommandName="Login" Font-Names="Verdana"
                                            Font-Size="Small" ForeColor="#284775" Height="24px" OnClick="btnSignin_Click"
                                            SkinID="DefaultButton" Text="Log In" ValidationGroup="Login2" Width="77px" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                            BorderStyle="Solid" BorderWidth="1px" CommandName="Cancel" Font-Size="Small"
                                            ForeColor="#284775" Height="25px" OnClick="btnCancel_Click" SkinID="DefaultButton"
                                            Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
    </div>
    </form>
</body>
</html>
