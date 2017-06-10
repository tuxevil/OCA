<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true"
    Inherits="System.Web.Mvc.ViewPage<RegisterView>" %>
<%@ Import Namespace="ePack.ApplicationServices.Views" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("Register", "Register", FormMethod.Post)) { %>

<div class="form">
<img src="/img/register1.png" />
    <fieldset>
        <div>
        <label for="EmailAddress" class="required">E-mail:</label>
        <%= Html.TextBoxFor(x => x.EmailAddress) %>
        <%= Html.ValidationMessageFor(x=>x.EmailAddress) %>
        </div>
        
        <div>
        <label for="UserName" class="required">Nombre de Usuario:</label>
        <%= Html.TextBoxFor(x => x.UserName) %>
         <%= Html.ValidationMessageFor(x=>x.UserName) %>
        </div>
        
        <div>
        <label for="Password" class="required">Contraseña:</label>
        <%= Html.PasswordFor(x => x.Password)%>
         <%= Html.ValidationMessageFor(x=>x.Password) %>
        </div>
        
        <div>
        <label for="PasswordConfirm" class="required">Comprobación de Contraseña:</label>
        <%= Html.PasswordFor(x => x.PasswordConfirm)%>
         <%= Html.ValidationMessageFor(x=>x.PasswordConfirm) %>
        </div>
        
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
        <%= Html.LabelFor(x => x.Company) %>
        <%= Html.TextBoxFor(x => x.Company) %>
        </div>
        
        <div>
        <%= Html.LabelFor(x => x.Industry) %>
        <%= Html.TextBoxFor(x => x.Industry) %>
        </div>
        
        <div>
        <%= Html.LabelFor(x => x.Website) %>
        <%= Html.TextBoxFor(x => x.Website) %>
         <%= Html.ValidationMessageFor(x=>x.Website) %>
        </div>
            
        <div>
        <%= Html.LabelFor(x => x.Position) %>
        <%= Html.TextBoxFor(x => x.Position) %>
        </div>
        
        <div>
        <label for="Phone" class="required">Teléfono:</label>
        <%= Html.TextBoxFor(x => x.PrePhone, new { @class = "shortInput" })%>&nbsp;
        <%= Html.TextBoxFor(x => x.Phone, new { @class = "postShortInput" })%>
         <%= Html.ValidationMessageFor(x=>x.Phone) %>
         <%= Html.ValidationMessageFor(x=>x.PrePhone) %>
        </div>
        
        <div>
        <label for="CelPhone" class="required">Celular:</label>
        <%= Html.TextBoxFor(x => x.PreCelPhone, new { @class = "shortInput" })%>&nbsp;
        <%= Html.TextBoxFor(x => x.CelPhone, new { @class = "postShortInput", @Value = "15"})%>
         <%= Html.ValidationMessageFor(x=>x.CelPhone) %>
         <%= Html.ValidationMessageFor(x=>x.PreCelPhone) %>
        </div>
        <div>
        <label for="PostalCode" class="required">Código Postal:</label>
        <%= Html.TextBoxFor(x => x.PostalCode)%>
        <%= Html.ValidationMessageFor(x=>x.PostalCode) %>
        <span id="location"></span>
        </div><br />
        <div class="radioLabel">
        <%= Html.LabelFor(x => x.InternetActivity) %>
         <%foreach (SelectListItem listItem in (List<SelectListItem>)ViewData["InternetActivity"])
            {%>
                <%=Html.RadioButton("InternetActivity", listItem.Value, listItem.Selected, new { @class = "radioInput" }) + " " + listItem.Text%> <br />
            <%} %>
        </div>
        
        <label>¿Eres un USUARIO CON CUENTA OCA?</label><br /><br />

        <div>
        <%= Html.LabelFor(x => x.CuitNumber) %>
        <%= Html.TextBoxFor(x => x.CuitNumber) %>
         <%= Html.ValidationMessageFor(x=>x.CuitNumber) %>
        </div>
        
        <div>
        <%= Html.LabelFor(x => x.OcaNumber) %>
        <%= Html.TextBoxFor(x => x.OcaNumber) %>
        <%= Html.ValidationMessageFor(x=>x.OcaNumber) %>
        </div>
        
        
    </fieldset>
</div>
<div class ="longForm">
<fieldset>
        <div>
        <%= Html.CheckBoxFor(x => x.ContactMe, new { @checked = "checked" })%>
        <%= Html.LabelFor(x => x.ContactMe) %>
        </div>
        
        <div>
        <%= Html.CheckBoxFor(x => x.GetInformation, new { @checked = "checked" })%>
        <%= Html.LabelFor(x => x.GetInformation) %>
        </div>
       
        <input id="sendBtn" class="registerBtn" type="image" src="/img/sendBtn.png" value="Enviar" />
    </fieldset>
</div>
<img src="/img/registerBottom.png"/>

<%} %>

</asp:Content>

<asp:Content ID="scripts" ContentPlaceHolderID="ScriptPlaceHolder" runat="server">
    <script language="javascript" type="text/javascript" src="/Scripts/jquery.validate.min.js"></script>
    <script language="javascript" type="text/javascript" src="/Scripts/MicrosoftMvcJQueryValidation.js"></script>
    <script language="javascript" type="text/javascript" src="/Scripts/nybble.validators.js"></script>
</asp:Content>
