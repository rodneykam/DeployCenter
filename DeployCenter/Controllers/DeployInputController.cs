using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeployCenter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeployCenter.Controllers
{
    public class DeployInputController : Controller
    { 
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new DeployInputModel();

            model.RevisionList = new List<SelectListItem>
                { new SelectListItem { Selected = false, Text = "19.1.5000.1", Value = "1" },
                  new SelectListItem { Selected = false, Text = "19.2.6000.1", Value = "2" },
                  new SelectListItem { Selected = false, Text = "19.3.6500.1", Value = "3" }
                };

            model.EnvironmentList = new List<SelectListItem>
                { new SelectListItem { Selected = false, Text = "Stage", Value = "STAGE"},
                  new SelectListItem { Selected = false, Text = "Integration", Value = "INTEG"},
                  new SelectListItem { Selected = false, Text = "Production", Value = "PROD"},
                };

            model.ServerList = new List<SelectListItem>
                { new SelectListItem { Selected = false, Text = "Server List Goes Here", Value = "1"},
                };

            ViewData["Message"] = "This page displays deployment options.";
            return View(model);
        }
    }
}
