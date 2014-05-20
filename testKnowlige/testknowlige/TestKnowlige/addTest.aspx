<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addTest.aspx.cs" Inherits="TestKnowlige.addTest" %>
<%@ Register TagName="UcAddTest" TagPrefix="uc" Src="~/usercontrol/AddTest.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="style/Addtest.css" />
</head>
<body>
    <form id="form1" class="main" runat="server">
    <div>
    <asp:ImageButton ID="addNewTest" AlternateText="AddTest" runat="server" CssClass="add" 
            ImageUrl="~/img/plus2.png" onclick="addTest_Click" Visible="false" />        
    <asp:ImageButton ID="AddQuestion" AlternateText="AddQuestion" runat="server" CssClass="add" 
            ImageUrl="~/img/plus2.png" onclick="AddQuestion_Click" Visible="false"/>        
    <asp:ImageButton ID="AddAnswer" AlternateText="AddAnswer" runat="server" CssClass="add" 
            ImageUrl="~/img/plus2.png" onclick="AddAnswer_Click" Visible="false" />        
        <div>
            <asp:Label ID="testName" runat="server"></asp:Label>
            <asp:Label ID="testAuthor" runat="server"></asp:Label>        
            <asp:HiddenField ID="test_id" runat="server" Value="10"/>
        </div>
        
        <asp:Repeater runat="server" ID="questions">        
            <ItemTemplate>
                <div class="question">
                <asp:Label ID="question" runat="server"><%# (questions.Items.Count+1).ToString()+".  "+ Eval("text") %></asp:Label>
                <asp:Label ID="question_point" runat="server" CssClass="points"><%# Eval("points") + " баллов"%></asp:Label>                                
                <asp:HiddenField ID="question_id" runat="server" Value='<%# Eval("question_id") %>' />
                <asp:HyperLink ID="ImageButton1"  runat="server" NavigateUrl="~/add.aspx">qwe</asp:HyperLink>
                <!--<asp:ImageButton ID="addAnswer"  runat="server" ImageUrl="~/img/plus3.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="AddBtn_Click" />-->
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

        <uc:UcAddTest ID="NewTest" runat="server" Visible="true" />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">На главную</asp:HyperLink>    
    </div>
    </form>
</body>
</html>
