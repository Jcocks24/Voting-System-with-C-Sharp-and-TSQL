<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Epic_Construction_21402733.Admin" %>

<asp:Content ID="ContentAdmin" ContentPlaceHolderID="ContentPlaceHolderAdmin" runat="server">
    <nav id="nav">  
        <ul>  
            <li><a href="Home.aspx">Home</a></li>  
            <li><a href="Staff.aspx">Staff</a></li>  
            <li><a href="Admin.aspx">Administrator</a></li>  
            <li><a href="Help.aspx">Help</a></li>  
        </ul>  
    </nav>

    <br />
    <%-- Admin Login Table --%>
        <table style="border-collapse:collapse;" id="AdminLoginTable">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td align="center" colspan="2">Log In</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LoginAdminUsernameLabel" runat="server" AssociatedControlID="LoginAdminUsername">Username:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="LoginAdminUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LoginAdminUsernameRequired" runat="server" ControlToValidate="LoginAdminUsername" ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="AdminLoginTable">Username is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LoginAdminPasswordLabel" runat="server" AssociatedControlID="LoginAdminPassword">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="LoginAdminPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LoginAdminPasswordRequired" runat="server" ControlToValidate="LoginAdminPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="AdminLoginTable">Password is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureTextAdminLogin" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="LoginAdminButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="StaffLoginTable" OnClick="LoginAdminButton_Click" />
                                <br />
                                <br />
                                <asp:Label ID="LoginAdminSuccess" runat="server"></asp:Label>
                                <br />
                                <asp:TextBox ID="TextBoxAdminFirstName" runat="server" Visible="False"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="TextBoxAdminLastName" runat="server" Visible="False"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="TextBoxAdminId" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
</asp:Content>
