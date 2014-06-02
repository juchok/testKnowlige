<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disciplines.aspx.cs" Inherits="TestKnowlige.administration.Disciplines" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/AdminMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Список дисциплин</title>
    <link rel="Stylesheet" type="text/css" href="../style/admins.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc:menu ID="AdminMenu" runat="server" />
        <div class="main">
            <asp:Label ID="lblHeader" Text="Список дисциплин" runat="server" />
            <asp:Label runat="server" ID="MessageError" Visible="false" CssClass="errorDelete"/>
            <asp:GridView ID="DisciplineList" runat="server"                    
            AutoGenerateColumns="false"  ShowFooter="true"
            OnRowEditing="Disciplinelist_RowEditing"
            OnRowCancelingEdit="Disciplinelist_RowCancelEditing"
            OnRowUpdating="Disciplinelist_RowUpdating"
            OnRowDeleting="Disciplinelist_RowDeleting"                       
            OnRowCommand="Disciplinelist_RowCommand"
            >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Обновить" OnClientClick="return confirm('Update?')" 
                                ValidationGroup="Update"></asp:LinkButton>                            
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Отмена"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                ValidationGroup="Insert" Text="Insert"></asp:LinkButton>                            
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Правка"></asp:LinkButton>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Удалить" OnClientClick="return confirm('Delete?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                ValidationGroup="Insert" Text="Добавить"></asp:LinkButton>                            
                        </FooterTemplate>
                    </asp:TemplateField>                    
                </Columns>
                <Columns>                   
                    <asp:TemplateField HeaderText="Название дисциплины" >                    
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Discipline_name") %>' runat="server" ID="ItemName"/> 
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="editDiscipline" Text='<%# Eval("Discipline_name") %>'/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="newDiscipline" Text=""/>                                                       
                        </FooterTemplate>
                    </asp:TemplateField>                    
            </Columns>
            <EditRowStyle Font-Bold="True" />                
            </asp:GridView>             
        </div> 
    
    </div>
    </form>
</body>
</html>
