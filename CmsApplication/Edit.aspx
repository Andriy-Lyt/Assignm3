<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" ValidateRequest="false" Inherits="CmsApplication.Edit" Title="Edit page" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 runat="server" id="h1SuccessMessage" style="display:none">Page succesfully updated</h1>

    <form runat="server" method="post">
        <table>
            <tr>               
                <td>Title</td>
                <td><input type="text" runat="server" id="itTitle" required /></td>
            </tr>
            <tr>
                <td>Body</td>
                <td>
                       <textarea rows="40" cols="80" runat="server" id="taBody" required></textarea>
                </td>
             </tr>        
        </table>
        <input type="submit" value="Update" />
    </form>
    </asp:Content>
