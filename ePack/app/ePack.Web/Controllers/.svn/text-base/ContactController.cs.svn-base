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
    public class ContactController : BaseController
    {

        private readonly IContactService _contactService;
        private readonly IPostalCodeRetrieverService _postalCodeRetrieverService;

        public ContactController(IContactService service, IPostalCodeRetrieverService pcrs) 
        {
            _contactService = service;
            _postalCodeRetrieverService = pcrs;
        }

        [HttpGet]
        public ActionResult Index()
        {
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
        public ActionResult Index(ContactView view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //save contact
                    _contactService.Create(view);
                    return RedirectToAction("ContactSended");
                }
                catch (InvalidDomainModelException ex) 
                {
                    FillModelStateErrors(ex);
                }
            }

            // Simply return our view
            return View(view);
        }

        public ActionResult ContactSended()
        {
            return View();
        }
    }
}
