<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yourTests.aspx.cs" Inherits="TestKnowlige.profile.yourTests" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ваши тесты</title>
    <link href="../../style/general.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../js/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="yourTests" runat="server">
    <div>
    <uc:menu Visible="true" ID="menu" runat="server"/>
    <div class="main">
        <asp:Label Text="Список тестов созданных вами" runat="server" ID="header"/>
        <div class="listTests">
            <asp:Label ID="MesssageError" Visible="false" CssClass="error" runat="server" />
        <asp:Repeater runat="server" ID="listTest">        
            <ItemTemplate>
            <div>
                <asp:Label runat="server" ID="Discipline_name"><%# Eval("discipline_name") %></asp:Label>
                <asp:Label runat="server" ID="Categories_name"><%# Eval("categories_name") %></asp:Label>
                <asp:Label runat="server" ID="test_name"><%# Eval("name") %></asp:Label>
                <asp:HyperLink ID="testRedact" runat="server" NavigateUrl='<%# "~/profile/teacher/TestEdit.aspx?id=" + Eval("test_id") %>'>Редактировать</asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>
    
    </div>
    </form>
</body>
</html>
