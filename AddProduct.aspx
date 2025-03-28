<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="project1.AddProduct" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Add Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add New Product</h2>
            
            <asp:TextBox ID="txtProductName" runat="server" placeholder="Enter Product Name"></asp:TextBox>
            <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtPrice" runat="server" placeholder="Enter Price"></asp:TextBox>
            <asp:TextBox ID="txtStock" runat="server" placeholder="Enter Stock Quantity"></asp:TextBox>
            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="InsertProduct" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

            <h3>Product List</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>