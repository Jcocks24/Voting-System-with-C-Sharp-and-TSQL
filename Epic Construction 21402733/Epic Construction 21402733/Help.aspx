<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Epic_Construction_21402733.Help" %>

<asp:Content ID="ContentHelp" ContentPlaceHolderID="ContentPlaceHolderHelp" runat="server">
    <nav id="nav">  
        <ul>  
            <li><a href="Home.aspx">Home</a></li>  
            <li><a href="Staff.aspx">Staff</a></li>  
            <li><a href="Admin.aspx">Administrator</a></li>  
            <li><a href="Help.aspx">Help</a></li>
        </ul>
    </nav>

    <asp:Panel ID="HelpPanel" runat="server"  align ="center">
        <table id="HelpTable">
            <tr>
                <td >
                    <br /><br />
                    <asp:PlaceHolder ID="PlaceHolderHelp" runat="server"></asp:PlaceHolder>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
