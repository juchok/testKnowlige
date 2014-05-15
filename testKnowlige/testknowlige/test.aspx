<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TestKnowlige.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="style/test.css" />
</head>
<body>
    <form id="Tests" class="test" runat="server">
    <div>
        <div class="header">
            <asp:Image AlternateText="" ID="img_header" ImageUrl="~/img/tests.jpg" runat="server"/>
            <asp:Label ID="header_discipline" runat="server" CssClass=""></asp:Label>
            <asp:Label ID="header_categories" runat="server" CssClass=""></asp:Label>
            <asp:Label ID="header_test" runat="server" CssClass=""></asp:Label>
        </div>
        <asp:Repeater runat="server" ID="questions">        
            <ItemTemplate>
                <div class="question">
                <asp:Label ID="question" runat="server"><%# (questions.Items.Count+1).ToString()+".  "+ Eval("text") %></asp:Label>
                <asp:HiddenField ID="question_id" Visible="false" runat="server" Value='<%# Eval("question_id") %>'/>
                    <div class="answers">
                        <asp:Repeater ID="answers" runat="server">
                            <ItemTemplate>                        
                                <div>
                                    <asp:CheckBox ID="answer" runat="server" Checked="false" Text='<%# Eval("answer_text") %>'/>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>                    
    <asp:Button ID="Complite" Text="Завершить" runat="server" 
            PostBackUrl="~/testComplite.aspx" />    
    </div>
    </form>
</body>
</html>
