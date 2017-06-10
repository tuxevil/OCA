using System.Web.Mvc;
using System.Collections.Generic;
using ePack.ApplicationServices;
using ePack.Core;

namespace ePack.Web.Controllers
{
    [HandleError]
    public class VendedoresController : BaseController
    {
        public ActionResult Index()
        {
            IList<Feed> lst = new FeedRetrievalService().FeedsList(3);
            return View(lst);
        }
    }
}
