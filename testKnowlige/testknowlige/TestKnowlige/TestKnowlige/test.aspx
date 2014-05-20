<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TestKnowlige.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Tests" runat="server">
    <div>
        <asp:Label ID="header" runat="server" CssClass=""></asp:Label>
        <asp:Repeater runat="server" ID="questions">
            <ItemTemplate>
                <asp:Label ID="question" runat="server"><%# Eval("text") %></asp:Label>
                <asp:HiddenField ID="question_id" runat="server" Value='<%# Eval("question_id") %>'/>
                <asp:Repeater ID="answers" runat="server">
                    <ItemTemplate>
                        <asp:CheckBox ID="answer" runat="server" Checked="false" Text='<%# Eval("answer_text") %>'/>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>            
        
    
    </div>
    </form>
</body>
</html>
