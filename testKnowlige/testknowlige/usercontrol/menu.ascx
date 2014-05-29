<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="menu.ascx.cs" Inherits="TestKnowlige.usercontrol.menu" %>
 <div class="menu" runat="server" id="listMenu">
        <ul>
            <li>
                <asp:HyperLink ID="common" runat="server" NavigateUrl="~/profile/general.aspx">Общая</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="more" runat="server" NavigateUrl="~/profile/more.aspx">Дополнительная</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="test" runat="server" NavigateUrl="~/profile/Tests.aspx">Тесты</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="message" runat="server" NavigateUrl="~/profile/mail.aspx">Почта</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="ChangePassword" runat="server" NavigateUrl="~/profile/ChangePassword.aspx">Изменить пароль</asp:HyperLink>    
                </li>                    
            <li>
                <asp:HyperLink ID="admins" runat="server" NavigateUrl="~/profile/admins.aspx">Админы</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="yourtests" runat="server" NavigateUrl="~/profile/Teacher/yourTests.aspx">Ваши тесты</asp:HyperLink>
                </li>
            <li>
                <asp:HyperLink ID="administration" runat="server" NavigateUrl="~/administration/main.aspx">Администрирование</asp:HyperLink>
                </li>    
        </ul>
    </div>