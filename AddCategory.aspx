<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="project1.Admin.AddCategory" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Add Category</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Add New Category</h2>
            <asp:TextBox ID="txtCategory" runat="server" placeholder="Enter Category Name"></asp:TextBox>
            <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="InsertCategory" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>

            <h3>Existing Categories</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CategoryID">
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="ID" />
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>