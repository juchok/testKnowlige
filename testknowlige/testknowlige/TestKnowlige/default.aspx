<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TestKnowlige._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LoginName ID="LogName" runat="server" FormatString="Welcome, {0}" />        
        <asp:HyperLink ID="lnkChangePass" runat="server" Visible="false" NavigateUrl="~/login/ChangePassword.aspx">Change password</asp:HyperLink>
        <asp:LoginStatus ID="LogStat" runat="server" />        
    </div>
    <div>
        <asp:HyperLink ig="Discipline" runat="server" NavigateUrl="~/Discipline.aspx">Выбор дисциплины</asp:HyperLink>
    </div>
    </form>
</body>
</html>
