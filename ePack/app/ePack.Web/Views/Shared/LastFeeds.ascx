<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IList<ePack.Core.Feed>>" %>
    <div class="tips">
        <img src="/img/clipsLogisticaTop.png"/>
        <% foreach (ePack.Core.Feed f in Model) { %>
            <div class="blog-item"><a href="<%=Url.RouteUrl(new { controller = "Blog", action= "Index"})%>#<%= f.Id %>"> <%= f.FormattedTitle%> </a></div>
        <% } %>
    </div>
    <img class="tipBottom" src="/img/clipsLogisticaBottom.png"/>
