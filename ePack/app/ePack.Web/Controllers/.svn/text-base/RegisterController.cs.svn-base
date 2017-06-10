using System.Web.Mvc;
using System.Collections.Generic;
using ePack.ApplicationServices;
using ePack.Core;
using ePack.ApplicationServices.Views;
using Nybble.Utils;
using Nybble.Security;
using SharpArch.Web.NHibernate;
using ePack.ApplicationServices.Connector;

namespace ePack.Web.Controllers
{
    [HandleError]
    public class RegisterController : BaseController
    {
        private readonly IAccountService _customerCreationService;
        private readonly IInternetActivityService _internetActivityService;
        private readonly IPostalCodeRetrieverService _postalCodeRetrieverService;
        public RegisterController(IAccountService ccs,
            IAuthenticationService<IUserContext> authService,
            ISignInService signInService, IInternetActivityService ias, IPostalCodeRetrieverService pcrs
            ) 
        { 
           this._customerCreationService = ccs;
            this._internetActivityService = ias;
            this._postalCodeRetrieverService = pcrs;
        }

        [HttpGet]
        public ActionResult Register()
        {
            List<SelectListItem> lst = _internetActivityService.InternetActivityList();
            ViewData["InternetActivity"] = lst;
            return View();
        }

        public ActionResult FindByPostalCode(string postalCode)
        {
            return Json(_postalCodeRetrieverService.FindCityFromPostalCode(postalCode), JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsValidPostalCode(string postalCode)
        {
            return Json(PostalCodeRemoteAttribute.ValidatePostalCode(postalCode), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Transaction]
        public ActionResult Register(RegisterView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerCreationService.Register(view);

                    return RedirectToAction("Confirmation");
                }
                catch (InvalidDomainModelException ex)
                {
                    FillModelStateErrors(ex);
                }
                catch (UserAlreadyExistException)
                {
                    ModelState.AddModelError("UserName", "El usuario ya existe.");
                }
                catch (EmailAlreadyExistException)
                {
                    ModelState.AddModelError("EmailAddress", "El e-mail ya existe.");
                }
                catch (PasswordNotMatchException)
                {
                    ModelState.AddModelError("Password", "Las contraseñas no son iguales.");
                }
            }

            // Simply return our view
            List<SelectListItem> lst = _internetActivityService.InternetActivityList();
            ViewData["InternetActivity"] = lst;
            return View(view);
        }

        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
