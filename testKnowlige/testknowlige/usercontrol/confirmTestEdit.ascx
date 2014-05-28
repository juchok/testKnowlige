<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="confirmTestEdit.ascx.cs" Inherits="TestKnowlige.usercontrol.confirmTestEdit" %>
<div class="UC_main">
<div class="backgr"></div>
    <div class="usercontr" >
        <asp:Label runat="server" CssClass="UC_header" ID="ConfirmHeader">Удаление</asp:Label>
        <asp:Label runat="server" ID="ConfirgText" CssClass="text">текст</asp:Label>
        <asp:Label runat="server" ID="Confirmdel" CssClass="text"></asp:Label>
        <asp:HiddenField ID="hideid" Visible="false" runat="server" />        
        <asp:Button ID="ConfirmDeleteQuestion" Text="Удалить" runat="server" 
            Visible="false" onclick="ConfirmDeleteQuestion_Click"/>
        <asp:Button ID="ConfirmDeleteAnswer" Text="Удалить" runat="server" 
            Visible="false" onclick="ConfirmDeleteAnswer_Click"/>
        <asp:Button ID="Cancel" Text="Отмена" runat="server" CausesValidation="false" 
            onclick="Cancel_Click" />
    </div>     
</div>