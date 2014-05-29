<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEdit.aspx.cs" Inherits="TestKnowlige.profile.Teacher.TestEdit"  EnableEventValidation="false"%>
<%@ Register TagName="EditTest" TagPrefix="uc" Src="~/usercontrol/TestRedact.ascx" %>
<%@ Register TagName="UcConfirm" TagPrefix="uc" Src="~/usercontrol/confirmTestEdit.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" type="text/css" href="../../style/Addtest.css" />
    <script src="../../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="../../js/script.js" type="text/javascript"></script>
    <title>Редактирование теста</title>
</head>
<body>
    <form id="TestEdit" runat="server" class="main">
    <div>         
        <asp:ImageButton ID="AddQuestion" AlternateText="AddQuestion" runat="server" CssClass="addQuestion" 
            ImageUrl="~/img/plus2.png" onclick="AddQuestion_Click" Visible="true" title="Добавить новый вопрос"/>  
        <asp:ImageButton ID="RedactTestName" AlternateText="RedactTestname" runat="server" CssClass="addQuestion" 
            ImageUrl="~/img/redact.png" onclick="RedactTestName_Click" Visible="true" title="Изменить имя теста"/>  
        <div>
            <asp:Label ID="testName" CssClass="testname" runat="server"></asp:Label>
            <asp:Label ID="testAuthor"  CssClass="testauthor" runat="server"></asp:Label>                 
            <asp:HiddenField ID="test_id" runat="server" />             
        </div>

        <asp:Repeater runat="server" ID="questions">        
            <ItemTemplate>
                <div class="question">
                    <div>
                        <asp:Label ID="question" runat="server"><%# (questions.Items.Count+1).ToString()+".  "+ Eval("text") %></asp:Label>                
                        <asp:HiddenField ID="question_id" runat="server" Value='<%# Eval("question_id") %>' />                
                        <asp:ImageButton ID="deleteQuestion"  runat="server" ImageUrl="~/img/delete.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="delQuestion_Click"  title="Удалить вопрос" Visible="true"/>
                        <asp:ImageButton ID="redactQuestion"  runat="server" ImageUrl="~/img/redact.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="RedactQuestion_Click" title="Редактировать вопрос" Visible="true"/>
                        <asp:ImageButton ID="addAnswer"  runat="server" ImageUrl="~/img/add.png" AlternateText='<%# Eval("question_id") %>' CssClass="add" OnClick="AddAnswer_Click" title="Добавить ответ" Visible="true"/>                
                        <asp:Label ID="question_point" runat="server" CssClass="points"><%# Eval("points") + " баллов"%></asp:Label>                                
                    </div>
                    <div class="answers">
                        <asp:Repeater ID="answers" runat="server">
                            <ItemTemplate>                        
                                <div>
                                    <asp:CheckBox ID="answer" Enabled="false" Checked='<%# Eval("correct") %>' runat="server" CssClass="answer" Text='<%# Eval("answer_text") %>'/>
                                    <asp:ImageButton ID="deleteAnswer"  runat="server" ImageUrl="~/img/delete.png" AlternateText='<%# Eval("answer_id") %>' CssClass="AnswerInput" OnClick="delAnswer_Click" title="Удалить ответ" />                
                                    <asp:ImageButton ID="redactAnswer"  runat="server" ImageUrl="~/img/redact.png" AlternateText='<%# Eval("answer_id") %>' CssClass="AnswerInput" OnClick="RedactAnswer_Click" title="Редактировать ответ" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <uc:EditTest ID="EditTest" runat="server" Visible="false" />
        <uc:UcConfirm ID="FormConfirm" runat="server" Visible="false" />        
        <asp:Button Text="Завершить" ID="Finish" runat="server" CssClass="save" onclick="Finish_Click" Visible="true" />
        <asp:Button Text="На главную" ID="Home" runat="server"  CssClass="cancel" onclick="Home_Click"/>
            <div class="saveComplite">
                <asp:Label Text="Сохранено" runat="server" />
            </div>
    </div>
    </form>
</body>
</html>
