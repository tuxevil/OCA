<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
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
            <p class="infoText"><b>Beneficios</b><br/>                • Entrega a domicilio o en sucursales OCA de todo el país.<br/>                • Poder mostrar el producto que vendiste en sucursales OCA.<br/>                • Cobrar el importe de tus productos por contrareembolso en cheque o efectivo.<br/>                • Cobrar el 100% del costo del envío al destinatario de tus productos.<br/>                • Seguimiento on line de tus envíos.<br/>                • Calculador on line del costo de transporte de tus envíos.<br/>                • Solicitud on line de retiro a domicilio.<br/>                • Emisión on line de etiquetas para adherir al envío.<br/>
            </p>
            <br />
            <a href="<%= Url.RouteUrl(new { controller = "Vendedores", action= "Index"}) %>">Más Información >></a>
            <img class="sellInfoBottom" src="/img/infoBottom.png"/>
    </div>
    <div style="width:360px;float:left;">
            <div class="buyOnline">
                <img src="/img/buyOnline.png"/>
                <p class="infoText">                <b>Beneficios</b><br/>                • Entregamos a tu domicilio (particular o laboral) o en la sucursal OCA de todo el país más próxima a tu domicilio.<br/>                • Podrás ver el producto que compraste en nuestra sucursal.<br/>                • Aviso por e-mail o SMS cuando el producto que compraste está disponible en la sucursal OCA.<br/>                • Servicio de pago contrareembolso en cheque o efectivo.<br/>                • Podrás pagar el costo del envío y desde tu domicilio.<br/>                • Podrás realizar el seguimiento on line del envío.<br/>
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
