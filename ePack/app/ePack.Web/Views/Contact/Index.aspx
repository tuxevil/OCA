<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<ContactView>" %>
<%@ Import Namespace="ePack.ApplicationServices.Views" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Index", "Contact", FormMethod.Post)) { %>

<div class="contactImage">
    <img src="/img/contactImage.jpg" />
</div>

<div class="contactForm">
    <h1>Contacto</h1>
    <h2>Si quéres contactarte con nosotros, te agradecemos que completes y envíes<br />
        el siguiente formulario:
    </h2>
    <fieldset>
    
        <div>
        <label for="FirstName" class="required">Nombre:</label>
        <%= Html.TextBoxFor(x => x.FirstName) %>
         <%= Html.ValidationMessageFor(x=>x.FirstName) %>
        </div>
        
        <div>
        <label for="LastName" class="required">Apellido:</label>
        <%= Html.TextBoxFor(x => x.LastName) %>
         <%= Html.ValidationMessageFor(x=>x.LastName) %>
        </div>
        
        <div>
        <label for="Phone" class="required">Teléfono:</label>
        <%= Html.TextBoxFor(x => x.Phone) %>
        <%= Html.ValidationMessageFor(x=>x.Phone) %>

        </div>
        
        <div>
        <label for="EmailAddress" class="required">E-mail:</label>
        <%= Html.TextBoxFor(x => x.Email) %>
        <%= Html.ValidationMessageFor(x=>x.Email) %>
        </div>
        
        <div>
        <%= Html.LabelFor(x => x.Company) %>
        <%= Html.TextBoxFor(x => x.Company) %>
        <%= Html.ValidationMessageFor(x=>x.Company) %>
        </div>
        
        <div>
        <%= Html.LabelFor(x => x.WebSite) %>
        <%= Html.TextBoxFor(x => x.WebSite) %>
        <%= Html.ValidationMessageFor(x=>x.WebSite) %>
        </div>
        
        <div>
        <label for="PostalCode" class="required">Código Postal:</label>
        <%= Html.TextBoxFor(x => x.PostalCode)%>
        <%= Html.ValidationMessageFor(x=>x.PostalCode) %>
        <span id="location"></span>
        </div>
        
        <div>
        <label for="Comment" class="required">Comentario:</label>
        <%= Html.TextAreaFor(x => x.Comment) %>
        <%= Html.ValidationMessageFor(x=>x.Comment) %>

        </div>
        
         <input class="sendBtn" type="image" src="/img/sendBtn.jpg" value="Enviar" />
    </fieldset>
</div>

<%} %>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript" src="/Scripts/jquery.validate.min.js"></script>
    <script language="javascript" type="text/javascript" src="/Scripts/MicrosoftMvcJQueryValidation.js"></script>
    <script language="javascript" type="text/javascript" src="/Scripts/nybble.validators.js"></script>
    <script language="javascript" type="text/javascript" >
        $(document).ready(function() {
        LastTabHovered();
        $(".lastTab").unbind("mouseleave");
        $("#arrowContact").removeClass("tabArrow");
        });
    </script>
</asp:Content>
