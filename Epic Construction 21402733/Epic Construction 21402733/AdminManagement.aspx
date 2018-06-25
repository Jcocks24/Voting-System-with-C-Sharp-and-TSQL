<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminManagement.aspx.cs" Inherits="Epic_Construction_21402733.AdminManagement" %>

<asp:Content ID="ContentAdminManagement" ContentPlaceHolderID="ContentPlaceHolderAdminManagement" runat="server">
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

    <header id="Welcome">  
        <h3>
            <asp:Label ID="LabelAdminName" runat="server"></asp:Label>
        </h3>
        <asp:TextBox ID="TextBoxCandidateId" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxCandidateFName" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxCandidateLName" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxCandidateCount" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxVotingList" runat="server" Visible="False"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBoxNumbersVoted" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
    </header>

    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonReturnAdmin_Click" Width="58px" />
    </div>
</asp:Content>
