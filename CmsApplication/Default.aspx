<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CmsApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Repeater runat="server" ID="rptMenu">
        <ItemTemplate>
            <a href="View.aspx?pageId=<%#Eval("Id")%>"><%#Eval("Title")%></a>
        </ItemTemplate>
    </asp:Repeater>

    <div>
        <p>Manage pages</p>
        <a href="AddNew.aspx" target="_blank">Add new</a>
    </div>

    <table border="1">
      <thead>
        <tr>
           <th>Title</th> 
            <th>Publication date</th>
            <th colspan="2">Action</th>
        </tr>
       </thead>
        
        <asp:Repeater runat="server" ID="rptPages">
        <ItemTemplate>
            <tr>
                <td>
                    <%#Eval("Title")%>
                </td>
                <td>
                    <%#Eval("PublishDate")%>
                </td>
                <td>
                    <a href="Edit.aspx?pageId=<%#Eval("Id")%>" target="_blank">Edit</a>
                </td>
                <td>
                    <a href="Delete.aspx?pageId=<%#Eval("Id")%>">Delete</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>

    </table>


</asp:Content>
