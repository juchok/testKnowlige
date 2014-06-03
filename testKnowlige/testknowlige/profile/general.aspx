<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="general.aspx.cs" Inherits="TestKnowlige.profile.general" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Общая информация</title>
    <link rel="Stylesheet" type="text/css" href="../style/general.css" />
</head>
<body>

    <form id="general" class="general" runat="server">
    <uc:menu ID="menu" runat="server" Visible="true"/>
    <div class="main">    
        <asp:Label ID="lblGeneral" runat="server" Text="Общая информация"></asp:Label>
        <asp:Label ID="MessageError" Visible="false" CssClass="error" runat="server" />
         <div>
            <asp:Label ID="lblFirsname" runat="server" Text="Firstname"></asp:Label>
            <asp:TextBox ID="txtFirstname" Enabled="false" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFirstname"
            ErrorMessage="Имя должно быть только из Букв или цифр, длинной не менее 2 символов"
            Display="Dynamic" id="validFirstname" CssClass="error"
            ValidationExpression="[a-zA-z0-9]{2,}"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtFirstname"
            ErrorMessage="Поле должно быть заполненным" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>        
        <div>
            <asp:Label ID="lblLastname" runat="server" Text="Lastname"></asp:Label>
            <asp:TextBox ID="txtLastname" Enabled="false" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtLastname"
            ErrorMessage="Фамиля должна быть только из Букв, длинной не менее 2 символов"
            Display="Dynamic" id="ValidLastname" CssClass="error"
            ValidationExpression="[a-zA-z]{2,}"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtLastname"
            ErrorMessage="Поле должно быть заполненным" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>  
        <div>
            <asp:Label ID="lblQuestioin" runat="server" Text="Your special question"></asp:Label>            
            <asp:TextBox ID="txtQuestion" runat="server" Enabled="false" CssClass="question"></asp:TextBox>        
        </div>
        <asp:RequiredFieldValidator runat="server" ID="validQuestion" ControlToValidate="txtQuestion"
        ErrorMessage="Поле вопроса должно быть заполненным" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>        
        <div>
            <asp:Label ID="lblAnswer" runat="server" Text="Your answer"></asp:Label>            
            <asp:TextBox ID="txtAnswer" runat="server" Enabled="false" CssClass="question"></asp:TextBox>        
        </div>
        <asp:RequiredFieldValidator runat="server" ID="ValidAnswer" ControlToValidate="txtAnswer"
        ErrorMessage="Поле ответа должно быть заполненным" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
        <br />        

        <asp:Button ID="Change" runat="server" Text="Редактировать" 
            onclick="Change_Click"  />
        <asp:Button ID="Save" runat="server" Text="Сохранить" Visible="false" PostBackUrl="~/profile/general.aspx"
            onclick="Save_Click" />
        <asp:Button ID="Cancel" runat="server" Visible="false" Text="Отмена" 
            CausesValidation="false" onclick="Cancel_Click"/>
    </div>
    </form>
</body>
</html>
