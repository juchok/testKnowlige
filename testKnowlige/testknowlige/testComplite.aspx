<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testComplite.aspx.cs" Inherits="TestKnowlige.testComplite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="style/testComplite.css" />
</head>
<body>
    <form id="testComplite" runat="server">
     <div>
        <div class="header" id="header">
            <asp:Image AlternateText="" ID="img_header" ImageUrl="~/img/tests.jpg" runat="server"/>
            <asp:Label ID="header_discipline" runat="server" CssClass=""></asp:Label>
            <asp:Label ID="header_categories" runat="server" CssClass=""></asp:Label>
            <asp:Label ID="header_test" runat="server" CssClass=""></asp:Label>
        </div>            
        <asp:Repeater ID="bodyAnswers" runat="server">
        </asp:Repeater>
         <asp:Label runat="server" ID="MessageError" Visible="false" CssClass="error"/>
        <asp:HyperLink ID="home" runat="server" NavigateUrl="~/default.aspx">На главную</asp:HyperLink>
    </div>    
    </form>
    
</body>
</html>
