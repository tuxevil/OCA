using ePack.ApplicationServices.Views;
using ePack.Core;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ePack.ApplicationServices
{
    public interface IAccountService
    {
        Site CreateSite(string legalName, string siteAddress);
        Site Register(IRegisterView view);

        Site RegisterUser(int customerId, string memberName, string firstName, string lastName, string emailAddress,
                          string userName, string password);

        Site RegisterUser(int customerId, string memberName, string firstName, string lastName, string emailAddress,
                          string userName);

        Site AddFunctionToSite(int siteId, string functionName);
        Site AssignFunctionToUser(int siteId, string userName, string functionName);
    }

    public interface IInternetActivityService
    {
        List<SelectListItem> InternetActivityList();
    }
}