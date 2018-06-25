<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Voting.aspx.cs" Inherits="Epic_Construction_21402733.Voting" %>

<asp:Content ID="ContentVoting" ContentPlaceHolderID="ContentPlaceHolderVoting" runat="server">
    <header id="Welcome">  
        <h3>
            <asp:Label ID="LabelStaffName" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="LabelDate" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LabelDateRange" runat="server"></asp:Label>
        </h3>
    </header>
    <div align="center">
        
        <asp:GridView ID="GridViewCandidates" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceCandidate">
            <Columns>
                <asp:BoundField DataField="CandidateFName" HeaderText="Candidate First Name" SortExpression="CandidateFName" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateLName" HeaderText="Candidate Last Name" SortExpression="CandidateLName" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateDepartment" HeaderText="Candidate Department" SortExpression="CandidateDepartment" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CandidateCode" HeaderText="Candidate Code" SortExpression="CandidateCode" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceCandidate" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\VotingSystemDatabase.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [CandidateFName], [CandidateLName], [CandidateDepartment], [CandidateCode] FROM [CandidateTable]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="LabelSelectCandidate" runat="server" Text="To select a Candidate select their Code"></asp:Label>
        <br />
        <asp:DropDownList ID="DropDownListCandidateCode" runat="server" DataSourceID="SqlDataSourceCandidate" DataTextField="CandidateCode" DataValueField="CandidateCode">
        </asp:DropDownList>
        
        <br />
        <br />
        <asp:Label ID="LabelOutsideDateRange" runat="server"></asp:Label>
        <br />

        <asp:Button ID="ButtonConfirmCandidate" runat="server" OnClick="ButtonConfirmCandidate_Click" Text="Confirm Candidate" Width="130px" />

        <br />
        <br />
        <br />

        <asp:Button ID="ButtonLogout" runat="server" Text="Logout" OnClick="ButtonReturnAdmin_Click" Width="52px" />
    </div>
</asp:Content>

