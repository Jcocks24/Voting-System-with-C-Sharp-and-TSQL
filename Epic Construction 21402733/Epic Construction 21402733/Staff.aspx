<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Epic_Construction_21402733.Staff" %>

<asp:Content ID="ContentStaff" ContentPlaceHolderID="ContentPlaceHolderStaff" runat="server">
    <%-- Navigation Bar --%>
    <nav id="nav">  
        <ul>  
            <li><a href="Home.aspx">Home</a></li>  
            <li><a href="Staff.aspx">Staff</a></li>  
            <li><a href="Admin.aspx">Administrator</a></li>  
            <li><a href="Help.aspx">Help</a></li>  
        </ul>  
    </nav>

    <br />
    <%-- Staff Login Table --%>
        <table style="border-collapse:collapse;" id="StaffLoginTable">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td align="center" colspan="2">Log In</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LoginStaffUsernameLabel" runat="server" AssociatedControlID="LoginStaffUsername">Username:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="LoginStaffUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LoginStaffUsernameRequired" runat="server" ControlToValidate="LoginStaffUsername" ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="StaffLoginTable">Username is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LoginStaffPasswordLabel" runat="server" AssociatedControlID="LoginStaffPassword">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="LoginStaffPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LoginStaffPasswordRequired" runat="server" ControlToValidate="LoginStaffPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="StaffLoginTable">Password is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureTextStaffLogin" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="LoginStaffButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="StaffLoginTable" OnClick="LoginButton_Click" />
                                <br />
                                <br />
                                <asp:Label ID="LabelLoginVoted" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="LoginStaffSuccess" runat="server"></asp:Label>
                                <br />
                                <asp:TextBox ID="TextBoxStaffFirstName" runat="server" Visible="False"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="TextBoxStaffLastName" runat="server" Visible="False"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="TextBoxStaffId" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    <br />
    <%-- Staff Registration Table --%>
        <table style="border-collapse:collapse;" id="StaffRegisterTable">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td align="center" colspan="2">Register</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="RegisterStaffFirstNameLabel" runat="server" AssociatedControlID="RegisterStaffFirstname">First Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RegisterStaffFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RegisterStaffFirstNameRequired" runat="server" ControlToValidate="RegisterStaffFirstName" ErrorMessage="First Name is required." ToolTip="First Name is required." ValidationGroup="StaffRegisterTable">First Name is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="RegisterStaffLastNameLabel" runat="server" AssociatedControlID="RegisterStaffLastName">Last Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RegisterStaffLastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RegisterStaffLastNameRequired" runat="server" ControlToValidate="RegisterStaffLastName" ErrorMessage="Last Name is required." ToolTip="Last Name is required." ValidationGroup="StaffRegisterTable">Last Name is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="RegisterStaffUsernameLabel" runat="server" AssociatedControlID="RegisterStaffUsername">Username:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RegisterStaffUsername" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RegisterStaffUsernameRequired" runat="server" ControlToValidate="RegisterStaffUsername" ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="StaffRegisterTable">Username is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="RegisterStaffPasswordLabel" runat="server" AssociatedControlID="RegisterStaffPassword">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RegisterStaffPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RegisterStaffPasswordRequired" runat="server" ControlToValidate="RegisterStaffPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="StaffRegisterTable">Password is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="RegisterStaffEmailLabel" runat="server" AssociatedControlID="RegisterStaffEmail">Email:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="RegisterStaffEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RegisterStaffEmailRequired" runat="server" ControlToValidate="RegisterStaffEmail" ErrorMessage="Email is required." ToolTip="Email is required." ValidationGroup="StaffRegisterTable">Email is Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureTextStaffRegister" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="RegisterStaffButton" runat="server" CommandName="Login" Text="Register" ValidationGroup="StaffRegisterTable" OnClick="RegisterStaffButton_Click"/>
                                <br />
                                <br />
                                <asp:Label ID="LabelUsernameExists" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="RegisterStaffSuccess" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
</asp:Content>
