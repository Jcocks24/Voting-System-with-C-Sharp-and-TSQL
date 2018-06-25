<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageCandidate.aspx.cs" Inherits="Epic_Construction_21402733.ManageCandidate" %>

<asp:Content ID="ContentManageCandidate" ContentPlaceHolderID="ContentPlaceHolderManageCandidate" runat="server">
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

    <asp:Panel ID="PanelSelectCandidate" runat="server" align="center">
                <br />
                <asp:Label ID="LabelSelectCandidate" runat="server" Text="Select Candidate"></asp:Label>
                <asp:DropDownList ID="DropDownListSelectCandidate" runat="server" Width="347px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSelectCandidate_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="ButtonAddCandidate" runat="server" Text="Add" OnClick="ButtonAddCandidate_Click"/>
                <asp:Button ID="ButtonInsertCandidate" runat="server" Text="Insert" OnClick="ButtonInsertCandidate_Click"/>
                <asp:Button ID="ButtonEditCandidate" runat="server" Text="Edit" OnClick="ButtonEditCandidate_Click"/>
                <asp:Button ID="ButtonUpdateCandidate" runat="server" Text="Update" OnClick="ButtonUpdateCandidate_Click"/>
                <asp:Button ID="ButtonDeleteCandidate" runat="server" Text="Delete" OnClick="ButtonDeleteCandidate_Click"/>
            </asp:Panel>

    <asp:Panel ID="PanelCandidateManage" runat="server" align="center">
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" id="CandidateManageTable">
                    <caption>
                        <br />
                        <asp:Label ID="LabelCandidateId" runat="server" Text="Candidate ID"></asp:Label>
                        <asp:TextBox ID="TextBoxCandidateId" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelCandidateFirstName" runat="server" Text="First Name"></asp:Label>
                        <asp:TextBox ID="TextBoxCandidateFirstName" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCandidateLastName" runat="server" Text="Last Name"></asp:Label>
                        <asp:TextBox ID="TextBoxCandidateLastName" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCandidateDepartment" runat="server" Text="Department"></asp:Label>
                        <asp:DropDownList ID="DropDownListDepartment" runat="server" Width="140px"></asp:DropDownList>
                        <br />
                        <asp:Label ID="LabelCandidateCode" runat="server" Text="Code"></asp:Label>
                        <asp:TextBox ID="TextBoxCandidateCode" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelCodeExists" runat="server"></asp:Label>
                    </caption>
                </table>
            </asp:Panel>

    <br />

    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
    </div>
</asp:Content>
