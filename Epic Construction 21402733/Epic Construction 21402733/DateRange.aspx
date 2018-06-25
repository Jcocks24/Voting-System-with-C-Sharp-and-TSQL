<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DateRange.aspx.cs" Inherits="Epic_Construction_21402733.DateRange" %>

<asp:Content ID="ContentDateRange" ContentPlaceHolderID="ContentPlaceHolderDateRange" runat="server">
    <nav id="nav">  
        <ul>  
            <li><a href="ManageStaff.aspx">Manage Staff</a></li>  
            <li><a href="ManageCandidate.aspx">Manage Candidate</a></li>  
            <li><a href="DateRange.aspx">Date Range</a></li>  
            <li><a href="VotingResults.aspx">Voting Results</a></li>  
            <li><a href="StaffReport.aspx">Staff Report</a></li>
            <li><a href="ManageHelp.aspx">Manage Help</a></li>
            <li><a href="ManageDepartment.aspx">Manage Department</a></li>
        </ul>  
    </nav>

    <asp:Panel ID="PanelDateRange" runat="server" align="center">
                <br />
                <asp:Label ID="LabelSelectDateRange" runat="server" Text="Date Range"></asp:Label>
                <asp:DropDownList ID="DropDownListDateRange" runat="server" Width="347px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListDateRange_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:Label ID="LabelDateRange" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="ButtonEdit" runat="server" Text="Edit" OnClick="ButtonEdit_Click"/>
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click"/>
            </asp:Panel>

            <asp:Panel ID="PanelDateRangeManage" runat="server" align="center">
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" id="DateRangeManageTable">
                    <caption>
                        <br />
                        <asp:Label ID="LabelDateRangeStart" runat="server" Text="Date Range Start"></asp:Label>
                        <asp:TextBox ID="TextBoxDateRangeStart" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelDateRangeEnd" runat="server" Text="Date Range End"></asp:Label>
                        <asp:TextBox ID="TextBoxDateRangeEnd" runat="server" Enabled="False"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelDateRangeId" runat="server" Text="DateRange ID" Visible="False"></asp:Label>
                        <asp:TextBox ID="TextBoxDateRangeId" runat="server" Enabled="False" ReadOnly="True" Visible="False"></asp:TextBox>
                    </caption>
                </table>
            </asp:Panel>
    <br />
    <br />
    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
    </div>
</asp:Content>
