<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addTest.aspx.cs" Inherits="TestKnowlige.addTest" EnableEventValidation="false" %>
<%@ Register TagName="UcAddTest" TagPrefix="uc" Src="~/usercontrol/AddTest.ascx"%>
<%@ Register TagName="UcConfirm" TagPrefix="uc" Src="~/usercontrol/confirm.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="style/Addtest.css" />
</head>
<body>
    <form id="form1" class="main" runat="server">
    <div>            
        <asp:ImageButton ID="addNewTest" AlternateText="AddTest" runat="server" CssClass="addQuestion" 
            ImageUrl="~/img/plus2.png" onclick="addTest_Click" Visible="false" title="Ввести название теста"/>        
        <asp:ImageButton ID="AddQuestion" AlternateText="AddQuestion" runat="server" CssClass="addQuestion" 
            ImageUrl="~/img/plus2.png" onclick="AddQuestion_Click" Visible="false" title="Добавить новый вопрос"/>  
        <div>
            <asp:Label ID="testName" CssClass="testname" runat="server"></asp:Label>
            <asp:Label ID="testAuthor"  CssClass="testauthor" runat="server"></asp:Label>        
            <asp:Label ID="MessageError" runat="server" Visible="true" />
            <asp:HiddenField ID="test_id" runat="server" />             
            <asp:HiddenField ID="cat_id" runat="server" />
        </div>
             
        
        <asp:Repeater runat="server" ID="questions">        
            <ItemTemplate>
                <div class="question">
                    <div>
                        <asp:Label ID="question" runat="server"><%# (questions.Items.Count+1).ToString()+".  "+ Eval("text") %></asp:Label>                
                        <asp:HiddenField ID="question_id" runat="server" Value='<%# Eval("question_id") %>' />                
                        <asp:ImageButton ID="deleteQuestion"  runat="server" ImageUrl="~/img/delete.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="delQuestion_Click"  title="Удалить вопрос"/>
                        <asp:ImageButton ID="redactQuestion"  runat="server" ImageUrl="~/img/redact.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="RedactQuestion_Click" title="Редактировать вопрос" />
                        <asp:ImageButton ID="addAnswer"  runat="server" ImageUrl="~/img/add.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="AddAnswer_Click" title="Добавить ответ"/>                
                        <asp:Label ID="question_point" runat="server" CssClass="points"><%# Eval("points") + " баллов"%></asp:Label>                                
                    </div>
                    <div class="answers">
                        <asp:Repeater ID="answers" runat="server">
                            <ItemTemplate>                        
                                <div>
                                    <asp:CheckBox ID="answer" Enabled="false" Checked='<%# Eval("correct") %>' runat="server" CssClass="answer" Text='<%# Eval("text") %>'/>
                                    <asp:ImageButton ID="deleteAnswer"  runat="server" ImageUrl="~/img/delete.png" AlternateText='<%# Eval("answer_id") %>' CssClass="AnswerInput" OnClick="delAnswer_Click" title="Удалить ответ" />                
                                    <asp:ImageButton ID="redactAnswer"  runat="server" ImageUrl="~/img/redact.png" AlternateText='<%# Eval("answer_id") %>' CssClass="AnswerInput" OnClick="RedactAnswer_Click" title="Редактировать ответ" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <uc:UcAddTest ID="NewTest" runat="server" Visible="true" />
        <uc:UcConfirm ID="FormConfirm" runat="server" Visible="false" />        
        <asp:Button Text="Сохранить" ID="save" runat="server" CssClass="save" onclick="save_Click" Visible="false" />
        <asp:Button Text="Отмена" ID="cancel" runat="server"  CssClass="cancel" CausesValidation="false" 
            onclick="cancel_Click"/>
    </div>
    </form>
</body>
</html>
