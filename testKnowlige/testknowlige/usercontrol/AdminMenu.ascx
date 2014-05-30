<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.ascx.cs" Inherits="TestKnowlige.usercontrol.AdminMenu" %>
 <div class="menu" runat="server" id="listMenu">
        <ul>
            <li>
                <asp:HyperLink ID="Home" runat="server" NavigateUrl="~/default.aspx">На главную</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="common" runat="server" NavigateUrl="~/profile/general.aspx">Ваш профиль</asp:HyperLink>
                </li>                        
            <li>
                <asp:HyperLink ID="discipline" runat="server" NavigateUrl="~/administration/Disciplines.aspx">Дисциплины</asp:HyperLink>    
                </li>                    
            <li>
                <asp:HyperLink ID="categories" runat="server" NavigateUrl="~/administration/Categories.aspx">Категории</asp:HyperLink>
                </li>            
            <li>
                <asp:HyperLink ID="test" runat="server" NavigateUrl="~/administration/Tests.aspx">Тесты</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="users" runat="server" NavigateUrl="~/administration/Users.aspx">Пользователи</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="newAdmin" runat="server" NavigateUrl="~/administration/WaitUsers.aspx">Ожидающие ответа</asp:HyperLink>
                </li>    
        </ul>
    </div>