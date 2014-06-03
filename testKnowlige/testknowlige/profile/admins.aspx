<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admins.aspx.cs" Inherits="TestKnowlige.profile.admins" EnableEventValidation="false" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<%@ Register TagName="mail" TagPrefix="uc" Src="~/usercontrol/Message.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Список администраторов</title>
    <link href="../style/general.css" rel="stylesheet" type="text/css" />    
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script> 
    <script src="../js/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="admins" runat="server">
    <div>
    <uc:menu Visible="true" ID="menu" runat="server"/>
    <div class="main">
        <asp:Label ID="AdminsHeader" runat="server" >Администрация сайта</asp:Label>
        <asp:Label ID="MessageError" Visible="false" CssClass="error" runat="server" />
        <table border="0" cellpadding="0" cellspacing="0">
            <asp:Repeater ID="listAdmins" runat="server">
            <HeaderTemplate>
                <tr>
                    <td>Фимилия</td>
                    <td>Имя</td>
                </tr>
            </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("Lastname") %>  </td>
                        <td><%#Eval("FirstName") %></td>
                        <td runat="server" visible="false"><%# Eval("login") %></td>
                        <td> <asp:Button ID="writeMessage" runat="server" Text="Написать" CommandArgument='<%# Eval("login") %>'  OnClick="writeMessage_Click"/></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </div>
    <uc:mail ID="MailMessage" runat="server" Visible="false" />
     <div runat="server" id="sendMessage" class="send" visible ="false">
        <asp:Label ID="goodSend" runat="server">Сообщение успешно отправленно</asp:Label>
    </div>
    </form>    
</body>
</html>
