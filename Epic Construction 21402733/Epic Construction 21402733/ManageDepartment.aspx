<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageDepartment.aspx.cs" Inherits="Epic_Construction_21402733.ManageDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderManageDepartment" runat="server">
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

    <asp:Panel ID="PanelSelectDepartment" runat="server" align="center">
                <br />
                <asp:Label ID="LabelSelectDepartment" runat="server" Text="Select Department"></asp:Label>
                <asp:DropDownList ID="DropDownListSelectDepartment" runat="server" Width="347px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSelectDepartment_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="ButtonAddStaff" runat="server" Text="Add" OnClick="ButtonAddStaff_Click"/>
                <asp:Button ID="ButtonInsertStaff" runat="server" Text="Insert" OnClick="ButtonInsertStaff_Click"/>
                <asp:Button ID="ButtonEditStaff" runat="server" Text="Edit" OnClick="ButtonEditStaff_Click"/>
                <asp:Button ID="ButtonUpdateStaff" runat="server" Text="Update" OnClick="ButtonUpdateStaff_Click"/>
            </asp:Panel>

            <asp:Panel ID="PanelDepartmentManage" runat="server" align="center">
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;" id="StaffManageTable">
                    <caption>
                        <br />
                        <asp:Label ID="LabelDepartmentId" runat="server" Text="Department ID"></asp:Label>
                        <asp:TextBox ID="TextBoxDepartmentId" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="LabelDepartmentName" runat="server" Text="Department Name"></asp:Label>
                        <asp:TextBox ID="TextBoxDepartmentName" runat="server"></asp:TextBox>
                    </caption>
                </table>
            </asp:Panel>

    <br />

    <div id="Buttons" align="center">
        <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
    </div>
</asp:Content>

