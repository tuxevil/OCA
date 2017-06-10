using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Nybble.Security;
using Nybble.Utils;
using SharpArch.Core.CommonValidator;
using Microsoft.Practices.ServiceLocation;

namespace ePack.Web.Controllers
{
    public abstract class BaseController : AuthenticationController
    {
        protected int FlowId;
    }

    public abstract class AuthenticationController : Controller
    {
        protected IUserContext UserContext;

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (User.Identity.IsAuthenticated)
            {
                // Get current user context into the controller
                IAuthenticationService<IUserContext> authService = (IAuthenticationService<IUserContext>)ServiceLocator.Current.GetService(typeof(IAuthenticationService<IUserContext>));
                if (authService != null)
                    UserContext = authService.LoggedUserContext;
            }

            base.OnAuthorization(filterContext);
        }

        protected void FillModelStateErrors(Exception ex)
        {
            if (ex is InvalidDomainModelException)
                foreach (IValidationResult res in (ex as InvalidDomainModelException).Results)
                    ModelState.AddModelError(res.PropertyName ?? res.ClassContext.Name, string.Format("[{0}] {1}", (res.PropertyName ?? res.ClassContext.Name), res.Message));
            else
                ModelState.AddModelError(string.Empty, ex.Message);
        }
    }
}
