<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TestKnowlige.login.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../style/style.css" />
</head>
<body>
    <form id="login" runat="server" class="login">
    <div>
        <asp:Label ID="lblLoginHeader" runat="server" Text="Login" CssClass="loginHeader"></asp:Label>        
        <asp:Label ID="MessageError" Visible="false" CssClass="messError" runat="server" />
        <div>
            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtLogin" ID="validLogin"
            ErrorMessage="Длинна логина должна быть не менее 4 символов, состоять из букв или цифр"
            Display="Dynamic" 
            ValidationExpression="\w{4,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
        </div>
         <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPassword"
            ErrorMessage="Длинна пароля должна быть не менее 6 символов"
            Display="Dynamic" ID="ValidPassword"
            ValidationExpression="\w{6,}"></asp:RegularExpressionValidator>        
        <asp:Label ID="ErrorMessage" runat="server" CssClass="" Visible="false" >Логин или пароль не правильный!</asp:Label>
        <asp:Button ID="btnLogin" runat="server" Text="Login" 
            onclick="btnLogin_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            CausesValidation="false" onclick="btnCancel_Click" /><br />
        <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/login/CreateLogin.aspx" CssClass="register">Зарегистрироваться</asp:HyperLink>
        <asp:HyperLink ID="lnkRecoveryPassword" runat="server" NavigateUrl="~/login/RecoveryPassword.aspx" CssClass="forgot">Забыли пароль?</asp:HyperLink>
    </div>
    </form>
</body>
</html>
