<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="project1.Admin.AdminDashboard" %>

<!DOCTYPE html>
<html>
<head>
    <title>Admin Dashboard</title>
    <style>
        .dashboard {
            text-align: center;
            margin-top: 50px;
        }
        .dashboard h1 {
            font-size: 24px;
            margin-bottom: 20px;
        }
        .dashboard a {
            display: block;
            width: 250px;
            padding: 15px;
            margin: 10px auto;
            font-size: 18px;
            text-decoration: none;
            background-color: #007bff;
            color: white;
            text-align: center;
            border-radius: 5px;
        }
        .dashboard a:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="dashboard">
            <h1>Admin Dashboard</h1>
            <a href="AddCategory.aspx">Add Categories</a>
            <a href="ManageProduct.aspx">Manage Products</a>
            <a href="ManageOrders.aspx">Manage Orders</a>
            <a href="AddProduct.aspx">Add Product</a>
        </div>
    </form>
</body>
</html>
