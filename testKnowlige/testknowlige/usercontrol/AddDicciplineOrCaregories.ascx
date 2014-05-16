<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddDicciplineOrCaregories.ascx.cs" Inherits="TestKnowlige.usercontrol.AddDicciplineOrCaregories" %>
<div class="UC_main">
<div class="backgr"></div>
    <div class="usercontr">
        <asp:Label ID="HeaderControl" CssClass="UC_header" runat="server"></asp:Label>
        <asp:Label ID="discipline" CssClass="UC_discipline" runat="server" ></asp:Label>
        <asp:HiddenField ID="discipline_id" runat="server" Visible="false" />
        <asp:Label ID="lblDisciplineOrCategories" CssClass="UC_DoC" runat="server"></asp:Label>
        <asp:TextBox ID="txtDisciplineOrCategories" CssClass="UC_txt" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="ValitDisciplineOrCategories" runat="server" 
            ErrorMessage="Название должна состоять из букв от а до я, цифр или круглых скобок, длиной 4+ символов"
            Display="Dynamic" ValidationExpression="[а-яА-я 0-9()]{3,}"  CssClass="UC_error"
            ControlToValidate="txtDisciplineOrCategories"
            ></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="EmptyField" runat="server" 
        ErrorMessage="Поле должно быть заполненым" Display="Dynamic"
        ControlToValidate="txtDisciplineOrCategories" CssClass="UC_error"
        ></asp:RequiredFieldValidator>
        <asp:Label ID="author" runat="server" CssClass="UC_author"></asp:Label>
        <asp:Button ID="btnAdd" runat="server" Text="Добавить" onclick="btnAdd_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Отмена" CssClass="UC_cancel" CausesValidation="false"
            onclick="btnCancel_Click" />
    </div>
</div>