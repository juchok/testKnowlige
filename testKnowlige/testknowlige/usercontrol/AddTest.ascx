<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTest.ascx.cs" Inherits="TestKnowlige.usercontrol.AddTest" %>
<div class="UC_main">
<div class="backgr"></div>
    <div class="usercontr">
        <asp:Label ID="HeaderControl" CssClass="UC_header" runat="server"></asp:Label>        
        <asp:HiddenField ID="hideField" runat="server" Visible="false" />
        <asp:Label ID="lblAdd" CssClass="lblAdd" runat="server"></asp:Label>
        <asp:TextBox ID="txtAdd" CssClass="txtAdd" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="ValidtxtAdd" runat="server" 
            ErrorMessage="Не должно содержать специальных символов"
            Display="Dynamic" ValidationExpression="[\S ]+"  CssClass="errorTxtAdd"
            ControlToValidate="txtAdd"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="EmptyField" runat="server" 
            ErrorMessage="Поле должно быть заполненым" Display="Dynamic"
            ControlToValidate="txtAdd" CssClass="errorTxtAdd"></asp:RequiredFieldValidator>        
        <asp:Panel ID="question_points" runat="server" Visible="false" CssClass="otherFilds">
            <div>
                <asp:Label ID="lblPoints" runat="server">Цена вопроса (баллы)</asp:Label>
                <asp:TextBox ID="txtPoints" runat="server" />  
            </div>
            <asp:RegularExpressionValidator ID="validPoints" runat="server" ControlToValidate="txtPoints"
            ErrorMessage="Могут быть только числа" CssClass="errorTxtAdd"
            Display="Dynamic" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="emptyPoints" runat="server" ControlToValidate="txtPoints" CssClass="errorTxtAdd"
            ErrorMessage="Поле с баллами не может быть пустым" Display="Dynamic"></asp:RequiredFieldValidator>
        </asp:Panel>
        <asp:Panel ID="answer_correct" runat="server" CssClass="otherFilds" Visible="false">
            <asp:CheckBox Text="Правильный ответ?" runat="server" ID="ckbCorrect" Checked="false"/>
        </asp:Panel>
        <asp:Button ID="btnAddTest" runat="server" Text="Добавить" 
            onclick="btnAddTest_Click" Visible="false"/>
        <asp:Button ID="btnAddQuestion" runat="server" Text="Добавить" 
            onclick="btnAddQuestion_Click" Visible="false"/>
        <asp:Button ID="btnAddAnswer" runat="server" Text="Добавить" 
            onclick="btnAddAnswer_Click" Visible="false"/>
        <asp:Button ID="RedactQuestion" Text="Редактировать" Visible="false" runat="server" OnClick="RedactQuestion_Click"/>
        <asp:Button ID="RedactAnswer" Text="Редактировать" Visible="false" runat="server" OnClick="RedactAnswer_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Отмена" CssClass="UC_cancel" 
            CausesValidation="false" onclick="btnCancel_Click" />
    </div>
</div>