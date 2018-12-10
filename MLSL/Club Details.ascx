<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Club Details.ascx.cs" Inherits="Club_Details" %>

<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 220px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label3" runat="server" Text="Name: ">
            </asp:Label></td>
        <td>
            <asp:TextBox ID="ClubNameTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ClubNameTextBox" ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label4" runat="server" Text="City: "></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="ClubCityTextBox" runat="server">
            </asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ClubCityTextBox" ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>