<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="TestKnowlige.administration.Users" %>
<%@ Register TagName="menu" TagPrefix="uc" Src="~/usercontrol/AdminMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Список пользователей</title>
    <link rel="Stylesheet" type="text/css" href="../style/admins.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc:menu ID="AdminMenu" runat="server" />
        <div class="main">
            <asp:Label ID="lblHeader" Text="Список пользователей" runat="server" />
            <asp:ValidationSummary runat="server" DisplayMode="BulletList" ValidationGroup="Update" ID="ValidUpdate"/>                        
            <asp:Label runat="server" ID="MessageError" Visible="false" CssClass="error"/>
            <asp:GridView ID="UserList" runat="server" ShowFooter="true"            
            AutoGenerateColumns="false"  
            OnRowEditing="UserList_RowEditing"
            OnRowCancelingEdit="UserList_RowCancelEditing"
            OnRowUpdating="UserList_RowUpdating"
            OnRowDeleting="UserList_RowDeleting"            
                >
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                Text="Обновить" OnClientClick="return confirm('Обновить информацию о пользователе?')" 
                                ValidationGroup="Update"></asp:LinkButton>                                                                                            
                            <asp:LinkButton ID="lnkCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Отмена"></asp:LinkButton>
                        </EditItemTemplate>                        
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="Правка"></asp:LinkButton>
                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="Удалить" OnClientClick="return confirm('Вы действительно хотите удалить пользователся?')"></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />                        
                    </asp:TemplateField>                    
                </Columns>
                <Columns>
                    <asp:BoundField DataField="firstname" HeaderText="Фамилия" />                    
                </Columns>
                <Columns>
                    <asp:BoundField DataField="lastname" HeaderText="Имя" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="login" HeaderText="Логин" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="question" HeaderText="Вопрос" />
                </Columns>
                <Columns>
                    <asp:BoundField DataField="answer" HeaderText="Ответ" />
                </Columns>
                <Columns>
                    <asp:TemplateField>                    
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Categories") %>' runat="server" />                            
                        </ItemTemplate>                        
                        <EditItemTemplate>
                            <asp:DropDownList runat="server" ID="UserCatigories">                                
                            </asp:DropDownList>
                            <asp:Label Text='<%# Eval("user_id") %>' runat="server" Visible="false" ID="UserId"/>
                        </EditItemTemplate>
                    </asp:TemplateField>                
                </Columns>
                
             
            </asp:GridView>
        </div>     
    </div>
    </form>
</body>
</html>
