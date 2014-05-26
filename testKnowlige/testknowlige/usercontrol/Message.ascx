<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="TestKnowlige.usercontrol.Message" %>
<div class="UC_main">
<div class="backgr"></div>
    <div class="usercontr" >
        <asp:Label runat="server" CssClass="UC_header" ID="ConfirmHeader">Новое сообщение</asp:Label>
        <div>
            <asp:Label runat="server" ID="From" CssClass="text">От</asp:Label>
            <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
        </div>
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtFrom"
            ErrorMessage="Длинна логина должна быть не менее 4 символов"
            Display="Dynamic" id="ValidFrom"
            ValidationExpression="\w{4,}"></asp:RegularExpressionValidator>
        <div>
            <asp:Label runat="server" ID="ToUser" CssClass="text">Кому</asp:Label>
            <asp:TextBox ID="txtToUser" runat="server"></asp:TextBox>
        </div>
         <asp:RegularExpressionValidator runat="server" ControlToValidate="txtToUser"
            ErrorMessage="Длинна логина должна быть не менее 4 символов"
            Display="Dynamic" id="ValidToUser"
            ValidationExpression="\w{4,}"></asp:RegularExpressionValidator>
        <asp:HiddenField ID="hideid" Visible="false" runat="server" />     
          <div>
            <asp:Label ID="lblMessage" runat="server">Сообщение</asp:Label>            
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:RequiredFieldValidator ID="ValidMesasge" runat="server" ControlToValidate="txtMessage"
            Display="Dynamic" ErrorMessage="Сообщение не может быть пустым"></asp:RequiredFieldValidator>        
        <asp:Label ID="errorMessage" runat="server" Visible="false"></asp:Label>
        
        <asp:Button ID="SendMessage" Text="Отправить" runat="server" 
            onclick="SendMessage_Click" />
        <asp:Button ID="Cancel" Text="Отмена" runat="server" CausesValidation="false" 
            onclick="Cancel_Click" />
    </div>       
</div>