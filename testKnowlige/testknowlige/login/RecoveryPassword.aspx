<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoveryPassword.aspx.cs" Inherits="TestKnowlige.login.RecoveryPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../style/style.css" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../js/script.js" type="text/javascript"></script>
</head>
<body>
    <form id="RecoveryPassword" runat="server" class="ChangePassword">
    <div>
        <asp:Label Text="Востановление пароля" runat="server" ID="header" CssClass="loginHeader"/>
        <asp:MultiView ID="RecoveryPass" runat="server">
            <asp:View runat="server" ID="yourLogin">
                <asp:Label ID="lbllogin" runat="server" >Введите ваш логин</asp:Label>
                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="txtLogin"
                    ErrorMessage="Длинна логина должна быть не менее 4 символов"
                    Display="Dynamic" id="ValidLogin" CssClass="messError"
                    ValidationExpression="\w{4,}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="validtxtLogin" CssClass="messError" ControlToValidate="txtLogin" runat="server"
                    ErrorMessage="Поле логина должно быть заполненным" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Label ID="loginError" runat="server" CssClass="messError" Visible="false">Указанный логин не существует</asp:Label>
                <asp:Button Text="Далее" runat="server" ID="btnNext_view1" 
                    onclick="btnNext_view1_Click"/>
                <asp:Button Text="Отмена" runat="server" ID="btnCancel_view1" CausesValidation="false"
                    onclick="btnCancel_view1_Click"/>
            </asp:View>

            <asp:View runat="server" ID="yourAnswer">
                <asp:Label ID="lblfotQuestion" runat="server">Вопрос: </asp:Label>
                <asp:Label ID="lblQuestion" runat="server"></asp:Label>
                <div>
                    <asp:Label Text="Введите ответ:" runat="server" ID="lblAnswer"/>
                    <asp:TextBox runat="server" ID="txtAnswer"/>
                    <asp:HiddenField ID="hidelogin" runat="server" />
                </div>
                    <asp:RequiredFieldValidator runat="server" ID="validQuestion" ControlToValidate="txtAnswer" CssClass="messError"
                    ErrorMessage="Поле вопроса должно быть заполненным" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="validtxtAnswer" ControlToValidate="txtAnswer" runat="server" CssClass="messError"
                    ErrorMessage="Поле ответа должно быть заполненным" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label runat="server" ID="answerError" CssClass="messError" Visible="false">Не верный ответ</asp:Label>
                    <asp:Button Text="Далее" runat="server" ID="btnNext_view2" 
                        onclick="btnNext_view2_Click"/>                    
                    <asp:Button Text="Отмена" runat="server" ID="btnCancel_view2" CausesValidation="false"
                        onclick="btnCancel_view2_Click" />                
            </asp:View>

            <asp:View runat="server" ID="newPass">
                <asp:HiddenField ID="hideLog" runat="server" />
                <asp:Label ID="lblNewPass" runat="server">Ваш новый пароль:</asp:Label>
                <asp:Label ID="lblPass" runat="server"></asp:Label>
                <asp:Button Text="На главную" runat="server" ID="btnHome" 
                    onclick="btnHome_Click"/>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
</body>
</html>
