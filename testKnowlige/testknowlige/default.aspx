<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TestKnowlige._default" %>
<%@ Register TagName="addItem" TagPrefix="uc" Src="~/usercontrol/AddDicciplineOrCaregories.ascx" %>
<%@ Register TagName="errorMes" TagPrefix="uc" Src="~/usercontrol/MyMessageError.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="Stylesheet" type="text/css" href="style/style.css" />
<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/script.js"></script>
<title>Главная страница</title>
</head>
<body>
    <form id="main" runat="server" class="main">
    <div class="over_header">
        <asp:HyperLink ID="lnkChangePass" runat="server" Visible="false" NavigateUrl="~/login/ChangePassword.aspx">Change password</asp:HyperLink>
        <asp:HyperLink ID="register" runat="server" Visible="true" CssClass="LogStat" NavigateUrl="~/login/CreateLogin.aspx">Зарегистрироваться</asp:HyperLink>
        <asp:LoginName ID="LogName" runat="server" FormatString="Welcome, {0}" />                
        <asp:LoginStatus ID="LogStat" runat="server" CssClass="LogStat"/>        
    </div>
    <div class="header">
        <asp:Image ID="header_left" AlternateText="header_left" ImageUrl="img/test_tehno.png" runat="server" />
        <p>Добро пожаловать на сайт проверки знаний</p>
        <asp:Image ID="header_right" AlternateText="header_right" ImageUrl="img/voprosy.png" runat="server" />         
    </div>
    <div class="bod">
        <h2>Выбирете интересующий вас тест</h2>
        <div class="test">
    	    <div class="head">
        	    <div class="act_div">
                    Дисциплина
                </div>
                <div>
                    Категория
                </div>                
                <div>
                    Тесты
                </div>
                <asp:ImageButton ID="addDoC" AlternateText="addDis" Visible="false" CssClass="add" ImageUrl="~/img/plus.png" runat="server" OnClick="addDoC_Click"/>                
                <asp:ImageButton ID="addCat" AlternateText="addCat" Visible="false" CssClass="add" ImageUrl="~/img/plus.png" runat="server" OnClick="addDoC_Click"/>                
                <asp:ImageButton ID="addTest" AlternateText="addTest" Visible="true" CssClass="add" ImageUrl="~/img/plus.png" runat="server" OnClick="addDoC_Click"/>                
            </div>
        <div class="body_div">            
            <div class="Discipline">
                <asp:Repeater ID="DirDiscipline" runat="server" DataSourceID="">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkDiscipline" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "discipline_name", "~/default.aspx?discipline={0}") %>'><%# Eval("discipline_name")%></asp:HyperLink>
                    </ItemTemplate>                          
                </asp:Repeater>          
                <asp:Label ID="errDis" Visible="false" runat="server">No records</asp:Label>
            </div>
            <div class="Categories">
                <asp:Label ID="categories_header" runat="server"></asp:Label>
                <asp:Repeater ID="DirCategories" runat="server" DataSourceID="">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkCategories" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "categories_name", "~/default.aspx?discipline="+Request.QueryString["Discipline"]+"&categories={0}") %>'><%# Eval("categories_name")%></asp:HyperLink>
                    </ItemTemplate>                          
                </asp:Repeater>          
                <asp:Label ID="SelectDiscipline" Visible="false" runat="server">Выберите дисциплину</asp:Label>
                <asp:Label ID="errCat" Visible="false" runat="server">Нет записей</asp:Label>
            </div>
            <div class="Tests">
                <asp:Repeater ID="DirTests" runat="server" DataSourceID="">
                    <ItemTemplate>
                        <asp:HyperLink ID="linkTests" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "test_id", "~/test.aspx?id={0}") %>'>Тест №<%# DirTests.Items.Count+1 %></asp:HyperLink>
                    </ItemTemplate>                          
                </asp:Repeater>
                <asp:Label ID="selectCategories" Visible="false" runat="server">Выберите дисциплину и категорию</asp:Label>
                <asp:Label ID="errTests" Visible="false" runat="server">Нет записей</asp:Label>                
            </div>
        </div>        
    </div>    
    </div>
    <div class="footer">
        <asp:HyperLink id="Discipline" runat="server" NavigateUrl="~/Discipline.aspx">Выбор дисциплины</asp:HyperLink>
    </div>
    <uc:addItem ID="addNewItem" runat="server" Visible="false" />
    <uc:errorMes ID="ErrorMes" runat="server" Visible="false" />
    </form>
</body>
</html>
