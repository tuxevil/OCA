using System.ComponentModel.DataAnnotations;
using ePack.Core;
using System.ComponentModel;
using ePack.ApplicationServices.Connector;

namespace ePack.ApplicationServices.Views
{
    public class ContactView : IContactView
    {
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Nombre requerido.")]
        [DisplayName("Nombre:")]
        public string FirstName
        { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Apellido requerido.")]
        [DisplayName("Apellido:")]
        public string LastName
        { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "Telefono requerido.")]
        [RegularExpression(@"^\+?\(?\d+\)?(\s|\-|\.)?\d{1,4}(\s|\-|\.)?\d{4}$", ErrorMessage = "Formato no válido (Ej: (011)-555-5555).")]
        [DisplayName("Telefono:")]
        public string Phone
        { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [Required(ErrorMessage = "E-mail requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-Mail no valido.")]
        [DisplayName("E-Mail:")]
        public string Email
        { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [DisplayName("Empresa:")]
        public string Company
        { get; set; }

        [StringLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        [RegularExpression(@"^(?<link>((?<prot>http:\/\/)*(?<subdomain>(www|[^\-\n]*)*)(\.)*(?<domain>[^\-\n]+)\.(?<after>[a-zA-Z]{2,3}[^>\n]*)))$", ErrorMessage = "Url no valida (Ej: www.oca.com.ar).")]
        [DisplayName("URL:")]
        public string WebSite
        { get; set; }

        [StringLength(4000, ErrorMessage = "Máximo 4000 caracteres.")]
        [Required(ErrorMessage = "Comentario requerido.")]
        [DisplayName("Comentario:")]
        public string Comment
        { get; set; }

        [DisplayName("Código Postal:")]
        [StringLength(4, ErrorMessage = "Máximo 4 caracteres.")]
        [PostalCodeRemote("IsValidPostalCode", "Contact", "postalCodeSuccess", ErrorMessage = "No existe ese código postal.")]
        [Required(ErrorMessage = "C.P. requerido.")]
        public string PostalCode { get; set; }
    }
}