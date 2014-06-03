<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitUsers.aspx.cs" Inherits="TestKnowlige.administration.WaitUsers" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/AdminMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../style/admins.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:menu ID="AdminMenu" runat="server" />
        <div class="main">
            <asp:Label Text="Список ожидающих ответа на админку" runat="server" ID="lblHeader"/>
            <asp:Label runat="server" ID="MessageError" Visible="false" CssClass="error"/>
            <asp:Label Text="Нет записей" runat="server" Visible="false" ID="MessageForAdmin" CssClass="MessageForAdmin"/>
            <asp:Repeater runat="server" ID="waitUserslist">
                <ItemTemplate>
                    <div>
                        <asp:CheckBox runat="server" ID="login" Text='<%# Eval("login") %>'/>
                        <asp:Label Text='<%# Eval("firstname") %>' runat="server" ID="lblFirstname"/>
                        <asp:Label Text='<%# Eval("lastname") %>' runat="server" ID="lblLastname"/>                    
                        <asp:Label Text='<%# Eval("mail") %>' runat="server" ID="lblMail"/>
                        <asp:Label Text='<%# Eval("phone") %>' runat="server" ID="lblPhone"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>            
                <asp:Button Text="Добавить" runat="server" ID="AddUser" 
                    onclick="AddUser_Click"/>
                <asp:Button Text="Удалить" runat="server" ID="DeleteUser" 
                    onclick="DeleteUser_Click"/>            
        </div>    
    </div>
    </form>
</body>
</html>
