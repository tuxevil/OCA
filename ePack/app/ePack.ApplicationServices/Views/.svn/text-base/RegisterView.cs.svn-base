using System.ComponentModel.DataAnnotations;
using ePack.Core;
using System.ComponentModel;
using Nybble.Validators;
using ePack.ApplicationServices.Connector;
using ePack.Utils;
using Microsoft.Practices.ServiceLocation;

namespace ePack.ApplicationServices.Views
{
    public class RegisterView : IRegisterView
    {
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Comprobación requerida.")]
        [DisplayName("Comprobación de Contraseña:")]
        [RegularExpression(@"^.{6,99}$", ErrorMessage = "Mínimo de 6 caracteres.")]
        [EqualTo(OtherProperty = "Password", ErrorMessage = "Las contraseñas no son iguales.")]
        public string PasswordConfirm { get; set; }

        #region IRegisterView Members

        public string LegalName { get; set; }

        public string SiteAddress { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Nombre requerido.")]
        [DisplayName("Nombre:")]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Apellido requerido.")]
        [DisplayName("Apellido:")]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage="E-Mail requerido.")]
        [DisplayName("E-Mail:")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-Mail no válido.")]
        public string EmailAddress { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Nombre de usuario requerido.")]
        [DisplayName("Nombre de Usuario:")]
        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Contraseña requerida.")]
        [DisplayName("Contraseña:")]
        [RegularExpression(@"^.{6,99}$", ErrorMessage = "Mínimo de 6 caracteres.")]
        public string Password { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Empresa:")]
        public string Company { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Industria:")]
        public string Industry { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Dominio Web:")]
        [RegularExpression(@"^(?<link>((?<prot>http:\/\/)*(?<subdomain>(www|[^\-\n]*)*)(\.)*(?<domain>[^\-\n]+)\.(?<after>[a-zA-Z]{2,3}[^>\n]*)))$", ErrorMessage = "Url no valida (Ej: www.oca.com.ar).")]
        public string Website { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Cargo:")]
        public string Position { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [RegularExpression(@"((\(?\d{2,5}\)?)?(\d|-| )?(15((\d|-| ){6,13})))", ErrorMessage = "Formato no válido (Ej:(011)-155-555-5555).")]
        [RequiredOneOf(OtherProperty = "Phone", ErrorMessage = "Teléfono o Celular deben ser completados.")]
        [RequiredWith(OtherProperty = "PreCelPhone", ErrorMessage = "Complete todos los campos del celular.")]
        [DisplayName("Celular:")]
        public string CelPhone { get; set; }

        [StringLength(10, ErrorMessage = "Máximo 10 caracteres.")]
        public string PreCelPhone { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Teléfono:")]
        [RegularExpression(@"^\+?\(?\d+\)?(\s|\-|\.)?\d{1,4}(\s|\-|\.)?\d{4}$", ErrorMessage = "Formato no válido (Ej: (011)-555-5555).")]
        [RequiredWith(OtherProperty = "PrePhone", ErrorMessage = "Complete todos los campos del teléfono.")]
        public string Phone { get; set; }

        [StringLength(10, ErrorMessage = "Máximo 10 caracteres.")]
        public string PrePhone { get; set; }

        [DisplayName("Actividad en Internet")]
        public InternetActivity InternetActivity { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Número de CUIT:")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{8}-[0-9]$", ErrorMessage = "CUIT no válido (Ej: 55-55555555-5).")]
        public string CuitNumber { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Número de Cuenta OCA:")]
        [RegularExpression(@"^[0-9]{7}$", ErrorMessage = "N° OCA no válido (Ej: 7777777).")]
        public string OcaNumber { get; set; }

        [DisplayName("Quiero ser contactado por un asistente comercial")]
        public bool ContactMe{ get; set; }

        [DisplayName("Quiero recibir información sobre e-Pak OCA")]
        public bool GetInformation{ get; set; }

        [DisplayName("Código Postal:")]
        [StringLength(4, ErrorMessage = "Máximo 4 caracteres.")]
        [PostalCodeRemote("IsValidPostalCode", "Register", "postalCodeSuccess", ErrorMessage = "No existe ese código postal.")]
        [Required(ErrorMessage = "C.P. requerido.")]
        public string PostalCode { get; set; }

        #endregion
        
    }
}