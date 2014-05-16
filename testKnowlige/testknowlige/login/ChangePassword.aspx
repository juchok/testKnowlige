<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TestKnowlige.login.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../style/style.css" />
</head>
<body>
    <form id="changepassword" runat="server" class="ChangePassword">
    <div>
        <asp:Label ID="lblChangePasswordHeader" runat="server" Text="Change password" CssClass="changeheader"></asp:Label>
        <div>
            <asp:Label ID="lblOldPass" runat="server" Text="Enter old password"></asp:Label>
            <asp:TextBox ID="txtOldPass" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="ValidOldPass" runat="server" ControlToValidate="txtOldPass" 
        ErrorMessage="Пароль не может быть пустым" Display="Dynamic"></asp:RequiredFieldValidator>
        <div>
            <asp:Label ID="lblNewPass" runat="server" Text="Enter new password"></asp:Label>
            <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server"></asp:TextBox>
        </div>
         <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNewPass"
            ErrorMessage="Длинна пароля должна быть не менее 6 символов"
            Display="Dynamic" id="ValidPassword"
            ValidationExpression="\S{6,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label ID="lblNewRePass" runat="server" Text="Enter new re-password"></asp:Label>
            <asp:TextBox ID="txtNewRePass" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:CompareValidator runat="server" ID="ValidRepass" ControlToValidate="txtNewRePass"
        ControlToCompare="txtNewPass" Display="Dynamic" Type="String"
        ErrorMessage="Пароли не одинаковые"></asp:CompareValidator>
        <div>
            <asp:Label ID="errorPas" runat="server" CssClass="errorPas" Visible="false">Не верный текущий пароль</asp:Label>
        </div>
        <br />
        <asp:Button ID="btnChangePass" runat="server" Text="Change" 
            onclick="btnChangePass_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  CausesValidation="false"
            onclick="btnCancel_Click" />
    </div>
    </form>
</body>
</html>
