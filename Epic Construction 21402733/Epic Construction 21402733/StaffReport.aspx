<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StaffReport.aspx.cs" Inherits="Epic_Construction_21402733.StaffReport" %>

<asp:Content ID="ContentStaffReport" ContentPlaceHolderID="ContentPlaceHolderStaffReport" runat="server">
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

    <asp:Panel ID="StaffReportPanel" runat="server"  align ="center">
        <table style="border-collapse:collapse;" id="StaffReportTable">
            <tr>
                <td colspan="2">
                    Staff Representative Voter RECORDS
                    <br />===========================<br /> 
                    Staff Voted
                    <br />---------------------------<br />
                    Staff Name &nbsp; &nbsp; Time of Voting
                    <br /><br />
                    <asp:PlaceHolder ID="PlaceHolderStaffVoted" runat="server"></asp:PlaceHolder>
                    <br />
                    <br />
                    <br />
                </td>
                </tr>
            <tr>
                <td colspan="2">
                    Staff Not Voted
                    <br />-------------------------<br />
                    Staff Name
                    <br /><br />
                    <asp:PlaceHolder ID="PlaceHolderStaff" runat="server"></asp:PlaceHolder>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <br />
    <br />

    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
    </div>
</asp:Content>
