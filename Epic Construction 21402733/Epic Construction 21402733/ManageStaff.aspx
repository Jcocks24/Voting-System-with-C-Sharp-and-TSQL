<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="Epic_Construction_21402733.ManageStaff" %>

<asp:Content ID="ContentManageStaff" ContentPlaceHolderID="ContentPlaceHolderManageStaff" runat="server">
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

    <asp:Panel ID="PanelSelectStaff" runat="server" align="center">
                <br />
                <asp:Label ID="LabelSelectStaff" runat="server" Text="Select Staff"></asp:Label>
                <asp:DropDownList ID="DropDownListSelectStaff" runat="server" Width="347px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSelectStaff_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="ButtonAddStaff" runat="server" Text="Add" OnClick="ButtonAddStaff_Click" />
                <asp:Button ID="ButtonInsertStaff" runat="server" Text="Insert" OnClick="ButtonInsertStaff_Click" />
                <asp:Button ID="ButtonEditStaff" runat="server" Text="Edit" OnClick="ButtonEditStaff_Click" />
                <asp:Button ID="ButtonUpdateStaff" runat="server" Text="Update" OnClick="ButtonUpdateStaff_Click" />
                <asp:Button ID="ButtonDeleteStaff" runat="server" Text="Delete" OnClick="ButtonDeleteStaff_Click" />
            </asp:Panel>

            <asp:Panel ID="PanelStaffManage" runat="server" align="center">
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" id="StaffManageTable">
                    <caption>
                        <br />
                        <asp:Label ID="LabelStaffId" runat="server" Text="Staff ID"></asp:Label>
                        <asp:TextBox ID="TextBoxStaffId" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelStaffFirstName" runat="server" Text="First Name"></asp:Label>
                        <asp:TextBox ID="TextBoxStaffFirstName" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelStaffLastName" runat="server" Text="Last Name"></asp:Label>
                        <asp:TextBox ID="TextBoxStaffLastName" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelStaffUsername" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="TextBoxStaffUsername" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelStaffPassword" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="TextBoxStaffPassword" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelStaffEmail" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="TextBoxStaffEmail" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="LabelUsernameExists" runat="server"></asp:Label>
                    </caption>
                </table>
            </asp:Panel>

    <br />

    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
    </div>
</asp:Content>

