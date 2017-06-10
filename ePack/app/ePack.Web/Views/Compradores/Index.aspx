<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<IList<ePack.Core.Feed>>" %>
<%@ Import Namespace="ePack.Web.Controllers" %>
<%@ Import Namespace="MvcContrib.UI.Grid"%>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    
        <div class="feedRight">
        <% Html.RenderPartial("LastFeeds"); %>
        </div>

        <div class="sellers">
            <h1>¿Comprás on line?</h1>
            <p>
            Ahora, con OCA, podés elegir la forma en que recibirás los productos que comprás por Internet, 
            ofreciéndote la entrega al domicilio que elijas o directamente en cualquiera de nuestras sucursales 
            OCA de todo el país.</p>
            <p>
            Además, te daremos un aviso por mail o SMS para que sepas el momento en que tu producto se encuentre 
            disponible en nuestra sucursal.</p>
            <p>
            Antes de hacer una oferta o compra a través de Internet, podés asegurarte que el producto sea el 
            que buscás ya que con el servicio e-Pak OCA, te va a llegar sin inconvenientes.</p>
            <p>
            Siempre investigá sobre el producto que vas a comprar, comparando detalles y precios de artículos 
            similares de diferentes vendedores y no olvides de preguntar por la manera en la que te van a 
            entregar lo que has comprado.</p>
            <p>
            La comunidad de compradores en Internet puede utilizar la plataforma de e-Pak OCA para consultar el 
            seguimiento de su envío vía web una vez realizada su compra.</p>
            <p>
            Ahora, con e-Pak OCA te ayudamos a que tus compras por Internet, te lleguen siempre y más aún, 
            podrás pagar el envío y el costo del producto en el mismo momento de la entrega.</p>
            <p class="floatingPBuyer">Solicitá el contacto de nuestros asesores desde <a href="<%= Url.RouteUrl(new { controller = "Contact", action= "Index"}) %>">aquí</a></p>

                <a href="<%= Url.RouteUrl(new { controller = "Register", action= "Register"}) %>">
                    <img src="/img/registerBtn.png"/>
                </a>
        </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript" >
        $(document).ready(function() {
        $("#buyerTab").addClass("tabhovered");
        $("#arrowBuyer").removeClass("tabArrow");
        });
    </script>
</asp:Content>
