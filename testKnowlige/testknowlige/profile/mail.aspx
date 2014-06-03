<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail.aspx.cs" Inherits="TestKnowlige.profile.mail" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<%@ Register TagName="message" TagPrefix="uc" Src="~/usercontrol/Message.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Почта</title>
    <link href="../style/general.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="mail" runat="server">
    <div>
    <uc:menu Visible="true" ID="menu" runat="server"/>
    <div class="main">
        <div class="MailOption">
            <asp:ImageButton ID="SendMes" runat="server" 
                ImageUrl="~/img/newMessage.png" onclick="SendMessage_Click" 
                style="width: 21px" />
            <asp:ImageButton ID="refreshMessage" runat="server" 
                ImageUrl="~/img/refreshMessage.png" onclick="refreshMessage_Click" />
            <asp:ImageButton ID="deleteMessage" runat="server"  
                ImageUrl="~/img/deleteMessage.png" onclick="deleteMessage_Click" />            
        </div>
        <div class="mail_menu">
        <asp:HiddenField runat="server" ID="WhatList" />
            <asp:Button runat="server" ID="NewMessage" Text="Полученные" 
                onclick="NewMessage_Click" />
            <asp:Button runat="server" ID="SenderMessage" Text="Отправленные" 
                onclick="SenderMessage_Click"  />            
        </div>
        <div class="listMessage"> 
            <asp:Label ID="MessageError" runat="server" CssClass="error" Visible="false"/>       
            <asp:Repeater runat="server" ID="listMessage">
                <ItemTemplate>
                <div>
                    <asp:CheckBox ID="selectMessage" runat="server" />
                    <asp:HiddenField ID="message_id" runat="server" Value='<%# Eval("message_id") %>'/>
                    <asp:Label ID="User" runat="server"><%# Eval("login") %></asp:Label>
                    <asp:Label ID="Message" runat="server"><%# Eval("Text") %></asp:Label>
                </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    </div>
    <uc:message ID="messageItem" runat="server" Visible="false"/>
    <div runat="server" id="sendMessage" class="send" visible ="false">
        <asp:Label ID="goodSend" runat="server">Сообщение успешно отправленно</asp:Label>
    </div>
    </form>
</body>
</html>
