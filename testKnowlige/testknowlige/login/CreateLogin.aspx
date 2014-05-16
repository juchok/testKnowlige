<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateLogin.aspx.cs" Inherits="TestKnowlige.login.CreateLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../style/style.css" />
</head>
<body>
    <form id="CreateAccaunt" runat="server" class="CreateAccaunt">
    <div>
        <asp:Label ID="lblCreateLoginHeader" runat="server" Text="Create accaunt" CssClass="loginHeader"></asp:Label>
        <div>
            <asp:Label ID="lblFirsname" runat="server" Text="Firstname"></asp:Label>
            <asp:TextBox ID="txtFirstname" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFirstname"
            ErrorMessage="Имя должно быть только из Букв или цифр, длинной не менее 2 символов"
            Display="Dynamic" id="validFirstname"
            ValidationExpression="[a-zA-z0-9]{2,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblLastname" runat="server" Text="Lastname"></asp:Label>
            <asp:TextBox ID="txtLastname" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtLastname"
            ErrorMessage="Фамиля должна быть только из Букв, длинной не менее 2 символов"
            Display="Dynamic" id="ValidLastname"
            ValidationExpression="[a-zA-z]{2,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblCategories" runat="server" Text="Categories"></asp:Label>
            <asp:DropDownList ID="DDList" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Students</asp:ListItem>
                <asp:ListItem>Teacher</asp:ListItem>
            </asp:DropDownList>        
        </div>
        <asp:RequiredFieldValidator ID="validCategories" runat="server" ControlToValidate="DDList"
        ErrorMessage="Необходимо выбрать категорию" Display="Dynamic"></asp:RequiredFieldValidator>
        <div>
            <asp:Label ID="lblLogin" runat="server" Text="Login"></asp:Label>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtLogin"
            ErrorMessage="Длинна логина должна быть не менее 4 символов"
            Display="Dynamic" id="ValidLogin"
            ValidationExpression="\w{4,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPassword"
            ErrorMessage="Длинна пароля должна быть не менее 6 символов"
            Display="Dynamic" id="ValidPassword"
            ValidationExpression="\w{6,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblRePassword" runat="server" Text="Re-Password"></asp:Label>
            <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password"></asp:TextBox>        
        </div>
        <asp:CompareValidator runat="server" ID="ValidRepass" ControlToValidate="txtRePassword"
        ControlToCompare="txtPassword" Display="Dynamic" Type="String"
        ErrorMessage="Пароли не одинаковые"></asp:CompareValidator>
        <div>
            <asp:Label ID="lblQuestioin" runat="server" Text="Your special question"></asp:Label>
            <br />
            <asp:TextBox ID="txtQuestion" runat="server" CssClass="question"></asp:TextBox>        
        </div>
        <asp:RequiredFieldValidator runat="server" ID="validQuestion" ControlToValidate="txtQuestion"
        ErrorMessage="Поле вопроса должно быть заполненным" Display="Dynamic"></asp:RequiredFieldValidator>        
        <div>
            <asp:Label ID="lblAnswer" runat="server" Text="Your answer"></asp:Label>
            <br />
            <asp:TextBox ID="txtAnswer" runat="server" CssClass="question"></asp:TextBox>        
        </div>
        <asp:RequiredFieldValidator runat="server" ID="ValidAnswer" ControlToValidate="txtAnswer"
        ErrorMessage="Поле ответа должно быть заполненным" Display="Dynamic"></asp:RequiredFieldValidator>       
        <br />
        <asp:Button ID="btnCreate" runat="server" Text="Register" 
            onclick="btnCreate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            CausesValidation="false" onclick="btnCancel_Click"/>
    </div>
    </form>
</body>
</html>
