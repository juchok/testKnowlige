<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="TestKnowlige.administration.Categories" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/AdminMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Список категорий</title>
    <link rel="Stylesheet" type="text/css" href="../style/admins.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc:menu ID="AdminMenu" runat="server" />
        <div class="main">
            <asp:Label ID="lblHeader" Text="Список категорий" runat="server" />
            <asp:Label runat="server" ID="MessageError" Visible="false" CssClass="error"/>
            <asp:GridView ID="CategoriesList" runat="server" ShowFooter="true"            
            AutoGenerateColumns="false" 
            OnRowEditing="CategoriesList_RowEditing"
            OnRowCancelingEdit="CategoriesList_RowCancelEditing"
            OnRowUpdating="CategoriesList_RowUpdating"
            OnRowDeleting="CategoriesList_RowDeleting"
            OnRowCommand="CategoriesList_RowCommand"
                >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Обновить" OnClientClick="return confirm('Вы действительно хотите обновить категорию?')" 
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
                                Text="Удалить" OnClientClick="return confirm('Вы действительно хотите удалить категорию?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <FooterTemplate>
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="True" CommandName="Insert"
                                ValidationGroup="Insert" Text="Добавить"></asp:LinkButton>                            
                        </FooterTemplate>
                    </asp:TemplateField>                    
                </Columns>
                <Columns>
                    <asp:TemplateField HeaderText = "Дисциплина">
                    <ItemTemplate>
                            <asp:Label ID="lblDiscipline_name" runat="server" Text='<%# Eval("Discipline_name") %>' />                                                        
                     </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="ddDiscipline" 
                            DataTextField="Discipline_Name" 
                            DataValueField="Discipline_Name">                            
                        </asp:DropDownList>                        
                    </EditItemTemplate>                        
                    <FooterTemplate>
                        <asp:DropDownList ID="DisciplineList" runat="server">                            
                        </asp:DropDownList>
                    </FooterTemplate>
                    </asp:TemplateField>                    
                </Columns>    
                <Columns>                    
                    <asp:TemplateField HeaderText="Категория">                        
                        <ItemTemplate>                        
                            <asp:Label ID="CatName" Text='<%# Eval("Categories_name") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" Text='<%# Eval("Categories_name") %>' ID="EditCaategories"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="newCategories"/>  
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>    
            </asp:GridView>
        </div>     
    </div>
    </form>
</body>
</html>
