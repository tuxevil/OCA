<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<RegisterView>" %>
<%@ Import Namespace="ePack.ApplicationServices.Views" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="form">
     <img src="/img/register3.png" />
    <div  class="thankyou">
        <img class="okhand" src="/img/okHand.png"/>
        <p><b>Te damos la bienvenida!</b></p>
        <p>Gracias por registrarte en Envíos Oca.</p>
        <p>A partir de ahora podrás disfrutar de una manera más ágil y sencilla de enviar y recibir<br />
            productos comercializados a través de internet.</p>
        <p>
        <b>Si comprás en Internet</b> podés conocer cómo recibir tus productos de manera segura<br />
        ingresando a la sección de <a href="<%= Url.RouteUrl(new { controller = "Compradores", action= "Index"}) %>">Compradores</a>.
        </p>
        <p>
        <b>Si sos vendedor</b>, ingresá en la sección <a href="<%= Url.RouteUrl(new { controller = "Vendedores", action= "Index"}) %>">Vendedores</a> y enterate
        cómo enviar tus artículos <br /> con todo el respaldo de OCA.
        </p>
        
        <p>
            También podés <b>solicitar ahora el contacto de uno de nuestros Asesores Comerciales.</b>
        </p>
        <a href="<%= Url.RouteUrl(new { controller = "Contact", action= "Index"}) %>"><img src="/img/contactBtn.png" /></a>
        
    </div>
</div>
    <img src="/img/registerBottom.png"/>
</asp:Content>

