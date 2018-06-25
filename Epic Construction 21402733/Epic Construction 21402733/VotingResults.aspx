<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VotingResults.aspx.cs" Inherits="Epic_Construction_21402733.VotingResults" %>

<asp:Content ID="ContentVotingResults" ContentPlaceHolderID="ContentPlaceHolderVotingResults" runat="server">
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

    <asp:Panel ID="PanelVoteResults" runat="server" align="center">
        <table style="border-collapse:collapse;" id="VotingResultsTable">
            <tr>
                <td colspan="2">
                    Staff Representative Voting STATISTICS
                    <br />===============================<br /> 
                    <asp:Label ID="LabelVotingList" runat="server"></asp:Label>
                    <br /> 
                    <asp:Label ID="LabelNumbersVoted" runat="server"></asp:Label>
                    <br />
                    <br />
                </td>
                </tr>
            <tr>
                <td colspan="2">
                    Voting Results
                    <br />-------------------------<br />
                    <asp:PlaceHolder ID="PlaceHolderCandidateStatistics" runat="server"></asp:PlaceHolder>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <br />

    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
    </div>
</asp:Content>

