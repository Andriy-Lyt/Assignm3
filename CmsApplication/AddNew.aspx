<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="CmsApplication.AddNew" ValidateRequest="false" Title = "Add new page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 runat="server" id="h1SuccessMessage" style="display:none">Page succesfully created, check it on the <a href="Default.aspx"> main page</a></h1>

    <form runat="server" method="post">
        <table>
            <tr>               
                <td>Title</td>
                <td><input type="text" runat="server" id="itTitle" required /></td>
            </tr>
            <tr>
                <td>Body</td>
                <td>|
                       <textarea rows="40" cols="80" runat="server" id="taBody" required ></textarea>
                </td>
             </tr>        
        </table>
        <input type="submit" value="Add new" />
    </form>
</asp:Content>
