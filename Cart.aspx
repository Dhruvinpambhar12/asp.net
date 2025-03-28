<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="project1.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
    <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button runat="server" Text="Remove" CommandName="RemoveItem" CommandArgument='<%# Eval("ProductID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<asp:Button runat="server" ID="btnCheckout" Text="Proceed to Checkout" OnClick="btnCheckout_Click" />

        </div>
    </form>
</body>
</html>
