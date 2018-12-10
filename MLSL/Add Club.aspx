<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Add Club.aspx.cs" Inherits="Add_Club"  %>
<%@ Register Src="~/Club Details.ascx" TagPrefix="uc1" TagName="Club_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 220px;
            margin-top: 18px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="PanelClub" runat="server">      
        <uc1:Club_Details runat="server" id="ClubDetails" />
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="registration_number" runat="server" Text="Registration Number: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="registrationNumberClub" runat="server" style="margin-top: 0px" TextMode="Number">
                    </asp:TextBox>       
                    <asp:RequiredFieldValidator ID="registrationNumberRequired" runat="server" ControlToValidate="registrationNumberClub" ErrorMessage="Required" ValidationGroup="1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="address" runat="server" Text="Address: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ClubAddress" runat="server" style="margin-top: 0px; margin-left: 0px;">
                    </asp:TextBox>
                    <br />
                </td>
            </tr>
        </table>    
        <table class="auto-style1">
            <tr>
                <td> <asp:Label ID="Label1" runat="server" Text="Select Stadium Region" sytle ="margin-top:-100px;"></asp:Label></td>
                <td><asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/images/earth-lights-world-419491.jpg" HotSpotMode="PostBack" OnClick="ImageMap1_Click">
            <asp:PolygonHotSpot AlternateText="Canada" HotSpotMode="PostBack" PostBackValue="Canada" Coordinates="61,35,54,49,38,32,30,22,44,19,60,14,82,11,101,13,106,21,119,23,126,38,87,42,98,42,111,41" />
            <asp:PolygonHotSpot AlternateText="United States" HotSpotMode="PostBack" PostBackValue="United States" Coordinates="59,52,59,38,75,38,95,40,104,43,115,44,96,57,84,68,74,67,94,75,99,67,64,59" />
            <asp:PolygonHotSpot AlternateText="England" PostBackValue="England" Coordinates="166,37,178,31,175,37" HotSpotMode="PostBack" />
            <asp:PolygonHotSpot AlternateText="Argentina" Coordinates="109,116,107,140,112,129,120,119" HotSpotMode="PostBack" PostBackValue="Argentina" />
            <asp:PolygonHotSpot AlternateText="Brazil" Coordinates="126,88,121,101,126,112,137,108,144,101,138,94" HotSpotMode="PostBack" PostBackValue="Brazil" />
            <asp:PolygonHotSpot AlternateText="Africa" Coordinates="185,84,169,81,167,67,180,58,202,58,218,74,225,83,222,112,203,125,194,110" HotSpotMode="PostBack" PostBackValue="Africa" />
            <asp:PolygonHotSpot AlternateText="India" Coordinates="253,56,248,63,254,73,258,80,265,71,273,65" HotSpotMode="PostBack" PostBackValue="India" />
            <asp:PolygonHotSpot AlternateText="Australia" Coordinates="313,101,301,109,293,120,295,128,306,120,314,121,322,125,334,119,326,106" HotSpotMode="PostBack" PostBackValue="Australia" />
            <asp:PolygonHotSpot AlternateText="China" Coordinates="275,62,262,59,253,52,263,42,276,42,284,52" PostBackValue="China" />
            <asp:PolygonHotSpot AlternateText="Russia" Coordinates="251,35,228,33,216,23,210,19,264,34,294,38,318,36,344,29,346,17,303,8,262,9,233,10,218,11,212,13,224,24,239,32,279,37,271,34" PostBackValue="Russia" />
        </asp:ImageMap></td>
            </tr>
        </table>
        <asp:Label ID="Country" runat="server" Text="No Country Selected " ForeColor="#CC3300"></asp:Label>
        <br/>
        
        <asp:Button ID="saveClub" runat="server" OnClick="saveClubOnClick" Text="Save Club " ValidationGroup="1" />
       
        <asp:Button ID="cancelClub" runat="server" Text="Cancel" OnClick="cancelClubOnClick" CausesValidation="False" UseSubmitBehavior="False" />
        
    </asp:Panel>
    <br>

    <asp:Panel ID="PanelPlayer" runat="server" Visible="False">
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Label ID="player_name" runat="server" Text="Player Name: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="PlayerName" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPlayerName" runat="server" ControlToValidate="PlayerName" ErrorMessage="Player Name Required">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="date_of_birth" runat="server" Text="Date of Birth: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Required_Date" runat="server" ErrorMessage="Date of Birth Required" ControlToValidate="DateOfBirth"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="jersey_number" runat="server" Text="Jersey Number: ">
                    </asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="JerseyNumber" runat="server" style="margin-top: 0px" TextMode="Number">
                    </asp:TextBox>
                    <asp:RangeValidator ID="RangeValidatorZeroToNintyNine" runat="server" ControlToValidate="JerseyNumber" ErrorMessage=" Enter a value from 0-99" MaximumValue="99" MinimumValue="0" SetFocusOnError="True" Type="Integer">
                    </asp:RangeValidator>
                </td>
            </tr>
        </table>
        <br>
        <br>
        <asp:Button ID="save_player" runat="server" OnClick="savePlayerOnClick" Text="Save Player " />
        <asp:Button ID="CancelPlayer" runat="server" Text="Cancel"  OnClick="cancelPlayerOnClick" CausesValidation="False" UseSubmitBehavior="False" />
    </asp:Panel>
</asp:Content>


