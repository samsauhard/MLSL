<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Match Scheduling.aspx.cs" Inherits="Match_Scheduling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 253px;
        }
        .auto-style3 {
            margin-top: 0px;
            margin-bottom: 15px;
        }
        .auto-style4 {
            width: 150px;
            margin-top: 16px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
       <tr>
           <td class="auto-style2">
               <asp:Label ID="HomeTeam" runat="server" Text="Home Team" style="margin-left:30px">
               </asp:Label>
           </td>
           <td>
               <asp:Label ID="AwayTeam" runat="server" style="margin-left:30px" Text="Away Team">
               </asp:Label>
           </td>
       </tr>
        <tr>
            <td class="auto-style2">   
                <asp:DropDownList ID="HomeClubdDropdown" runat="server" OnSelectedIndexChanged ="DropDownListSelectedIndexChanged" CssClass="auto-style3" style ="margin-left:30px" Width="150px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="AwayClubDropdown" runat="server" OnSelectedIndexChanged ="DropDownListSelectedIndexChanged" style="margin-left:30px; " CssClass="auto-style4" AutoPostBack="True">
                </asp:DropDownList>
                <br/>
                <br/>
                <br/>
            </td>
            <td>
            <asp:Button ID="ScheduleMatch" runat="server" Text="Schedule Match" style="margin-left:30px" Height="22px" OnClick="scheduleMatch"/>
            </td>
       </tr>
       <tr>
           <td class="auto-style2">
               <asp:Label ID="MatchDateSelection" runat="server" Text="Select Match Date :" style="margin-left:40px; margin-top:60px" >
               </asp:Label>       
           </td>
           <td>
               <asp:Label ID="ErrorOutput" runat="server" Text=" " ForeColor="red" style="">
                </asp:Label>
                <asp:Calendar ID="DateSelectionCalander" runat="server" OnDayRender="dateSelectionCalanderOnDayRender" OnSelectionChanged ="Selection_Change" style="margin-top:20px" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" >
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
                <br/>
                <br/>
                <asp:Label ID="SelectedDate" runat="server" ForeColor="Black">
                </asp:Label>
           </td>

        </tr>
        <br/>
        <br/>
        <br/>
        <tr>
            <td>
            </td>
            <td>
                <div style ="margin-top:30px">
                    <asp:GridView ID="GridViewFixtures" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField HeaderText="Home Team" DataField ="home"/>
                            <asp:BoundField HeaderText="Away Team" DataField ="away"/>
                            <asp:BoundField HeaderText="Match Date" DataField ="matchdate" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td> 
        </tr>
    </table>
</asp:Content>