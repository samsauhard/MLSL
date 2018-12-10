<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="clubdetails.aspx.cs" Inherits="clubdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 50px;
            margin-top: 18px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:DataList id="clubsDetailedList" runat="server"  onitemcommand="clubDetailedListDisplay" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <ItemTemplate>
                      Club Name: <strong><%#Eval("name")%></strong><br />
                      Club City: <strong><%#Eval("city")%></strong><br />
                      Club Reg. Number : <strong><%#Eval("registration_number")%></strong><br />
                      Club Address : <strong><%#Eval("address")%></strong><br />
                      <asp:LinkButton ID="BackButton" runat="server" Text="Go Back " ForeColor="Black" CommandName="goBack" />
                      &nbsp;
                      &nbsp;
                      &nbsp;
                      &nbsp;
                      <asp:LinkButton ID="DeleteClub" runat="server" Text=<%#"Delete Club " + Eval("name")%>  CommandName="deleteClub" CommandArgument=<%#Eval("registration_number")%> ForeColor="Black" />
                 </ItemTemplate>
                 <AlternatingItemStyle BackColor="PaleGoldenrod" />
                 <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                 <SeparatorTemplate>
                    <hr />
                 </SeparatorTemplate>
        </asp:DataList>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Style="margin-left:20px" OnRowEditing="editPlayer" OnRowDeleting ="playerDelete" OnRowUpdating  ="updatePlayer" OnRowCancelingEdit="playerCancelEdit" DataKeyNames ="jersey_number">
            <Columns>
                <asp:TemplateField HeaderText="Name" SortExpression="name">
                    <EditItemTemplate>
                        <asp:TextBox ID="playerName" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date of Birth" SortExpression="date_of_birth">
                    <EditItemTemplate>
                        <asp:TextBox ID="playerBirth" runat="server" Text='<%# Bind("date_of_birth") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("date_of_birth") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Jersey Number" SortExpression="jersey_number">
                    <EditItemTemplate>
                        <asp:TextBox ID="playerJersey" runat="server" Text='<%# Bind("jersey_number") %>' ReadOnly="true"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("jersey_number") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True">
                <ItemStyle ForeColor="Black" />
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    <asp:Label ID="Label4" runat="server" Text="Login To Edit Information" ForeColor="#CC3300" Visible="False"></asp:Label>  
    <asp:Button ID="Button1" runat="server" Text="Login" CssClass="auto-style1" PostBackUrl="~/Login.aspx" Visible="False" />
</asp:Content>

