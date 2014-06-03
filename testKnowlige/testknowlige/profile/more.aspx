<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="more.aspx.cs" Inherits="TestKnowlige.profile.more" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Дополнительная информация</title>
    <link href="../style/general.css" rel="stylesheet" type="text/css" />
</head>
<body>
      <form id="general" class="general" runat="server">
   <uc:menu Visible="true" ID="menu" runat="server"/>
    <div class="main">    
        <asp:Label ID="lblMore" runat="server" Text="Дополнительная информация"></asp:Label>
        <asp:Label ID="MessageError" Visible="false" CssClass="error" runat="server" />
         <div>
            <asp:Label ID="lblMail" runat="server" Text="e-Mail"></asp:Label>
            <asp:TextBox ID="txtMail" Enabled="false" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtMail"
            ErrorMessage="E-Mail введен не корректно! привер коректного - имя@сайт.домен"
            Display="Dynamic" id="validMail" CssClass="error"
            ValidationExpression=".+@.{2,}\..{2,4}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblPhone" runat="server" Text="Телефон"></asp:Label>
            <asp:TextBox ID="txtPhone" Enabled="false" runat="server"></asp:TextBox>        
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtPhone"
            ErrorMessage="формат телефон должен быть +nnn-nn-nnn-nn-nn"
            Display="Dynamic" id="ValidPhone" CssClass="error"
            ValidationExpression="\+\d{3}\-\d{2}\-\d{3}\-\d{2}\-\d{2}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblAddress" runat="server" Text="Адресс"></asp:Label>            
            <asp:TextBox ID="txtAddress" Enabled="false" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtAddress"
            ErrorMessage="Адрес должен быть больше 20 символов"
            Display="Dynamic" id="RegularExpressionValidator1" CssClass="error"
            ValidationExpression="\S{20,}"></asp:RegularExpressionValidator>
        <br />        

        <asp:Button ID="Change" runat="server" Text="Редактировать" onclick="Change_Click" 
            />
        <asp:Button ID="Save" runat="server" Text="Сохранить" Visible="false" onclick="Save_Click" 
            />
        <asp:Button ID="Cancel" runat="server" Visible="false" Text="Отмена" 
            CausesValidation="false" onclick="Cancel_Click" />
    </div>
    </form>
</body>
</html>
