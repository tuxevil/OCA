<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<IList<ePack.Core.Feed>>" %>
<%@ Import Namespace="ePack.Web.Controllers" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
        <div class="feedRight">
        <% Html.RenderPartial("LastFeeds"); %>
        </div>
        
        <div class="sellers">
            <h1>¿Vendés on line?</h1>
            <p>
            Con OCA contás con la mejor plataforma de distribución con cobertura nacional para que tus productos 
            lleguen en tiempo y forma a manos de tus clientes.</p>
            <p>
            Ahora con el servicio e-Pak OCA podrás elegir la modalidad de entrega más cómoda y ágil, al             domicilio particular, laboral o con retiro por parte del destinatario en cualquiera de nuestras             sucursales de todo el país. Una ventaja importante es que tus compradores no sólo podrán pagar el             envío o el producto que vendiste, sino que también podremos mostrar en nuestra sucursal lo que están             recibiendo, asegurando 100% su satisfacción.</p>
            <p>
            Además, e-Pak OCA ofrece un <b>Programa de Beneficios exclusivos</b> para los usuarios <b>Certificados e-Pak</b> 
            quienes podrán acumular “kilómetros” por cada envío realizado por OCA, que luego podrán canjear por 
            envíos sin cargo.</p>
           <p>
            Sumate a e-Pak OCA y dale a tus ventas en Internet más seguridad con mayores beneficios para vos y 
            tus clientes.</p>
            <p class="floatingP" >Solicitá el contacto de nuestros asesores desde <a href="<%= Url.RouteUrl(new { controller = "Contact", action= "Index"}) %>">aquí</a></p>
            <a href="<%= Url.RouteUrl(new { controller = "Register", action= "Register"}) %>">
                <img src="/img/registerBtn.png"/>
            </a>
        </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript" >
        $(document).ready(function() {
            $("#sellerTab").addClass("tabhovered");
            $("#arrowSeller").removeClass("tabArrow");
        });
    </script>
</asp:Content>
