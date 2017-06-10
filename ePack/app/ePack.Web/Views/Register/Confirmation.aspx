<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<RegisterView>" %>
<%@ Import Namespace="ePack.ApplicationServices.Views" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="form">
    <div class="confirmRegistration">
        <img src="/img/register2.png" />
        <p>Un mensaje de verificación ha sido enviado a la dirección de e-mail que ingresaste en el formulario de registro.</p>
        <p><b>Completá la activación de tu cuenta haciendo clic en el link que recibiste por e-mail.</b></p>
        </div>
</div>
    <img src="/img/registerBottom.png"/>

</asp:Content>

