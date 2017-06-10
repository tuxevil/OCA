using System.Web.Mvc;
using System.Collections.Generic;
using ePack.ApplicationServices;
using ePack.Core;
using Nybble.Security;
using SharpArch.Web.NHibernate;

namespace ePack.Web.Controllers
{
    [HandleError]
    public class ValidationController : BaseController
    {
        private readonly ISignInService _signInService;

        public ValidationController(ISignInService signInService) 
        { 
           this._signInService = signInService;
        }

        [Transaction]
        public ActionResult ConfirmEmail(string token)
        {
            if (ModelState.IsValid) {
                try 
                {
                    _signInService.ActivateUser(token);
                    return RedirectToAction("Thankyou");
                }
                catch (InvalidCredentialsException)
                {
                    
                }
            }

            return View();
        }

        public ActionResult Thankyou()
        {
            return View();
        }
    }
}
