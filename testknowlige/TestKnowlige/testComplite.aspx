<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testComplite.aspx.cs" Inherits="TestKnowlige.testComplite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="style/test.css" />
</head>
<body>
    <form id="testComplite" runat="server">
     <div>
        <div class="header">
            <asp:Image AlternateText="" ID="img_header" ImageUrl="~/img/tests.jpg" runat="server"/>
            <asp:Label ID="header_discipline" runat="server" CssClass=""></asp:Label>
            <asp:Label ID="header_categories" runat="server" CssClass=""></asp:Label>
            <asp:Label ID="header_test" runat="server" CssClass=""></asp:Label>
        </div>            
    <asp:Button ID="Complite" Text="Завершить" runat="server"/>   
    </div>    
    </form>
</body>
</html>
