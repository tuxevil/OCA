<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<IList<ePack.Core.Feed>>" %>
<%@ Import Namespace="ePack.Web.Controllers" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
        <div class="blogContainer">
        <h1>Blog</h1>
        <% foreach (ePack.Core.Feed f in Model) { %>
            <img class="blogTop" src="/img/blogTop.png" />
            <div class="item">
                <a name="#<%=f.Id%>" />
                <h2><a href="<%=f.FeedUrl%>" target="_blank"><%= f.Title %></a></h2>
                <h3>Publicado el <%=f.DatePublished.ToShortDateString() %></h3>
                <p><%=f.FeedData %></p>
            </div>
            <img class="blogBottom" src="/img/blogBottom.png" />
       <% } %>
        </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript" >
        $(document).ready(function() {
        $("#blogTab").addClass("tabhovered");
        $("#arrowBlog").removeClass("tabArrow");
        });
    </script>
</asp:Content>

