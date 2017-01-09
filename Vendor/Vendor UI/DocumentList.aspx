<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="DocumentList.aspx.cs" Inherits="Vendor.UI.DocumentList" Title="Document List" %>

<asp:Content ID="documentList" runat="server" ContentPlaceHolderID="cph">
    <div style="height: 442px; width: 1005px;">
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="83px" 
            OnClick="btnAdd_Click" Height="22px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="82px" 
            OnClick="btnDelete_Click" Height="22px" />
        </br>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;<br />
        <br />
        <asp:GridView ID="gvDocument" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Height="285px" 
            Onselectedindexchanging="gvDocument_SelectedIndexChanging" 
            Onsorting="gvDocument_Sorting" Width="1002px" 
            AllowSorting="True" AllowPaging="True" 
            Onpageindexchanging="gvDocument_PageIndexChanging" PageSize="5">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    SortExpression="Description" />
                <asp:BoundField DataField="IsMendatory" HeaderText="IsMendatory" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
    </div>
</asp:Content>
