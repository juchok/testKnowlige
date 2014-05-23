<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail.aspx.cs" Inherits="TestKnowlige.profile.mail" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/menu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Почта</title>
    <link href="../style/general.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="mail" runat="server">
    <div>
    <uc:menu Visible="true" ID="menu" runat="server"/>
    <div class="main"></div>
    </div>
    </form>
</body>
</html>
