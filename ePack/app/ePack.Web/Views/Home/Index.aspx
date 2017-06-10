﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<IList<ePack.Core.Feed>>" %>
<%@ Import Namespace="ePack.Web.Controllers" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="login">
        <div style="float:right;">
            <a href="<%= Url.RouteUrl(new { controller = "Register", action= "Register"}) %>">
                <img src="/img/violetRegister.png" />
            </a>
        </div>
        <img class="banner" src="/img/violetBanner.png"/>
    </div>
    
    <div style="margin-left:9px;" >
    <div class="sellOnline">
            <img src="/img/sellOnline.png"/>
            <img src="/img/violetHand.gif"/> <br/>
            <p class="infoText"><b>Beneficios</b><br/>
            </p>
            <br />
            <a href="<%= Url.RouteUrl(new { controller = "Vendedores", action= "Index"}) %>">Más Información >></a>
            <img class="sellInfoBottom" src="/img/infoBottom.png"/>
    </div>
    <div style="width:360px;float:left;">
            <div class="buyOnline">
                <img src="/img/buyOnline.png"/>
                <p class="infoText">
                </p><br />
                <a href="<%= Url.RouteUrl(new { controller = "Compradores", action= "Index"}) %>">Más Información >></a>
               <img class="buyInfoBottom" src="/img/infoBottom.png"/>
            </div>
            <div class="ecommerceBanner">
                <a href="<%= Url.RouteUrl(new { controller = "Register", action= "Register"}) %>">
                    <img src="/img/ecommerceday.gif" />
                </a>
            </div>    
    </div>
    <div style="width:232px;float:left;">
        <% Html.RenderPartial("LastFeeds"); %>
    </div>
    </div>
    <div style="clear:both"></div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript" >
        $(document).ready(function() {
        FirstTabHovered();
        $(".firstTab").unbind("mouseleave");
        $("#arrowHome").removeClass("tabArrow");
        });
    </script>
</asp:Content>