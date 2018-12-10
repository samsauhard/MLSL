<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Clubs.aspx.cs" Inherits="Clubs" %>
<%@ Register Src="~/Club Details.ascx" TagPrefix="uc1" TagName="ClubDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        margin-left: 353px;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <br/>
    <br/><br/><br/><br/>
     <asp:DataList id="clubsList" runat="server" onitemcommand="clubListDisplay" CssClass="auto-style1">
         <ItemTemplate>
             <asp:LinkButton ID="detailsButton" runat="server" Text=<%#Eval("name")%> CommandName="getDetails" CommandArgument=<%#Eval("registration_number")%> ForeColor="Black" />
             <br/>   
             Club City: <strong><%#Eval("city")%></strong><br/>   
             
        </ItemTemplate>
        <SeparatorTemplate>
            <hr/>
        </SeparatorTemplate>
    </asp:DataList>
    
</asp:Content>

