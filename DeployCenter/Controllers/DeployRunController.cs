using DeployCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeployCenter.Controllers
{
    public class DeployRunController : Controller
    {
        // GET: DeployRun
        public ActionResult Index(DeployRunModel model)
        {
            return View(model);
        }
    }
}