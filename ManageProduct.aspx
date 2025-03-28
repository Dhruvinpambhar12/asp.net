<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="project1.Admin.ManageProduct" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Manage Products</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Manage Products</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductID" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" 
                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting">
                
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ID" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Product Name">
                        <ItemTemplate>
                            <%# Eval("ProductName") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProductName" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="CategoryID" HeaderText="Category ID" ReadOnly="True" />
                    
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <%# Eval("Price", "{0:C}") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Stock">
                        <ItemTemplate>
                            <%# Eval("Stock") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtStock" runat="server" Text='<%# Bind("Stock") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
