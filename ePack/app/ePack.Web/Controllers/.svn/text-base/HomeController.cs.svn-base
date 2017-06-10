using System.Web.Mvc;
using ePack.ApplicationServices;
using System.Collections;
using ePack.Core;
using System.Collections.Generic;

namespace ePack.Web.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            IList<Feed> lst = new FeedRetrievalService().FeedsList(3);
            return View(lst);
        }
    }
}
