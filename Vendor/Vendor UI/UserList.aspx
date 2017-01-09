<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="UserList.aspx.cs" Inherits="Vendor.UI.UserList" Title="User List" %>

<asp:Content ID="userList" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 721px; width: 1360px">
        <br />
        <asp:Button ID="btn1ADD" runat="server" OnClick="btn1ADD_Click" Text="ADD" Width="82px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn1DELETE" runat="server" OnClick="btn1DELETE_Click" Text="DELETE"
            Width="86px" />
        &nbsp;<br />
        <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="185px" OnPageIndexChanging="gvUser_PageIndexChanging"
            PageSize="20" Width="1358px" OnSelectedIndexChanging="gvUser_SelectedIndexChanging"
            OnSorting="gvUser_Sorting">
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
                <asp:BoundField DataField="UserID" HeaderText="UserID" SortExpression="UserID" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                <asp:TemplateField HeaderText="IsAdmin">
                    <ItemTemplate>
                        <asp:CheckBox ID="chckbxIsAdmin" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="IsOperator">
                    <ItemTemplate>
                        <asp:CheckBox ID="chckbxIsOperator" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
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
