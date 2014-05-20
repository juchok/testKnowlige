<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyMessageError.ascx.cs" Inherits="TestKnowlige.usercontrol.MyMessageError" %>
<div class="UC_main">
<div class="backgr"></div>
    <div class="usercontr">
        <asp:Label ID="HeaderControl"  Text="Header" CssClass="UC_header" runat="server"></asp:Label>
        <asp:Label ID="ErrorMes" Text="Error" CssClass="UC_MesError" runat="server" ></asp:Label>       
        <asp:Button ID="btnOk" runat="server" Text="Ok" CausesValidation="false" 
            onclick="btnOk_Click" />
    </div>
</div>