<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tests.aspx.cs" Inherits="TestKnowlige.profile.Tests" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Пройденные тесты</title>
    <link href="../style/general.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="tests" runat="server">
    <div>
    <uc:menu Visible="true" ID="menu" runat="server"/>
    <div class="main">
        <asp:Label ID="lblHeader" runat="server" >Ваши пройденные тесты</asp:Label>        
        <asp:Label ID="MessageError" Visible="false" CssClass="error" runat="server" />
        <asp:GridView ID="ListTests" runat="server" GridLines="None" AutoGenerateColumns="False">
        <Columns>
                <asp:BoundField DataField="Discipline_name" HeaderText="Дисциплина" />
                <asp:BoundField DataField="Categories_name" HeaderText="Категория" />
                <asp:BoundField DataField="name" HeaderText="Название" />
                <asp:BoundField DataField="points" HeaderText="Баллы" />
                <asp:BoundField DataField="dateComplite" HeaderText="Дата" />
         </Columns>        
        <AlternatingRowStyle BackColor="#f2f2f2"/>
        </asp:GridView>    
    </div>
    </div>
    </form>
</body>
</html>
