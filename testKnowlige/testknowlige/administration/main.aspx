<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TestKnowlige.administration.main" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/AdminMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Главная страница администратора</title>
    <link rel="Stylesheet" type="text/css" href="../style/admins.css" />
</head>
<body>
    <form id="Main" runat="server">    
    <div>
        <uc:menu ID="AdminMenu" runat="server" />
        <div class="main">
            <asp:Label Text="Добро пожаловать на страничку администрирования" runat="server" />
        </div>    
    </div>    
    </form>
</body>
</html>
